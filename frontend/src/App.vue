<template>
  <Header></Header>

  <div class="container-fluid">
    <div class="d-flex justify-content-end">
      <LoadProfile v-if="!loggedStore.isLogged"></LoadProfile>
    </div>
    <div class="d-flex profiles">
      <div class="d-flex justify-content-start">
        <div v-if="!loggedStore.isLogged">
          <NoProfile></NoProfile>
        </div>
        <div v-if="loggedStore.isLogged">
          <Profile></Profile>
        </div>
      </div>
    </div>

    <div class="row">
      <div class="col-md-2 col-12 text-center mb-3">
      </div>
      <div class="col-md-8 col-12">
        <RouletteMechanism></RouletteMechanism>
      </div>
    </div>
  </div>

  <Footer></Footer>
</template>

<script setup>
import RouletteMechanism from "./components/roulette/RouletteMechanism.vue";
import Header from "./components/layout/Header.vue";
import Footer from "./components/layout/Footer.vue";
import Profile from "./components/profile/Profile.vue";
import LoadProfile from "./components/profile/LoadProfile.vue";
import NoProfile from "./components/profile/NoProfile.vue";

import { useLoggedStore } from "./store/user/loggedStore";

const loggedStore = useLoggedStore();

</script>

<style scoped></style>
