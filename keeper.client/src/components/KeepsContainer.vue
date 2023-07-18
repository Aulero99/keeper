<template>
  <section class="row display-flex flex-row justify-content-center overflow-hidden" v-if="keeps.length > 1">
    <div class="keeps-container">
      <div v-for="k in keeps" :key="k.id" class="keep-slot">
        <KeepCard :keep="k"/>
      </div>
    </div>
  </section>
</template>
  
<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
  export default {
    props:{

    },
    setup() {
      return {
        keeps: computed(() => AppState.keeps)
      }
    }
  }
</script>

<style scoped>
.keeps-container{
  margin: 1rem 0;
  width: 100%;
  max-width: 1200px;
  columns: 6 150px;
  column-gap: 1rem;
}
.keep-slot{
  width: 100%;
  min-width: 100px;
  margin: 0 1rem 1rem 0;
  display: inline-block;
}
</style>