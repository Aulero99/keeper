<template>
  <section class="row mt-4" v-if="vault">
    <div class="col-12 d-flex flex-column justify-content-center align-items-center">
      <VaultCard :vault="vault"/>
      <button @click="deleteVault(vault.id)">Delete Vault</button>
    </div>
    <div class="col-12 text-center mt-2 d-flex flex-row justify-content-center">
      <div class="keep-counter elevation-2">
        {{keeps.length}} Keeps
      </div>
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
import { router } from '../router'

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
          // this.throwAnError()
          await vaultsService.getActiveVault(route)
          getKeepsInVault()
        } catch (error) {
          router.push('/')
          logger.log(error, 'getActiveVault()')
          Pop.error(error)
        }
      }

      onMounted(()=>{
        getActiveVault()
      })

      onUnmounted(()=>{
        AppState.keeps = []
        AppState.activeVault = null
      })

      return {
        keeps: computed(()=> AppState?.keeps ),
        vault: computed(()=> AppState?.activeVault ),
        async deleteVault(id){
          try {
            if(await Pop.confirm('Do you want to delete this vault?')){
              await vaultsService.deleteVault(id)
              router.push('/')
            }
          } catch (error) {
            Pop.error(error)
            logger.error(`deleteVault(${id})`,error)
          }
        }
      }
    }
  }
</script>

<style scoped>
.keep-counter{
  color: var(--cs-6);
  background-color: var(--cs-3);
  width: max-content;
  padding: 0.25rem 0.5rem;
  border-radius: 0.5rem;
  font-weight: 500;
}
</style>