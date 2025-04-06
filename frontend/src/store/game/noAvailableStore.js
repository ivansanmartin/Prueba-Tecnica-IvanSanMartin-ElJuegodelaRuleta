import { defineStore } from "pinia";
import { ref } from "vue";
 
export const useNoAvailableStore = defineStore("noAvailable", () => {
    const isAvailable = ref(true);

    const setAvailable = (available) => isAvailable.value = available;

    return { isAvailable, setAvailable };
})