import { defineStore } from "pinia"

import { ref } from "vue"

export const useSpinRouletteStore = defineStore("roulette", () => {
    const roulette = ref(null);

    const setRoulette = (spin) => roulette.value = spin;

    return { roulette, setRoulette }
 })