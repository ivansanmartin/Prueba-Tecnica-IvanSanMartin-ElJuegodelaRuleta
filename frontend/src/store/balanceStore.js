import { defineStore } from "pinia";
import { ref } from "vue";

export const useBalanceStore = defineStore("balance", () => {
    const balance = ref(0)

    const setBalance = (amount) => {
        balance.value = amount
    }

    return { balance, setBalance }
})