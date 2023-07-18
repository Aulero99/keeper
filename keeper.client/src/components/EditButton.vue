<template>
    <div class="edit-button elevation-3" type="button">
        <i class="mdi mdi-pencil-outline"></i>
    </div>
</template>
  
<script>
  export default {
    props:{

    },
    setup() {
      return {
  
      }
    }
  }
</script>

<style scoped>
.edit-button{
    background-color: var(--cs-1);
    width: 2rem;
    height: 1.5rem;
    border-radius: 0.5rem;
    display: flex;
    justify-content: center;
    align-items: center;
    cursor: pointer;
    transition: all ease-in-out 100ms;
}
.edit-button:hover{
    background-color: var(--cs-6);
    color: var(--cs-1);
}
</style>