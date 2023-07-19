<template>
        <div class="account-menu" v-if="user.isAuthenticated">
          <div class="fill-y d-flex flex-row" >
            
            <div class="fill-y p-2">
              <img :src="account.picture" :alt="account.name" class="user-img elevation-2">
            </div>

            <div class="options elevation-3">
              <router-link :to="{ name: 'Account' }" class="fill" aria-label="Link to Account Page">
              <div class="drop-link">
                  Account Page
                </div>
              </router-link>
              <div
              class="drop-link" 
              type="button" 
              @click="logout()" 
              title="logout"
              aria-label="Logout From Account">
                Logout
              </div>
            </div>
          </div>
        </div>

        <div class="link fill-y" v-else>
          <div class="button" type="button" @click="login()" aria-label="Login to Account">
            Login
          </div>
        </div>
    
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
import { AuthService } from '../services/AuthService'
export default {
  setup() {
    return {
      user: computed(() => AppState?.user),
      account: computed(() => AppState?.account),
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
  cursor: pointer;
}
.button{
  padding: 0.25rem 0.5rem;
  border-radius: 0.5rem;
  color: var(--cs-6);
  font-weight: 500;
  transition: all 100ms ease-in-out;
}
.button:hover {
  text-decoration: none;
  background-color: var(--cs-4);
}
.link{
  color: var(--cs-6);
  display: flex;
  justify-content: center;
  flex-direction: column;
  align-items: center;
  margin-right: 0.5rem;
}
.account-menu{
  position: relative;
  display: inline-block;
}
.options{
  // display: none;
  overflow: hidden;
  max-height: 0;
  opacity: 0%;
  position: absolute;
  right: 0;
  top: var(--nav-h);
  background-color: #f9f9f9;
  min-width: 160px;
  z-index: 1000;
  transition: opacity ease-in-out 100ms;
}
.drop-link {
  color: black;
  padding: 12px 16px;
  text-decoration: none;
  display: block;
  transition: all 100ms ease-in-out;
}
.drop-link:hover {
    background-color: #f1f1f1
}
.account-menu:hover .options {
  display: block;
  max-height: 8rem;
  opacity: 100%;
}
/* Change the background color of the dropdown button when the dropdown content is shown */

@media screen and (max-width: 576px) { 
    .options{
        top: auto;
        bottom: var(--nav-h);
    }
}
</style>
