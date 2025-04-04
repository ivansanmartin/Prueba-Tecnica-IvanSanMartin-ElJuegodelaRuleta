<template>
    <div class="option-color-and-parity">
        <div class="input-group mt-4">
            <span class="input-group-text"><span><small>🔴</small></span>|<span><small>⚫</small></span></span>
            <select name="color" v-model="color" id="color" class="form-select">
                <option value="">Seleccione algún color</option>
                <option value="rojo">Rojo</option>
                <option value="negro">Negro</option>
            </select>
        </div>

        <div class="mt-3">
            <select name="parity" v-model="parity" id="parity" class="form-select">
                <option value="">Seleccione paridad</option>
                <option value="0">Pares</option>
                <option value="1">Impares</option>
            </select>
        </div>

    </div>


    <div class="error-select-parity">
        <p v-if="!parity || !color" class="alert alert-warning mt-2">
            Por favor seleccione un color y paridad.
        </p>
    </div>

    <SpinRouletteButton :is-disabled="isDisabledButton"></SpinRouletteButton>
</template>

<script setup>
import { ref, computed } from "vue"
import SpinRouletteButton from "../SpinRouletteButton.vue";

const parity = ref("");
const color = ref("");

const isDisabledButton = computed(() => {
  return parity.value === "" || color.value === "";
});


</script>