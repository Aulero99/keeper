<template>
  
  <header>
    <Navbar />
  </header>
  
  <main class="container-fluid">
    <router-view />
  </main>
  
  <footer class="m-3">
    <button class="btn btn-dark" data-bs-toggle="modal" data-bs-target="#vaultModal" >Open Modal</button>
  </footer>
  
  <Modal id="keepModal">
    <ModalKeep/>
  </Modal>

  <Modal id="vaultModal">
    <ModalVault/>
  </Modal>
  
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root{
  --main-height: calc(100vh - 32px - 64px);
}


footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
