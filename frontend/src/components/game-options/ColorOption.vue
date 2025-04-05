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
    <div class="results-roulette d-flex flex-column align-items-start mt-3">
      <p>Color: <small class="badge text-bg-primary">{{ rouletteStore.roulette.color == "red" ? "🔴" : colorBet ==
        "green" ? "🟢" : "⚫"
      }}</small></p>
      <p>Color apostado: <small class="badge text-bg-primary">{{ colorBet == "red" ? "🔴" : colorBet == "green" ? "🟢" :
        "⚫" }}</small>
      </p>
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


const rouletteStore = useSpinRouletteStore();
const balanceStore = useBalanceStore();
const stoppedRoulette = useStoppedRoulette();
const loadingStore = useLoadingStore();

const isDisabled = computed(() => {
  return colorBet.value === "" || loadingStore.isLoading
})

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