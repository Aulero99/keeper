<template>

        <div class="link fill-y d-flex flex-row" v-if="user.isAuthenticated">
          
          <button @click="logout()">
            Logout
          </button>
          <router-link :to="{ name: 'Account' }" class="fill p-2">
            <img :src="account.picture" :alt="account.name" class="user-img">
          </router-link>

        </div>
        <div class="link fill-y" v-else type="button" @click="login()">
          <a>
            Login
          </a>
        </div>
    
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
import { AuthService } from '../services/AuthService'
export default {
  setup() {
    return {
      user: computed(() => AppState.user),
      account: computed(() => AppState.account),
      async login() {
        AuthService.loginWithPopup()
      },
      async logout() {
        AuthService.logout({ returnTo: window.location.origin })
      }
    }
  }
}
</script>

<style lang="scss" scoped>
.user-img{
  height: 100%;
  aspect-ratio: 1/1;
  object-fit: cover;
  border-radius: 50%;
}
</style>
