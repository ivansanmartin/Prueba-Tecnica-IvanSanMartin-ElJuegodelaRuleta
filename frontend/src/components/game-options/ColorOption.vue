<template>
	<div class="option-color">
		<div class="input-group mt-4">
			<span class="input-group-text"
				><span><small>🔴</small></span
				>|<span><small>⚫</small></span></span
			>
			<select
				v-model="colorBet"
				name="color"
				id="color"
				class="form-select"
			>
				<option selected value="">Seleccione algún color</option>
				<option value="red">Rojo</option>
				<option value="black">Negro</option>
			</select>
		</div>
	</div>

	<RouletteLoading></RouletteLoading>

	<div
		v-if="rouletteStore.roulette != null && showResult"
		class="alert alert-secondary mt-4"
	>
		<div class="title">
			<h6>Resultado de la ruleta:</h6>
		</div>
		<div class="results-roulette d-flex flex-column mt-3">
			<div class="d-flex flex-column align-items-start">
				<p>
					Color:
					<small class="badge text-bg-primary">
						{{
							rouletteStore.roulette.color === "red" ? "🔴" : "⚫"
						}}
					</small>
				</p>
				<p>
					Color apostado:
					<small class="badge text-bg-primary">
						{{ finalColorBet === "red" ? "🔴" : "⚫" }}
					</small>
				</p>
			</div>
			<div class="d-flex justify-content-center align-items-center">
				<p v-if="wonColorBet" class="mt-3 text-success fw-bold">
					¡Ganaste! 🎉
				</p>
				<p v-else class="mt-3 text-danger fw-bold">Perdiste 😢</p>
			</div>
		</div>
	</div>

	<GameResult
		v-if="gameResultStore.result || lastProfitStore.profit != null"
		:result="gameResultStore.result"
		:loading="gameIsLaoding"
	/>

	<SaveResult
		v-if="shouldShowSaveResult && lastProfitStore.profit > 0"
	></SaveResult>

	<SpinRouletteButton
		:is-disabled="isDisabled || balanceStore.balance < betStore.bet"
	></SpinRouletteButton>
</template>

<script setup>
import SpinRouletteButton from "../layout/SpinRouletteButton.vue";
import RouletteLoading from "../layout/RouletteLoading.vue";
import SaveResult from "../layout/SaveResult.vue";
import GameResult from "../layout/GameResult.vue";
import { useSpinRouletteStore } from "@/store/roulette/spinRouletteStore";
import { useStoppedRoulette } from "@/store/roulette/stoppedRouletteStore";
import { useBalanceStore } from "@/store/game/balanceStore";
import { useLoadingStore } from "@/store/game/loadingStore";
import { useBetStore } from "@/store/game/betStore";
import { useGameResultStore } from "@/store/user/gameResultStore";
import { useLoggedStore } from "@/store/user/loggedStore";
import { useLastProfitStore } from "@/store/game/lastProfitStore";
import { useGame } from "@/composables/useGame";
import { ref, computed, watch } from "vue";

const showResult = ref(false);
const colorBet = ref("");
const finalColorBet = ref("");
const gameIsLaoding = ref(false);

const rouletteStore = useSpinRouletteStore();
const balanceStore = useBalanceStore();
const betStore = useBetStore();
const stoppedRoulette = useStoppedRoulette();
const loadingStore = useLoadingStore();
const gameResultStore = useGameResultStore();
const loggedStore = useLoggedStore();
const lastProfitStore = useLastProfitStore();

const isDisabled = computed(() => {
	return colorBet.value === "" || loadingStore.isLoading;
});

const wonColorBet = computed(() => {
	return (
		showResult.value &&
		rouletteStore.roulette &&
		rouletteStore.roulette.color === finalColorBet.value
	);
});

const shouldShowSaveResult = computed(() => {
	return (
		loggedStore.isLogged &&
		gameResultStore.result &&
		gameResultStore.result.is_winner &&
		lastProfitStore.profit != null &&
		!gameIsLaoding.value
	);
});

watch(
	[() => stoppedRoulette.isStopped, () => loadingStore.isLoading],
	async ([stopped, loading]) => {
		showResult.value = false;
		gameIsLaoding.value = true;

		if (stopped && !loading) {
			showResult.value = true;
			finalColorBet.value = colorBet.value;

			const body = {
				betType: 0,
				betAmount: betStore.bet,
				winning: wonColorBet.value,
			};

			await useGame(body);
			gameIsLaoding.value = false;

			if (gameResultStore.result.is_winner) {
				balanceStore.setBalance(
					balanceStore.balance + gameResultStore.result.amount_won
				);
				lastProfitStore.setProfit(gameResultStore.result.amount_won);
			} else {
				balanceStore.setBalance(
					balanceStore.balance - gameResultStore.result.amount_lost
				);
				showResult.value = true;
			}
		}
	}
);
</script>
