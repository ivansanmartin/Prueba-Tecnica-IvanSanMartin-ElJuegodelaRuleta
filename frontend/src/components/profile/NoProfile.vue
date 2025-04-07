<template>
	<div class="profile-info p-3">
		<div class="card mt-4 d-flex flex-row">
			<div class="card-body">
				<h6 class="card-subtitle mb-2 text-body-secondary fw-bold">
					¿Quieres guardar tus ganancias?
				</h6>

                <p class="text-secondary text-center">Crea tú perfil y guarda las <br>ganacias de tus apuestas.</p>
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

const balanceStore = useBalanceStore();
</script>
