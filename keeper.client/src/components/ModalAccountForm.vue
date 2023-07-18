<template>
  <div class="modal-header">
<button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
</div>
<div class="modal-body">
  <form @submit.prevent="editAccount()">
  Account Stuff
  <button type="submit" class="btn btn-dark">Submit</button>
  </form>
</div>
</template>

<script>
import { ref } from 'vue'
import { logger } from '../utils/Logger'
import Pop from '../utils/Pop'
import { accountService } from '../services/AccountService'
export default {

setup() {
  const editable = ref({})
return {
  editable,
  async editAccount(){
      try {
          await accountService.editAccount(editable.value)
      } catch (error) {
          logger.log(error,'editAccount()')
          Pop.error(error)
      }
  }

}
}
}
</script>

<style scoped>

</style>