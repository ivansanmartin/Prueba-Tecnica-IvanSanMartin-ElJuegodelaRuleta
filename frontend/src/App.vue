<script setup>
import HelloWorld from './components/HelloWorld.vue'
import TheWelcome from './components/TheWelcome.vue'
</script>

<template>
    <div class="wrapper d-flex flex-column justify-content-center align-items-center mt-5">
      <div class="arrow">
      </div>
      <div class="roulette">
        <div class="wheel spin">
          <img class="roulette-wheel" src="/images/roulette.png">
        </div>
      </div>
      
      <div class="spin-button">
        <button class="btn btn-secondary" @click="spinRoulette">Girar ruleta</button>
      </div>
    </div>
</template>

<script>

import axios from "axios"

export default {
  data() {
    return {
      apiResult: null,
      errorMessage: ""
    };
  },
  methods: {

    async spinRoulette() {
      try {
        const roulette = document.querySelector('.roulette-wheel');
        roulette.style.transition = "none";  
        roulette.style.transform = "rotate(0deg)"


        await new Promise(resolve => setTimeout(resolve, 50));

        const response = await axios.get("http://localhost:5138/api/spin-roulette");
        this.apiResult = response;
        const numbersOrder = [0, 32, 15, 19, 4, 21, 2, 25, 17, 34, 6, 27, 13, 36, 11, 30, 8, 23, 10, 5, 24, 16, 33, 1, 20, 14, 31, 9, 22, 18, 29, 7, 28, 12, 35, 3, 26];
        const baseRotation = -1080;
        const degreesPerNumber = -360 / numbersOrder.length;
        
        const numberIndex = numbersOrder.indexOf(this.apiResult.data.number);
        if (numberIndex === -1) {
            console.error("The number is not correct.");
            return;
        }
        
        const extraTurns = -360 * 5; 
        const finalRotation = baseRotation + (numberIndex * degreesPerNumber) + extraTurns;

        console.log(this.apiResult.data.number, this.apiResult.data.color)

        setTimeout(() => {
          roulette.style.transition = "transform 3s ease-out";
          roulette.style.transform = `rotate(${finalRotation}deg)`;

        }, 500)

      } catch (error) {
        this.errorMessage = "Error al comunicarse con el servicio";
        console.log(error)
      }
    },

    restartRoulette(roulette) {
    }
    
  }
};

</script>

