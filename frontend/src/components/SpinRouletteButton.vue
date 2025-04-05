<template>
  <div class="spin-button">
    <button class="btn btn-secondary mt-3" @click="spinRoulette" :disabled="isDisabled">Apostar</button>
  </div>
</template>


<script setup>
import { useRoulette } from '@/composables/useRoulette';
import { defineProps } from 'vue';
import { useStoppedRoulette } from "@/store/stoppedRouletteStore"
import { useLoadingStore } from '@/store/loadingStore';

const stoppedRoulette = useStoppedRoulette();
const loadingStore = useLoadingStore();
  
const props = defineProps({ isDisabled: Boolean })

const spinRoulette = async () => {
  stoppedRoulette.setStopped(false);

  const spinData = await useRoulette();

  const roulette = document.querySelector('.roulette-wheel');
  roulette.style.transition = "none";
  roulette.style.transform = "rotate(0deg)"

  await new Promise(resolve => setTimeout(resolve, 50));

  const numbersOrder = [0, 32, 15, 19, 4, 21, 2, 25, 17, 34, 6, 27, 13, 36, 11, 30, 8, 23, 10, 5, 24, 16, 33, 1, 20, 14, 31, 9, 22, 18, 29, 7, 28, 12, 35, 3, 26];
  const baseRotation = -1080;
  const degreesPerNumber = -360 / numbersOrder.length;

  const numberIndex = numbersOrder.indexOf(spinData.number);
  if (numberIndex === -1) {
    console.error("The number is not correct.");
    return;
  }

  const extraTurns = -360 * 5;
  const finalRotation = baseRotation + (numberIndex * degreesPerNumber) + extraTurns;

  roulette.style.transition = "transform 3s ease-out";
  roulette.style.transform = `rotate(${finalRotation}deg)`;

  loadingStore.startLoading();
  setTimeout(() => {
    stoppedRoulette.setStopped(true);
    loadingStore.stopLoading()
  }, 3400)
}

</script>