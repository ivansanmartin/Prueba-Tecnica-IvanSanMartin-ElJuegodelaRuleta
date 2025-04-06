import { defineStore } from "pinia";
import { ref } from "vue";

export const useStoppedRoulette = defineStore("isStopped", () => {
    const isStopped = ref(false);

    const setStopped = (stop) => {
        isStopped.value = stop;
    }

    return { isStopped, setStopped };
})