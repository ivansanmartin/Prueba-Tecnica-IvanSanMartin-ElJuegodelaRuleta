<template>
    <div class="option-number-and-color d-flex flex-column">
        <div class="input-group mt-4">
            <span class="input-group-text"><span><small>🔴</small></span>|<span><small>⚫</small></span></span>
            <select name="color" v-model="color" id="color" class="form-select">
                <option selected>Seleccione algún color</option>
                <option value="red">Rojo</option>
                <option value="black">Negro</option>
            </select>
        </div>

        <div class="mt-3">
            <input type="number" v-model="number" name="numBet" id="numerBet" class="form-control"
                placeholder="Ingrese un número">
        </div>

        <div v-if="errorMessage" class="alert alert-danger mt-3">
            {{ errorMessage }}
        </div>

        <RouletteLoading></RouletteLoading>


        <div v-if="showResult" class="alert alert-secondary mt-4">
            <div class="title">
                <h6>Resultado de la ruleta: </h6>
            </div>
            <div class="results-roulette d-flex flex-column align-items-start mt-3">
                <p>Ruleta: <small class="badge text-bg-primary">{{ rouletteStore.roulette.number }}</small> | <small class="badge text-bg-primary">{{
                    rouletteStore.roulette.color == "red" ? "🔴" : rouletteStore.roulette.color == "green" ? "🟢" : "⚫"
                            }}</small></p>
                <p>Apuesta: <small class="badge text-bg-primary">{{ number }}</small> | <small class="badge text-bg-primary">{{ color == "red" ? "🔴" : color == "green" ?
                            "🟢" : "⚫" }}</small></p>
            </div>
        </div>

    </div>

    <SpinRouletteButton :is-disabled="isDisabledButton"></SpinRouletteButton>

</template>

<script setup>

import { Colors } from "@/enums/colors";
import SpinRouletteButton from "../SpinRouletteButton.vue";
import RouletteLoading from "../RouletteLoading.vue";
import { useSpinRouletteStore } from "@/store/spinRouletteStore";
import { useStoppedRoulette } from '@/store/stoppedRouletteStore';
import { useBalanceStore } from "@/store/balanceStore";
import { useLoadingStore } from "@/store/loadingStore";
import { ref, watch, computed } from "vue";

const color = ref("");
const number = ref();
const errorMessage = ref("");
const showResult = ref(false);

const rouletteStore = useSpinRouletteStore();
const balanceStore = useBalanceStore();
const stoppedRoulette = useStoppedRoulette();
const loadingStore = useLoadingStore();


const setColor = (event) => {
    color.value = event.target.value;
    validateForm();
};

const setNumber = (event) => {
    number.value = event.target.value;
    validateForm();
};

const isDisabledButton = computed(() => {
    if (!color.value || !number.value || loadingStore.isLoading) {
        errorMessage.value = "";
        return true;
    }

    const numberColor = Colors.ROULETTE[number.value];

    if (!numberColor) {
        errorMessage.value = "Número inválido. Asegúrate de que esté dentro del rango de la ruleta.";
        return true;
    }

    if (numberColor !== color.value) {
        errorMessage.value = `El número ${number.value} es ${
            numberColor === "red" ? "🔴 rojo" : numberColor === "black" ? "⚫ negro" : "🟢 verde"
        }, no coincide con el color seleccionado.`;
        return true;
    }

    errorMessage.value = "";
    return false;
});


watch(number, (value) => {
    if (!number.value) {
        number.value = 0
    }
    if (value < 0) {
        number.value = Math.abs(value);
    }
})

watch(
  [() => stoppedRoulette.isStopped, () => loadingStore.isLoading],
  ([stopped, loading]) => {
    showResult.value = false;

    if (stopped && !loading) {
      showResult.value = true;
    } 
  }
);

</script>