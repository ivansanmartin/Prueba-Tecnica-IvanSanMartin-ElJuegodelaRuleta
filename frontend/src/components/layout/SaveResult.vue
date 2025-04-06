<template>
    <div class="load-profile-game mt-3 m-2 d-flex flex-column align-items-center mt-4">
        <button class="btn btn-success" @click="saveProfit" :disabled="dataSave">
            <span>{{ dataSave ? "Ganancias guardadas al perfil: " + profileStore.profile.data.username : "Guardar ganancia en el perfil" }}</span>
        </button>
    </div>

    <div v-if="isLoading" class="loading mt-5 d-flex flex-column align-items-center gap-3">
        <div class="spinner-border text-danger" role="status">
        </div>
        <div>
            <p>Guardando ganancias al perfil: {{ profileStore.profile.data.username }}</p>
        </div>
    </div>

</template>

<script setup>
import { updateUser } from '@/helpers/updateUser';
import { useProfileStore } from '@/store/user/profileStore';
import { useLastProfitStore } from '@/store/game/lastProfitStore';
import { ref } from 'vue';


const profileStore = useProfileStore();
const lastProfitStore = useLastProfitStore();
const dataSave = ref(false);
const isLoading = ref(false);

const saveProfit = async () => {
    dataSave.value = false;
    isLoading.value = true;
    const body = {
        "username": profileStore.profile.data.username,
        "amount": lastProfitStore.profit
    }

    await updateUser(body)

    dataSave.value = true;

    setTimeout(() => {
        isLoading.value = false;
    }, 2000)

}



</script>