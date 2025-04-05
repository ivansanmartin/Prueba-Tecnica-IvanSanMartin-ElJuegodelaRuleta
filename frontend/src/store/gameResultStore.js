import { defineStore } from "pinia";
import { ref } from "vue";

export const useGameResultStore = defineStore("gameResult", () => {
    const result = ref(null)

    const loadGameResult = (gameResult) => result.value = gameResult;

    return {result, loadGameResult};
})