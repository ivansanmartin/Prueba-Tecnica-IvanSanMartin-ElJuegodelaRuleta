<template>
    <div class="option-color-and-parity">
        <div class="input-group mt-4">
            <span class="input-group-text"><span><small>🔴</small></span>|<span><small>⚫</small></span></span>
            <select name="color" v-model="color" id="color" class="form-select">
                <option value="">Seleccione algún color</option>
                <option value="rojo">Rojo</option>
                <option value="negro">Negro</option>
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
        <div class="results-roulette d-flex flex-column align-items-start mt-3">
            <p>Número, color y paridad: <span><small class="badge text-bg-primary">{{ rouletteStore.roulette.number }}</small> | <small class="badge text-bg-primary">{{ colorObject[rouletteStore.roulette.color] }}</small> | <small class="badge text-bg-primary">{{ parityObject[rouletteStore.roulette.parity] }}</small></span></p>
            <p>Color y paridad apostado: <span><small class="badge text-bg-primary">{{ color == "red" ? "🔴" : color == "green" ? "🟢" : "⚫"}}</small> | <small class="badge text-bg-primary">{{ parityObject[parity] }}</small></span>
            </p>
        </div>
    </div>

    <SpinRouletteButton :is-disabled="isDisabledButton"></SpinRouletteButton>
</template>

<script setup>
import { ref, computed, watch } from "vue"
import SpinRouletteButton from "../SpinRouletteButton.vue";
import RouletteLoading from "../RouletteLoading.vue";
import { useSpinRouletteStore } from "@/store/spinRouletteStore";
import { useStoppedRoulette } from "@/store/stoppedRouletteStore";
import { useBalanceStore } from "@/store/balanceStore";
import { useLoadingStore } from "@/store/loadingStore";

const parity = ref("");
const color = ref("");
const showResult = ref(false);
const parityObject = ref({
    pair: "Par",
    odd: "Impar"
})

const colorObject = ref({
    black: "Negro",
    red: "Rojo"
})

const rouletteStore = useSpinRouletteStore();
const stoppedRoulette = useStoppedRoulette();
const balanceStore = useBalanceStore();
const loadingStore = useLoadingStore();


const isDisabledButton = computed(() => {
    return parity.value === "" || color.value === "" || loadingStore.isLoading;
});

watch(
  [() => stoppedRoulette.isStopped, () => loadingStore.isLoading],
  ([stopped, loading]) => {
    showResult.value = false;

    if (stopped && !loading) {
      showResult.value = true;
    }
  }
);

</script>