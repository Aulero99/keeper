<template>
  <section class="row mt-4">
    <div class="col-12 text-center">
      {{keeps.length}} Keeps
    </div>
  </section>
  <KeepsContainer class="mt-4"/>
</template>
  
<script>
import { computed, onMounted, onUnmounted } from 'vue'
import { useRoute } from 'vue-router'
import { logger } from '../utils/Logger'
import Pop from '../utils/Pop'
import { vaultsService } from '../services/VaultsService'
import { AppState } from '../AppState'

  export default {
    setup() {
      const route = useRoute().params.id

      async function getKeepsInVault(){
        try {
          await vaultsService.getKeepsInVault(route)
        } catch (error) {
          logger.log(error, 'getKeepsInVault()')
          Pop.error(error)
        }
      }

      async function getActiveVault(){
        try {
          await vaultsService.getActiveVault(route)
          getKeepsInVault()
        } catch (error) {
          logger.log(error, 'getActiveVault()')
          Pop.error(error)
        }
      }

      onMounted(()=>{
        getActiveVault()
      })

      onUnmounted(()=>{
        AppState.keeps = []
      })

      return {
        keeps: computed(()=>AppState.keeps)
      }
    }
  }
</script>

<style scoped>

</style>