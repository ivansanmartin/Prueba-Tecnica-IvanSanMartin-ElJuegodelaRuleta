<template>
    <div class="option-color-and-parity">
        <div class="input-group mt-4">
            <span class="input-group-text"><span><small>🔴</small></span>|<span><small>⚫</small></span></span>
            <select name="color" v-model="color" id="color" class="form-select">
                <option value="">Seleccione algún color</option>
                <option value="red">Rojo</option>
                <option value="black">Negro</option>
            </select>
        </div>

        <div class="mt-3">
            <select name="parity" v-model="parity" id="parity" class="form-select">
                <option value="">Seleccione paridad</option>
                <option value="pair">Pares</option>
                <option value="odd">Impares</option>
            </select>
        </div>

    </div>


    <div class="error-select-parity">
        <p v-if="!parity || !color" class="alert alert-warning mt-2">
            Por favor seleccione un color y paridad.
        </p>
    </div>

    <RouletteLoading></RouletteLoading>

    <div v-if="rouletteStore.roulette != null && showResult" class="alert alert-secondary mt-4">
        <div class="title">
            <h6>Resultado de la ruleta: </h6>
        </div>
        <div class="results-roulette d-flex flex-column mt-3">
            <div class="d-flex flex-column align-items-start">
                <p>
                    Número, color y paridad: <span><small class="badge text-bg-primary">{{
                        rouletteStore.roulette.number }}</small> |
                        <small class="badge text-bg-primary">{{ rouletteStore.roulette.color == "red" ? "🔴" :
                            rouletteStore.roulette.color == "green" ? "🟢" : "⚫" }}</small> |
                        <small class="badge text-bg-primary">{{ parityObject[rouletteStore.roulette.parity]
                        }}</small></span>
                </p>
                <p>
                    Color y paridad apostado: <span><small class="badge text-bg-primary">
                            {{ finalColor == "red" ? "🔴" : color == "green" ? "🟢" : "⚫" }}</small> | <small
                            class="badge text-bg-primary">{{ parityObject[finalParity] }}</small></span>
                </p>

            </div>

            <div class="d-flex justify-content-center">
                <p v-if="wonColorAndParityBet" class="mt-3 text-success fw-bold">
                    ¡Ganaste! 🎉
                </p>
                <p v-else-if="showResult" class="mt-3 text-danger fw-bold">
                    Perdiste 😢
                </p>
            </div>

        </div>
    </div>

    <GameResult v-if="gameResultStore.result || lastProfitStore.profit != null" :result="gameResultStore.result"
        :loading="gameIsLaoding" />

    <SaveResult v-if="shouldShowSaveResult && lastProfitStore.profit > 0"">
    </SaveResult>

    <SpinRouletteButton :is-disabled="isDisabledButton || balanceStore.balance < betStore.bet">
        </SpinRouletteButton>
</template>

<script setup>
import { ref, computed, watch } from "vue";
import SpinRouletteButton from "../layout/SpinRouletteButton.vue";
import RouletteLoading from "../layout/RouletteLoading.vue";
import SaveResult from "../layout/SaveResult.vue";
import GameResult from "../layout/GameResult.vue";
import { useSpinRouletteStore } from "@/store/roulette/spinRouletteStore";
import { useStoppedRoulette } from "@/store/roulette/stoppedRouletteStore";
import { useBalanceStore } from "@/store/game/balanceStore";
import { useBetStore } from "@/store/game/betStore";
import { useGameResultStore } from '@/store/user/gameResultStore';
import { useLoggedStore } from '@/store/user/loggedStore';
import { useLastProfitStore } from '@/store/game/lastProfitStore';
import { useGame } from '@/composables/useGame';
import { useLoadingStore } from "@/store/game/loadingStore";


const parity = ref("");
const color = ref("");
const finalParity = ref("")
const finalColor = ref("")
const showResult = ref(false);
const gameIsLaoding = ref(false);

const rouletteStore = useSpinRouletteStore();
const stoppedRoulette = useStoppedRoulette();
const balanceStore = useBalanceStore();
const loadingStore = useLoadingStore();
const gameResultStore = useGameResultStore();
const betStore = useBetStore();
const loggedStore = useLoggedStore();
const lastProfitStore = useLastProfitStore();

const parityObject = ref({
    pair: "Par",
    odd: "Impar"
});

const colorObject = ref({
    black: "Negro",
    red: "Rojo"
});

const wonColorAndParityBet = computed(() => {
    return (
        showResult.value &&
        rouletteStore.roulette &&
        rouletteStore.roulette.color === finalColor.value &&
        rouletteStore.roulette.parity === finalParity.value
    );
});

const shouldShowSaveResult = computed(() => {
    return loggedStore.isLogged && gameResultStore.result
        && gameResultStore.result.is_winner && lastProfitStore.profit != null && !gameIsLaoding.value
});

const isDisabledButton = computed(() => {
    return parity.value === "" || color.value === "" || loadingStore.isLoading;
});

watch(
    [() => stoppedRoulette.isStopped, () => loadingStore.isLoading],
    async ([stopped, loading]) => {
        showResult.value = false;
        gameIsLaoding.value = true;

        if (stopped && !loading) {
            finalColor.value = color.value;
            finalParity.value = parity.value;
            showResult.value = true;

            const body = {
                "betType": 0,
                "betAmount": betStore.bet,
                "winning": wonColorAndParityBet.value
            }

            await useGame(body);
            gameIsLaoding.value = false;

            if (gameResultStore.result.is_winner) {
                balanceStore.setBalance(balanceStore.balance + gameResultStore.result.amount_won);
                lastProfitStore.setProfit(gameResultStore.result.amount_won);
            } else {
                balanceStore.setBalance(balanceStore.balance - gameResultStore.result.amount_lost);
            }
        }
    }
);

</script>