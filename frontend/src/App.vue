<template>
  <Header></Header>

  <div class="container-fluid">
    <div v-if="!loggedStore.isLogged" class="row">
      <div class="col-12 d-flex justify-content-end">
        <LoadProfile></LoadProfile>
      </div>
    </div>

    <div class="row">
      <div class="col-md-2 col-12 text-center mb-3">
        <div v-if="loggedStore.isLogged" class="profile">
          <Profile></Profile>
        </div>
        <div v-if="!loggedStore.isLogged">
          <NoProfile></NoProfile>
        </div>
      </div>

      <div class="col-md-8 col-12">
        <RouletteMechanism></RouletteMechanism>
      </div>
    </div>
  </div>

  <Footer></Footer>
</template>

<script setup>
import RouletteMechanism from "./components/RouletteMechanism.vue";
import Header from "./components/Header.vue";
import Footer from "./components/Footer.vue";
import Profile from "./components/Profile.vue";
import LoadProfile from "./components/LoadProfile.vue";
import NoProfile from "./components/NoProfile.vue";

import { useLoggedStore } from "./store/loggedStore";

const loggedStore = useLoggedStore();

</script>

<style scoped></style>
