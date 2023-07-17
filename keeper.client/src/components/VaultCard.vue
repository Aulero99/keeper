<template>
    <div class="card overflow-hidden">
        <img :src="vault.img" :alt="vault.name">
        {{ vault.name }}
    </div>
</template>
  
<script>
import { Vault } from '../models/Vault'

  export default {
    props:{
        vault: {type: Vault, required: true}
    },
    setup() {
      return {
  
      }
    }
  }
</script>

<style scoped>

</style>