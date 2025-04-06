<template>
    <div class="load-profile-game mt-3 m-2 d-flex flex-column align-items-center gap">
        <button v-if="!showInput" class="btn btn-success" @click="showInput = true">
            Cargar o crear mi perfil
        </button>

        <div v-else>
            <div class="input-group">
                <span class="input-group-text"><i class="fa-solid fa-user-tie"></i></span>
                <input
                    type="text"
                    name="username"
                    v-model="username"
                    id="username"
                    class="form-control"
                    placeholder="Ingrese su nombre de usuario (ejemplo: ivan)"
                />
            </div>
            <button 
                type="button" 
                class="btn btn-primary mt-2" 
                @click="loadProfile" 
                :disabled="isDisabledButton"
            >
                Cargar
            </button>
            <p v-if="profileNotFound" class="text-danger">No se ha encontrado el perfil.</p>
        </div>
    </div>
</template>

<script setup>
import { ref, computed } from "vue";
import { useBalanceStore } from "@/store/game/balanceStore";
import { useLoggedStore } from "@/store/user/loggedStore";
import { useUser } from "@/composables/useUsers";
import { createUser } from "@/helpers/createUserProfile";
import { useProfileStore } from "@/store/user/profileStore";


const username = ref("");
const profileNotFound = ref(false);
const showInput = ref(false);

const balanceStore = useBalanceStore();
const loggedStore = useLoggedStore();
const profileStore = useProfileStore();

const isDisabledButton = computed(() => {
    return username.value.length == 0;
});

const loadProfile = async () => {
    profileNotFound.value = false;
    try {
        const profile = await useUser(username.value);     

        if (!profile.ok) {
            const newProfile = await createUser({
                username: username.value,
                amount: 0
            })

            profileStore.loadProfile(newProfile)
            balanceStore.setBalance(newProfile.amount);
            loggedStore.isLogin()
            return;
        }

        balanceStore.setBalance(profile.data.amount);
        loggedStore.isLogin()

    } catch (error) {
        if (error && error.message && error.message_code === "UNKNOWN_ERROR") {
            profileNotFound.value = true;
        }
    }
};
</script>
