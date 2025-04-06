<template>
    <div class="profile-info p-3">
        <div class="card mt-4 d-flex flex-row">
            <div class="card-body text-break text-wrap">
                <h5 class="card-title">{{ profileStore.profile.data.username }}</h5>
                <h6 class="card-subtitle mb-2 text-body-secondary">¡Bienvenido de vuelta!</h6>
                
                
                <div class="balance mt-4">
                    <h6 class="mb-2 text-primary">Balance: </h6>
                    <i class="text-success fa-solid fa-dollar-sign"></i><span> {{ balanceStore.balance }}</span>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup>
import { useBalanceStore } from '@/store/game/balanceStore';
import { useProfileStore } from '@/store/user/profileStore';
import { storeToRefs } from 'pinia';

const balanceStore = useBalanceStore();
const profileStore = useProfileStore();

</script>
