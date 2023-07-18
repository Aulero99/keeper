<template>
  <router-link class="txt-cs-6" :to="{ name: 'Vault', params: { id: vault.id } }" :title="vault.name">
    <div class="vault-card-container">
      
      <div class="vault-card fill elevation-3">
        <div class="img-container fill">
          <img :src="vault.img" :alt="vault.name" :title="vault.name">
        </div>

        <div class="info-container">
          <div class="info">
            <div class="title">
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

<style scoped>
.vault-card-container{
  width: 15rem;
  height: 10rem;
  transition: all 100ms ease-in-out;
  margin-bottom: 1rem;
}
.vault-card-container:hover{
  height: 11rem;
  margin-bottom: 0;
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
  position: absolute;
  z-index: 1;
  height: 100%;
  width: 100%;
  top:0;
  display: flex;
  flex-direction: column;
  justify-content: flex-end;
  padding: 0.5rem;
  background: rgb(0,0,0);
  background: linear-gradient(0deg, rgba(0,0,0,0.65) 0%, rgba(0,0,0,0.25) 50%, rgba(0,0,0,0) 100%);
}
.info{
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  color: var(--cs-1);
}
.title{
  flex-grow: 1;
  height: auto;
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
}
</style>