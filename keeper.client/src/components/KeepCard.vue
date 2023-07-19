<template>
  <div class="keep-card-container">
    <div class="keep-card fill elevation-3" 
    type="button"
    @click="openModal(keep.id)">
      
      <div class="img-container fill">
        <img :src="keep.img" :alt="keep.name">
      </div>
  
      <div class="info-container">
        <div class="info">
          <div class="title">
            {{ keep.name }}
          </div>
          <div class="creator">
            <img :src="keep.creator.picture" :alt="keep.creator.name" :title="keep.creator.name" class="profile-img">
          </div>
        </div>
      </div>

    </div>
    
    <DeleteButton class="delete" title="Delete Keep" 
    v-if="keep.creator.id == account.id" 
    @click="deleteKeep(keep.id)"/>
  </div>
</template>
  
<script>
import { Modal } from 'bootstrap'
import { Keep, VaultedKeep } from '../models/Keep'
import { logger } from '../utils/Logger'
import { keepsService } from '../services/KeepsService'
import Pop from '../utils/Pop'
import { computed } from 'vue'
import { AppState } from '../AppState'
  export default {
    props:{
        keep: { type: Keep || VaultedKeep, required: true }
    },
    setup() {
        // const myModalEl = document.getElementById('exampleModal')
        // myModalEl.addEventListener('show.bs.modal', event => {
        // logger.log('modal launched')
        // })
      return {
        account: computed(()=> AppState.account),
        async openModal(id){
            logger.log('Opening modal for id', id)
            await keepsService.getKeepById(id)
            Modal.getOrCreateInstance('#keepModal').show()
        },

        async deleteKeep(id){
          try {
            if(await Pop.confirm("Do you want to delete this keep?")){
              await keepsService.deleteKeep(id)
              Pop.success("Deleted Keep")
            }
          } catch (error) {
            Pop.error(error)
            logger.log(error, 'removeKeepFromVault()')
          }
        }
      }
    }
  }
</script>

<style scoped>
.keep-card-container{
  max-height: 450px;
  width: 100%;
  position: relative;
}
.keep-card{
  background-color: var(--cs-1);
  position: relative;
  overflow: hidden;
  border-radius: 0.5rem;
  cursor: pointer;
}
.img-container img{
  width: 100%;
  object-fit: cover;
}
.keep-card:hover .info-container{
  padding: 0.5rem 0.5rem 0.75rem 0.5rem;
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
  transition: all ease-in-out 100ms;
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
    justify-content: flex-start;
    align-items: center;
}
.creator{
}
.profile-img{
    height: 30px;
    aspect-ratio: 1/1;
    object-fit: cover;
    border-radius: 50%;
}

.delete{
  z-index: 10;
  position: absolute;
  top: 0.25rem;
  right: 0.5rem;
}
</style>