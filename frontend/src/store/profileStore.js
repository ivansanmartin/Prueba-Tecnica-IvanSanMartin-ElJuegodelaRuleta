import { defineStore } from "pinia";
import { ref } from "vue"

export const useProfileStore = () =>{
    const profile = ref(null);

    const loadProfile = (profileData) => profile.value = profileData;

    return { profile, loadProfile }
}