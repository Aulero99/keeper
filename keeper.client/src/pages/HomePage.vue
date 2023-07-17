<template>
  <section class="row">
    <div v-for="k in keeps" :key="k.id" class="col-3">
      <KeepCard :keep="k"/>
    </div>
  </section>
</template>

<script>
import { computed, onMounted } from 'vue'
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
