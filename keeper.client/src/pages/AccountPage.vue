<template>
  <section class="row mt-4" v-if="account?.id">
    <ProfileCard :profile="account"/>
  </section>
  
  <section class="row">
    <div class="col-12 text-center">
      {{ myVaults.length }} Vaults | {{ keeps.length }} Keeps
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
        <div v-for="v in myVaults" :key="v.id" class="me-3 mb-3">
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
import { computed, onMounted, onUnmounted } from 'vue';
import { AppState } from '../AppState';
import Pop from '../utils/Pop';
import { logger } from '../utils/Logger';
import { accountService } from '../services/AccountService';
export default {
  setup() {
    // async function getVaultsByAccountId(){
    //   try {
    //     await accountService.getVaultsByAccountId()
    //   } catch (error) {
    //     logger.log(error, "getAccountVaults()")
    //     Pop.error(error)
    //   }
    // }

    async function getKeepsByAccountId(){
      try {
        await accountService.getKeepsByAccountId()
      } catch (error) {
        logger.log(error,"getKeepsByAccountId()")
        Pop.error(error)
      }
    }

    onMounted(()=>{
      // getVaultsByAccountId()
      getKeepsByAccountId()
    })
    onUnmounted(()=>{
        AppState.keeps = []
      })
    return {
      account: computed(() => AppState?.account),
      myVaults: computed(() => AppState?.myVaults),
      keeps: computed(() => AppState?.keeps)
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
