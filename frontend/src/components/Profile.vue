<template>
    <div class="profile-info p-3">
        <div class="card mt-4 d-flex flex-row">
            <div class="card-body text-break text-wrap">
                <h5 class="card-title">ivan</h5>
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
import { useBalanceStore } from '@/store/balanceStore';

const balanceStore = useBalanceStore();

</script>
