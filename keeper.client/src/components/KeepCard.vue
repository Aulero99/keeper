<template>
  <div class="card overflow-hidden">
    <img :src="keep.img" :alt="keep.name">
    {{ keep.name }}
    <img :src="keep.creator.picture" :alt="keep.creator.name">
    <button class="btn btn-dark" data-bs-toggle="modal" data-bs-target="#keepModal" @click="openModal(keep.id)">Open Modal</button>
  </div>
</template>
  
<script>
// import bootstrap from 'bootstrap'
// import { bootstrap } from '../../node_modules/bootstrap'
import { AppState } from '../AppState'
import { Keep } from '../models/Keep'
import { logger } from '../utils/Logger'
  export default {
    props:{
        keep: { type: Keep, required: true }
    },
    setup() {
        // const myModalEl = document.getElementById('exampleModal')
        // myModalEl.addEventListener('show.bs.modal', event => {
        // logger.log('modal launched')
        // })
      return {
        openModal(id){
            // TODO fix modal bug where bootstrap will not import for js launch
            logger.log('Opening modal for id', id)
            AppState.activeKeep = AppState.keeps.find(k=>k.id = id)
            logger.log(AppState.activeKeep)
        }
      }
    }
  }
</script>

<style scoped>

</style>