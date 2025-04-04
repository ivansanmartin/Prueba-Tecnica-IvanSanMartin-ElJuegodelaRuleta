<template>

  <div class="wrapper d-flex flex-column align-items-center">

    <div class="arrow">
    </div>
    <div class="roulette">
      <div class="wheel spin">
        <img class="roulette-wheel" src="/images/roulette.png">
      </div>
    </div>

    <div class="first-game-roulette">
      <h3>Comienze agregando un saldo y apuesta</h3>
      <form class="d-flex gap-4 mt-4">
        <div class="input-group">
          <span class="input-group-text"><i class="fa-solid fa-dollar-sign"></i></span>
          <input type="text" name="balance" id="balance" class="form-control" placeholder="Ingrese su saldo">
        </div>
        <div class="input-group">
          <span class="input-group-text"><i class="fa-solid fa-coins"></i></span>
          <input type="text" name="bet" id="balance" class="form-control" placeholder="Ingrese su apuesta">
        </div>
      </form>
    </div>

    <div class="game-options text-center mt-5 d-flex flex-column align-items-center">
      <h3>¿A qué desea apostar?</h3>
      <div class="options mt-3 d-flex flex-column align-items-center">

        <div class="mt-3">
          <select name="betType" @change="getSelectedOption($event)" id="betType" class="form-select">
            <option selected>Seleccione un tipo de apuesta</option>
            <option value="0">Apostar por un color</option>
            <option value="1">Apostar por pares o impares de un color</option>
            <option value="2">Apostar por un número y su color</option>
          </select>
        </div>

        <ColorOption v-if="selectedBetType === '0'"></ColorOption>
        <ParityColorOption v-if="selectedBetType === '1'"></ParityColorOption>
        <NumberColor v-if="selectedBetType === '2'"></NumberColor>

      </div>

    </div>

    <div class="load-profile-game mt-4 d-flex flex-column align-items-center gap-2">
      <div class="information d-flex flex-column align-items-center">
        <div class="title">
          <h3>¡Cargué su perfil aquí!</h3>
        </div>
        <div class="description mt-3">
          <p class="text-white">Cargué su perfil para obtener su saldo actual y comience a duplicar su dinero.</p>
        </div>
      </div>
      <button class="btn btn-success" data-bs-toggle="modal" data-bs-target="#loadProfileModal">Cargar mi
        perfil</button>

      <div class="modal fade" id="loadProfileModal" tabindex="-1" aria-labelledby="loadProfileModal" aria-hidden="true">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <h1 class="modal-title fs-5" id="loadProfileLabel">Cargar mi perfil</h1>
              <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
              <form>
                <div class="input-group">
                  <span class="input-group-text"><i class="fa-solid fa-user-tie"></i></span>
                  <input type="text" name="username" id="username" class="form-control"
                    placeholder="Ingrese su nombre de usuario (ejemplo: ivan)">
                </div>
              </form>
            </div>
            <div class="modal-footer">
              <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
              <button type="button" class="btn btn-primary">Cargar</button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>

</template>


<script setup>

import ColorOption from "./game-options/ColorOption.vue"
import NumberColor from "./game-options/NumberColor.vue"
import ParityColorOption from "./game-options/ParityColorOption.vue"

import axios from "axios"
import { ref } from "vue"

const selectedBetType = ref(null);

const getSelectedOption = (event) => {
  selectedBetType.value = event.target.value;
};


const spinRoulette = async () => {

  try {
    const roulette = document.querySelector('.roulette-wheel');
    roulette.style.transition = "none";
    roulette.style.transform = "rotate(0deg)"


    await new Promise(resolve => setTimeout(resolve, 50));

    const response = await axios.get("http://localhost:5138/api/spin-roulette");
    const numbersOrder = [0, 32, 15, 19, 4, 21, 2, 25, 17, 34, 6, 27, 13, 36, 11, 30, 8, 23, 10, 5, 24, 16, 33, 1, 20, 14, 31, 9, 22, 18, 29, 7, 28, 12, 35, 3, 26];
    const baseRotation = -1080;
    const degreesPerNumber = -360 / numbersOrder.length;

    const numberIndex = numbersOrder.indexOf(response.data.number);
    if (numberIndex === -1) {
      console.error("The number is not correct.");
      return;
    }

    const extraTurns = -360 * 5;
    const finalRotation = baseRotation + (numberIndex * degreesPerNumber) + extraTurns;

    console.log(response.data.number, response.data.color)

    setTimeout(() => {
      roulette.style.transition = "transform 3s ease-out";
      roulette.style.transform = `rotate(${finalRotation}deg)`;

    }, 500)

  } catch (error) {
    console.log(error)
  }

}

</script>


<style scoped>
.game-options {
  width: 50%;
}
</style>