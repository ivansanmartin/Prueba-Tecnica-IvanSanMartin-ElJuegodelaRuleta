<template>
    <div class="profile-info p-3">
        <div class="card mt-4 d-flex flex-row">
            <div class="card-body">
                <div class="balance text-break">
                    <h6 class="mb-2 text-primary">Balance: </h6>
                    <i class="text-success fa-solid fa-dollar-sign"></i><span>{{ balanceStore.balance }}</span>
                </div>
            </div>
        </div>
    </div>
</template>


<script setup>
import { useBalanceStore } from '@/store/balanceStore';

const balanceStore = useBalanceStore();

</script>