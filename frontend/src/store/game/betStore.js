import { defineStore } from "pinia";
import { ref } from "vue";

export const useBetStore = defineStore("bet", () => {
    const bet = ref(0)

    const setBet = (amount) => {
        bet.value = amount
    }

    return { bet, setBet }
})