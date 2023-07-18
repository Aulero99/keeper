<template>
    <div class="modal-header">
  <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
</div>
<div class="modal-body">
    <form @submit.prevent="newKeep()" class="d-flex flex-column">

        <div class="form-group mb-3">
            <label for="name">Keep Name</label>
            <input type="text" required v-model="editable.name" class="form-control" name="name">
        </div>

        <div class="form-group mb-3">
            <label for="description">Keep Description</label>
            <input type="text" required v-model="editable.description" class="form-control" name="description">
        </div>

        <div class="form-group mb-3">
            <label for="img">Keep img</label>
            <input type="text" required v-model="editable.img" class="form-control" name="img">
        </div>

        <button type="submit" class="btn btn-dark">Submit</button>
    </form>
</div>
</template>

<script>
import { ref } from 'vue'
import { logger } from '../utils/Logger'
import Pop from '../utils/Pop'
import { keepsService } from '../services/KeepsService'
import { Modal } from 'bootstrap'
export default {

setup() {
    const editable = ref({})
return {
    editable,
    async newKeep(){
        try {
            await keepsService.postNewKeep(editable.value)
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