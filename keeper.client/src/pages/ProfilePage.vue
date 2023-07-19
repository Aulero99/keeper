<template>
  <section class="row mt-4" v-if="profile?.id">
    <ProfileCard :profile="profile"/>
  </section>

  <section class="row">
    <div class="col-12 text-center">
      {{ vaults.length }} Vaults | {{ keeps.length }} Keeps
    </div>
  </section>

  <section class="row mt-4">
    <div class="col-12 overflow-hidden d-flex flex-row justify-content-center">
      <div class="limit-width">
        <h2>Vaults</h2>
      </div>
    </div>
  </section>

  <section class="row">
    <div class="col-12 d-flex flex-row justify-content-center">
      <div class="limit-width d-flex flex-row flex-wrap">
        <div v-for="v in vaults" :key="v.id" class="me-3 mb-3">
          <VaultCard :vault="v"/>
        </div>
      </div>
    </div>
  </section>

  <section class="row mt-4">
    <div class="col-12 d-flex flex-row justify-content-center">
      <div class="limit-width">
        <h2>Keeps</h2>
      </div>
    </div>
  </section>

  <KeepsContainer/>
</template>
  
<script>
import { computed, onMounted, onUnmounted } from 'vue'
import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import Pop from '../utils/Pop'
import { profileService } from '../services/ProfileService'
import { useRoute } from 'vue-router'
  export default {
    setup() {

      const route = useRoute().params.id

      async function getProfile(){
        try {
          await profileService.getProfile(route)
        } catch (error) {
          logger.log(error, "getProfileKeeps()")
          Pop.error(error)
        }
      }
      
      async function getProfileVaults(){
        try {
          await profileService.getProfileVaults(route)
        } catch (error) {
          logger.log(error, "getProfileVaults()")
          Pop.error(error)
        }
      }

      async function getProfileKeeps(){
        try {
          await profileService.getProfileKeeps(route)
        } catch (error) {
          logger.log(error, "getProfileKeeps()")
          Pop.error(error)
        }
      }

      onMounted(()=>{
        getProfileKeeps()
        getProfileVaults()
        getProfile()
      })
      onUnmounted(()=>{
        AppState.keeps = []
      })
      return {
        profile: computed(()=>AppState?.profile),
        vaults: computed(()=>AppState?.vaults),
        keeps: computed(()=> AppState?.keeps)
      }
    }
  }
</script>

<style scoped>

</style>