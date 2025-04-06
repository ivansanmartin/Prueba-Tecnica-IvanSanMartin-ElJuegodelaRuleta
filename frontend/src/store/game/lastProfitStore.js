import { defineStore } from "pinia";
import { ref } from "vue";

export const useLastProfitStore = defineStore("lastProfit", () => {
    const profit = ref(0);
    const setProfit = (newProfit) => profit.value = newProfit;

    return { profit, setProfit };
})