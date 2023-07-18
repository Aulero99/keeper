<template>
  <KeepsContainer class="mt-4"/>
</template>

<script>
import { computed, onMounted, onUnmounted } from 'vue'
import { logger } from '../utils/Logger'
import { keepsService } from '../services/KeepsService'
import Pop from '../utils/Pop'
import { AppState } from '../AppState'
export default {
  setup() {
    async function getKeepsFromApi(){
      try {
        keepsService.getKeepsFromApi();
      } catch (error) {
        Pop.error(error);
        logger.log(error, '[getKeepsFromApi()]');
      }
    }
    onMounted(()=>{
      getKeepsFromApi()
    })
    onUnmounted(()=>{
      AppState.keeps = []
    })
    return {
      keeps: computed(() => AppState.keeps)
    }
  }
}
</script>

<style scoped lang="scss">
// .home {
//   display: grid;
//   height: 80vh;
//   place-content: center;
//   text-align: center;
//   user-select: none;

//   .home-card {
//     width: 50vw;

//     >img {
//       height: 200px;
//       max-width: 200px;
//       width: 100%;
//       object-fit: contain;
//       object-position: center;
//     }
//   }
// }
</style>
