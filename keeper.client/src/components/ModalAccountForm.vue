<template>
  <div class="modal-header">
<button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
</div>
<div class="modal-body">
  <form @submit.prevent="editAccount()" class="d-flex flex-column">

    <div class="form-group mb-3">
        <label for="name">Name</label>
        <input type="text"
        v-model="editable.name" 
        class="form-control" 
        name="name"
        :placeholder="account.name">
    </div>

    <div class="form-group mb-3">
        <label for="picture">Avatar</label>
        <input type="url" 
        v-model="editable.picture" 
        class="form-control" 
        name="picture"
        :placeholder="account.picture">
    </div>

    <div class="form-group mb-3">
        <label for="coverImg">Cover Image</label>
        <input type="text"
        v-model="editable.coverImg" 
        class="form-control" 
        name="coverImg"
        :placeholder="account.coverImg">
    </div>

    <button type="submit" class="btn btn-dark">Submit</button>
  </form>
</div>
</template>

<script>
import { computed, ref } from 'vue'
import { logger } from '../utils/Logger'
import Pop from '../utils/Pop'
import { accountService } from '../services/AccountService'
import { Modal } from 'bootstrap'
import { AppState } from '../AppState'
export default {

setup() {
  const editable = ref({})
return {
  editable,
  account: computed(()=>AppState.account),
  async editAccount(){
      if(!editable.value.name){
        editable.value.name = AppState.account.name
      }
      if(!editable.value.picture){
        editable.value.picture = AppState.account.picture
      }
      if(!editable.value.coverImg){
        editable.value.coverImg = AppState.account.coverImg
      }
      try {
          await accountService.editAccount(editable.value)
          Pop.success
          Modal.getOrCreateInstance('#editAccountModal').hide()
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