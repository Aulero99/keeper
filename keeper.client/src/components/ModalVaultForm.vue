<template>
  <div class="modal-header">
<button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
</div>
<div class="modal-body">
  <form @submit.prevent="newVault()" class="d-flex flex-column">

    <div class="form-group mb-3">
      <label for="name">Vault Name</label>
      <input type="text" required v-model="editable.name" class="form-control" name="name">
    </div>

    <div class="form-group mb-3">
      <label for="description">Vault Description</label>
      <input type="text" required v-model="editable.description" class="form-control" name="description">
    </div>

    <div class="form-group mb-3">
      <label for="img">Vault Image</label>
      <input type="text" required v-model="editable.img" class="form-control" name="img">
    </div>

    <div class="form-check mb-3">
      <input type="checkbox" class="form-check-input" name="isPrivate" v-model="editable.isPrivate">
      <label class="form-check-label" for="isPrivate">Private</label>
    </div>
    
    <button type="submit" class="btn btn-dark">Submit</button>
  </form>
</div>
</template>

<script>
import { ref } from 'vue'
import { logger } from '../utils/Logger'
import Pop from '../utils/Pop'
import { vaultsService } from '../services/VaultsService'
import { Modal } from 'bootstrap'
export default {

setup() {
  const editable = ref({isPrivate:false})
return {
  editable,
  async newVault(){
      try {
          await vaultsService.postNewVault(editable.value)
          Pop.success
          Modal.getOrCreateInstance('#editVaultModal').hide()
      } catch (error) {
          logger.log(error,'newKeep()')
          Pop.error(error)
      }
  }

}
}
}
</script>

<style scoped>

</style>