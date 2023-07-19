<template>
  <section class="navbar fill elevation-3 d-flex flex-row justify-content-center">
    <div class="limit-width fill d-flex flex-row justify-content-between ">
      
      <div class="d-flex flex-row justify-content-sm-start justify-content-center links fill-y nav-section order-2 order-sm-1">
          <div class="link fill-y d-none d-sm-flex">
            <router-link :to="{ name: 'Home' }" class="d-flex">
              Home
            </router-link>
          </div>
          <CreateDropdown/>      
      </div>
        
      <div class="fill-y nav-section order-1 order-sm-2">
        <router-link class="navbar-brand d-flex flex-row justify-content-start justify-content-sm-center align-items-start fill" :to="{ name: 'Home' }">
          <div class="d-flex flex-column align-items-center fill-y">
            <img alt="logo" src="../assets/img/logo.svg" class="logo fill-y"/>
          </div>
        </router-link>
      </div>
        
      <div class="fill-y nav-section d-flex flex-row justify-content-end order-3">      
        <!-- LOGIN COMPONENT HERE -->
        <Login />
      </div>

    </div>
  </section>
</template>

<script>
import Login from './Login.vue';
export default {
  setup() {
    return {

    }
  },
  components: { Login }
}
</script>

<style scoped>
.navbar{
  background-color: var(--cs-1);
  padding: 0 1rem;
}
.nav-section{
  width: 33%;
}
.logo{
  height: 100%;
}
.links a{
  transition: all 100ms ease-in-out;
}
.links a:hover {
  text-decoration: none;
  background-color: var(--cs-4);
}
.links{
  color: var(--cs-6);
}
.link{
  display: flex;
  justify-content: center;
  flex-direction: column;
  align-items: center;
  margin-right: 0.5rem;
}
.link a{
  padding: 0.25rem 0.5rem;
  border-radius: 0.5rem;
  color: var(--cs-6);
  font-weight: 500;
}
.links .router-link-exact-active {
  background-color: var(--cs-4);
}
</style>
