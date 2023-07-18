<template>
    <div class="delete-button elevation-2" type="button">
      <i class="mdi mdi-trash-can"></i>
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
.delete-button{
    background-color: var(--cs-4);
    color: var(--cs-6);
    height: 1.5rem;
    aspect-ratio: 1/1;
    display: flex;
    flex-direction: row;
    justify-content: center;
    align-items: center;
    border-radius: 50%;
    cursor: pointer;
    transition: all ease-in-out 100ms;
}
.delete-button:hover{
    background-color: var(--cs-6);
    color: var(--cs-1);
}
</style>