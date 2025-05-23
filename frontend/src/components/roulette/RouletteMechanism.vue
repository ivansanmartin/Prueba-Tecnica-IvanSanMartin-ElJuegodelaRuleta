<template>
	<div class="wrapper d-flex flex-column align-items-center">
		<div class="roulette">
			<div class="arrow"></div>
			<div class="wheel spin">
				<img
					class="roulette-wheel"
					src="/images/roulette.png"
					style="width: 100%"
				/>
			</div>
		</div>

		<div class="first-game-roulette">
			<h3 class="text-center">Comienze agregando un saldo y apuesta</h3>
			<form class="d-flex gap-4 mt-4">
				<div class="input-group">
					<span class="input-group-text"
						><i class="fa-solid fa-dollar-sign"></i
					></span>
					<input
						type="number"
						v-model="balance"
						name="balance"
						id="balance"
						class="form-control"
						placeholder="Ingrese su saldo"
					/>
				</div>
				<div class="input-group">
					<span class="input-group-text"
						><i class="fa-solid fa-coins"></i
					></span>
					<input
						type="number"
						v-model="bet"
						name="bet"
						id="balance"
						class="form-control"
						placeholder="Ingrese su apuesta"
					/>
				</div>
			</form>
		</div>

		<div class="criterion-errors mt-4">
			<p v-if="criterionNotMet" class="text-warning">
				{{ errorMessage }}
			</p>
		</div>

		<div class="game-options text-center mt-5 d-flex flex-column">
			<h3>¿A qué desea apostar?</h3>
			<p v-if="balance == 0 || bet == 0" class="text-warning">
				Por favor ingrese un saldo y apuesta
			</p>
			<div class="options mt-3 d-flex flex-column align-items-center">
				<div>
					<select
						name="betType"
						@change="getSelectedOption($event)"
						:disabled="balance == 0 || bet == 0 || criterionNotMet"
						id="betType"
						class="form-select"
					>
						<option selected>Seleccione un tipo de apuesta</option>
						<option value="0">Apostar por un color</option>
						<option value="1">
							Apostar por pares o impares de un color
						</option>
						<option value="2">
							Apostar por un número y su color
						</option>
					</select>
				</div>

				<ColorOption v-if="selectedBetType === '0'"></ColorOption>
				<ParityColorOption
					v-if="selectedBetType === '1'"
				></ParityColorOption>
				<NumberColor v-if="selectedBetType === '2'"></NumberColor>
			</div>
		</div>
	</div>
</template>

<script setup>
import ColorOption from "../game-options/ColorOption.vue";
import NumberColor from "../game-options/NumberColorOption.vue";
import ParityColorOption from "../game-options/ParityColorOption.vue";
import { useBalanceStore } from "@/store/game/balanceStore";
import { useBetStore } from "@/store/game/betStore";
import { useLastProfitStore } from "@/store/game/lastProfitStore";
import { useNoAvailableStore } from "@/store/game/noAvailableStore";
import { useGameResultStore } from "@/store/user/gameResultStore";

import { ref, watch } from "vue";
import { storeToRefs } from "pinia";

const selectedBetType = ref(null);
const criterionNotMet = ref(false);
const errorMessage = ref("");

const balanceStore = useBalanceStore();
const betStore = useBetStore();
const lastProfitStore = useLastProfitStore();
const noAvailableStore = useNoAvailableStore();
const gameResultStore = useGameResultStore();

const { balance } = storeToRefs(balanceStore);
const { bet } = storeToRefs(betStore);

watch(bet, (val) => {
	if (!bet.value) {
		bet.value = 0;
	}

	if (val < 0) {
		bet.value = Math.abs(val);
	}
});

watch([() => balance.value, () => bet.value], ([newBalance, newBet]) => {
	if (!newBalance) {
		balance.value = 0;
	}
	if (newBalance < 0) {
		balance.value = Math.abs(val);
	}

	if (!newBet) {
		bet.value = 0;
	}
	if (newBet < 0) {
		bet.value = Math.abs(val);
	}

	if (newBalance < newBet) {
		errorMessage.value = "No tiene fondos suficientes para apostar.";
		criterionNotMet.value = true;
		noAvailableStore.setAvailable(false);
	} else {
		criterionNotMet.value = false;
		noAvailableStore.setAvailable(true);
	}
});

const getSelectedOption = (event) => {
	selectedBetType.value = event.target.value;
	lastProfitStore.setProfit(null);
	gameResultStore.loadGameResult(null);
};
</script>

<style scoped>
.game-options {
	width: 50%;
}
</style>
