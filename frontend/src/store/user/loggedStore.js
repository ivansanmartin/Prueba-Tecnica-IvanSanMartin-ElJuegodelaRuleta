import { defineStore } from "pinia"
import { ref } from "vue"

export const useLoggedStore = defineStore("login", () => {
    const isLogged = ref(false);

    const isLogin = () => isLogged.value = true;

    return { isLogged, isLogin }
})