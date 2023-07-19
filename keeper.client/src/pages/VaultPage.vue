<template>
  <section class="row mt-4" v-if="vault">
    <div class="col-12 d-flex flex-row justify-content-center align-items-center">
      <div class="limit-width d-flex flex-row justify-content-center">
        <div class="vault-container d-flex flex-column align-items-center elevation-3">
          <div class="vault-img fill">
            <img :src="vault.img" :alt="vault.name" :title="vault.name">
          </div>
          
          <div class="vault-details">
            <div class="title">
              {{ vault.name }}
            </div>
          </div>
          
          <DeleteButton @click="deleteVault(vault.id)" class="delete-button" title="Delete This Vault"/>
        
        </div>
      </div>
    </div>
    <div class="col-12 text-center mt-3 d-flex flex-row justify-content-center">
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
.vault-container{
  position: relative;
  width: 70%;
  aspect-ratio: 11/7;
  max-height: 20rem;
  overflow: hidden;
  border-radius: 0.5rem;
}
.vault-img img{
  height: 100%;
  width: 100%;
  object-fit: cover;
}
.vault-details{
  position: absolute;
  height: 100%;
  width: 100%;
  z-index: 1;
  display: flex;
  flex-direction: column;
  justify-content: flex-end;
  text-align: center;
  padding: 0.75rem;
  background: rgb(0,0,0);
  background: linear-gradient(0deg, rgba(0,0,0,0.65) 0%, rgba(0,0,0,0.25) 50%, rgba(0,0,0,0) 100%);
  color: var(--cs-1);
  font-size: 1.7rem;
  font-weight: 500;
}
.delete-button{
  position: absolute;
  z-index: 2;
  top: 0.85rem;
  right: 1rem;
}
</style>