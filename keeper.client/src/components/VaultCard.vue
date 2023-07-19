<template>
  <router-link class="txt-cs-6" :to="{ name: 'Vault', params: { id: vault.id } }" :title="vault.name">
    <div class="vault-card-container">
      
      <div class="vault-card fill elevation-3">
        <div class="img-container fill">
          <img :src="vault.img" :alt="vault.name" :title="vault.name">
        </div>

        <div class="info-container fill d-flex flex-column justify-content-end">
          <div class="info d-flex flex-row justify-content-between">
            <div class="title d-flex flex-row justify-content-between align-items-center">
              {{ vault.name }}
              <div class="locked" v-if="vault.isPrivate">
                <i class="mdi mdi-lock" title="Private Vault"></i>
              </div>
            </div>
          </div>
        </div>

      </div>

    </div>
  </router-link>
      
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

<style lang="scss" scoped>
.vault-card-container{
  width: 15rem;
  height: 10rem;
  transition: all var(--ease);
  margin-bottom: 1rem;
    &:hover{
      height: 11rem;
      margin-bottom: 0;
        .info-container{ padding: 0.5rem 0.5rem 1.6rem 0.5rem; }
    }
}
.vault-card{
  border-radius: 0.5rem;
  overflow: hidden;
  position: relative;
}
.img-container img{
  width: 100%;
  height: 100%;
  object-fit: cover;
}
.info-container{
  transition: all var(--ease);
  position: absolute;
  z-index: 1;
  top:0;
  padding: 0.5rem;
  background: var(--cs-6);
  background: var(--gradient);
}
.info{ color: var(--cs-1); }
.title{
  flex-grow: 1;
  height: auto;
}
</style>