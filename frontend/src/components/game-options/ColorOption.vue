<template>
  <div class="option-color">
    <div class="input-group mt-4">
      <span class="input-group-text"><span><small>🔴</small></span>|<span><small>⚫</small></span></span>
      <select v-model="colorBet" name="color" id="color" class="form-select">
        <option selected value="">Seleccione algún color</option>
        <option value="red">Rojo</option>
        <option value="black">Negro</option>
      </select>
    </div>
  </div>

  <RouletteLoading></RouletteLoading>

  <div v-if="rouletteStore.roulette != null && showResult" class="alert alert-secondary mt-4">
    <div class="title">
      <h6>Resultado de la ruleta: </h6>
    </div>
    <div class="results-roulette d-flex flex-column mt-3">
      <div class="d-flex flex-column align-items-start">
        <p>
          Color:
          <small class="badge text-bg-primary">
            {{ rouletteStore.roulette.color === "red" ? "🔴" : "⚫" }}
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
        <p v-else class="mt-3 text-danger fw-bold">
          Perdiste 😢
        </p>
      </div>
    </div>
  </div>

  <SpinRouletteButton :is-disabled="isDisabled"></SpinRouletteButton>
</template>

<script setup>
import SpinRouletteButton from '../SpinRouletteButton.vue';
import RouletteLoading from '../RouletteLoading.vue';
import { useSpinRouletteStore } from '@/store/spinRouletteStore';
import { useStoppedRoulette } from '@/store/stoppedRouletteStore';
import { useBalanceStore } from "@/store/balanceStore";
import { useLoadingStore } from '@/store/loadingStore';
import { ref, computed, watch } from 'vue';

const showResult = ref(false);
const colorBet = ref("");
const finalColorBet = ref("");

const rouletteStore = useSpinRouletteStore();
const balanceStore = useBalanceStore();
const stoppedRoulette = useStoppedRoulette();
const loadingStore = useLoadingStore();

const isDisabled = computed(() => {
  return colorBet.value === "" || loadingStore.isLoading
});

const wonColorBet = computed(() => {
  return (
    showResult.value &&
    rouletteStore.roulette &&
    rouletteStore.roulette.color === finalColorBet.value
  );
});

watch(
  [() => stoppedRoulette.isStopped, () => loadingStore.isLoading],
  ([stopped, loading]) => {
    showResult.value = false;
    if (stopped && !loading) {
      showResult.value = true;
      finalColorBet.value = colorBet.value;
    }
  }
);
</script>
