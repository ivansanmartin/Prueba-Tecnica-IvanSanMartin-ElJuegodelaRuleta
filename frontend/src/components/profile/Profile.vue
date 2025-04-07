<template>
	<div class="profile-info p-3">
		<div class="card mt-4 d-flex flex-row">
			<div class="card-body text-break text-wrap">
				<h5 class="card-title">
					{{ profileStore.profile.data.username }}
				</h5>
				<h6 class="card-subtitle mb-2 text-body-secondary">
					¡Bienvenido de vuelta!
				</h6>

				<div class="balance text-break d-flex gap-1 align-items-center">
					<h6 class="text-primary m-0">Balance:</h6>
                    <span><i class="text-success fa-solid fa-dollar-sign"></i
                        >{{ balanceStore.balance }}</span>
				</div>
			</div>
		</div>
	</div>
</template>

<script setup>
import { useBalanceStore } from "@/store/game/balanceStore";
import { useProfileStore } from "@/store/user/profileStore";

const balanceStore = useBalanceStore();
const profileStore = useProfileStore();
</script>
