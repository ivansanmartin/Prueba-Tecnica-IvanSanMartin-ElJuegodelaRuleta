<template>
    <div class="option-color-and-parity">
        <div class="input-group mt-4">
            <span class="input-group-text"><span><small>🔴</small></span>|<span><small>⚫</small></span></span>
            <select name="color" id="color" class="form-select">
                <option selected>Seleccione algún color</option>
                <option value="rojo">Rojo</option>
                <option value="negro">Negro</option>
            </select>
        </div>

        <div class="mt-3">
            <select name="parity" @change="calculateParity($event)" id="parity" class="form-select">
                <option selected>Seleccione paridad</option>
                <option value="0">Pares</option>
                <option value="1">Impares</option>
            </select>
        </div>

    </div>


    <div class="numbers-parity w-50">
        <div id="numbers-display" class="mt-3">
            <h4>Números disponibles:</h4>

            <div v-if="numbers.length > 0" class="d-flex justify-content-center flex-wrap gap-2 mt-3">
                <div v-for="(number, index) in numbers" :key="index" class="form-check">
                    <input class="form-check-input" type="checkbox" :id="'number-' + number" :value="number"
                        v-model="selectedNumbers">
                    <label class="form-check-label" :for="'number-' + number">
                        {{ number }}
                    </label>
                </div>
            </div>

            <p v-else class="alert alert-warning mt-2">
                Por favor seleccione una paridad.
            </p>
        </div>
    </div>

    <div class="spin-button">
        <button class="btn btn-secondary mt-5" @click="">Apostar</button>
    </div>
</template>

<script setup>
import { ref, watch  } from "vue"

const numbers = ref([])
const selectedNumbers = ref([]); 

const calculateParity = (value) => {
    switch (value.target.value) {
        case "0":
            numbers.value = Array.from({ length: 37 }, (_, i) => i).filter(num => num % 2 === 0);
            break;
        case "1":
            numbers.value = Array.from({ length: 37 }, (_, i) => i).filter(num => num % 2 !== 0);
        default:
            break;
    }

}

watch(selectedNumbers, (newVal) => {
  console.log('Selected numbers:', newVal);
});

</script>