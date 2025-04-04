<template>
  <div class="option-color">
    <div class="input-group mt-4">
      <span class="input-group-text"><span><small>🔴</small></span>|<span><small>⚫</small></span></span>
      <select @change="setColorBet($event)" name="color" id="color" class="form-select">
        <option selected>Seleccione algún color</option>
        <option value="red">Rojo</option>
        <option value="black">Negro</option>
      </select>
    </div>
  </div>

  <div v-if="rouletteStore.roulette != null && showResult" class="alert alert-secondary mt-4">
    <div class="title">
      <h6>Resultado de la ruleta: </h6>
    </div>
    <div class="results-roulette d-flex flex-column align-items-start mt-3">
      <p>Color: <span><small>{{ rouletteStore.roulette.color == "red" ? "🔴" : "⚫" }}</small></span></p>
      <p>Color apostado: <span><small>{{ colorBet == "red" ? "🔴" : "⚫" }}</small></span></p>
    </div>
  </div>

  <SpinRouletteButton></SpinRouletteButton>

</template>

<script setup>
import SpinRouletteButton from '../SpinRouletteButton.vue';
import { useSpinRouletteStore } from '@/store/spinRouletteStore';
import { useBalanceStore } from "@/store/balanceStore";
import { ref, watch } from 'vue';



const showResult = ref(false);
const colorBet = ref("");


const rouletteStore = useSpinRouletteStore();
const balanceStore = useBalanceStore();

const setColorBet = (event) => {
  colorBet.value = event.target.value
}


watch(() => rouletteStore.roulette, (newRoulette) => {
  if (newRoulette) {
    showResult.value = false;
    setTimeout(() => {
      showResult.value = true;
    }, 3600);
  }
});

</script>