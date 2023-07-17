<template>
  <section class="row">
    <div class="about text-center">
      <h1>Welcome {{ account.name }}</h1>
      <img class="rounded" :src="account.picture" alt="" />
      <p>{{ account.email }}</p>
    </div>
  </section>
  <section class="row">
    <h2 class="col-12">Vaults</h2>
    <div v-for="v in vaults" :key="v.id" class="col-3">
      <VaultCard :vault="v"/>
    </div>
  </section>
  <section class="row">
    <h2 class="col-12">Keeps</h2>

    <div class="col-3" v-for="k in keeps" :key="k">
      <KeepCard :keep="k"/>
    </div>
  </section>
</template>

<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState';
import Pop from '../utils/Pop';
import { logger } from '../utils/Logger';
import { accountService } from '../services/AccountService';
export default {
  setup() {
    async function getVaultsByAccountId(){
      try {
        await accountService.getVaultsByAccountId()
      } catch (error) {
        logger.log(error, "getAccountVaults()")
        Pop.error(error)
      }
    }

    async function getKeepsByAccountId(){
      try {
        await accountService.getKeepsByAccountId()
      } catch (error) {
        logger.log(error,"getKeepsByAccountId()")
        Pop.error(error)
      }
    }

    onMounted(()=>{
      getVaultsByAccountId()
      getKeepsByAccountId()
    })
    return {
      account: computed(() => AppState.account),
      vaults: computed(() => AppState.vaults),
      keeps: computed(() => AppState.keeps)
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
