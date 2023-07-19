<template>
    <div class="dropdown">
        <div class="button-container">
            <div class="dropbtn" type="button" title="Create Dropdown">
                Create
            </div>
        </div>
        <div class="dropdown-content elevation-3">
            <div type="button" class="drop-link" @click="newKeep()" aria-label="Create New Keep">
                New Keep
            </div>
            <div type="button" class="drop-link" @click="newVault()" aria-label="Create New Vault">
                New Vault
            </div>
        </div>
    </div>
</template>
  
<script>
import { Modal } from 'bootstrap'
import { logger } from '../utils/Logger'
  export default {
    props:{

    },
    setup() {
      return {
        newKeep(){
            logger.log('newKeep()')
            Modal.getOrCreateInstance('#editKeepModal').show()
        },
        newVault(){
            logger.log('newVault()')
            Modal.getOrCreateInstance('#editVaultModal').show()
        }
      }
    }
  }
</script>

<style lang="scss" scoped>
a{
    cursor: pointer;
}
/* The container <div> - needed to position the dropdown content */
.dropdown {
  position: relative;
  display: inline-block;
}
.button-container{
    height: 100%;
    display: flex;
    justify-content: center;
    flex-direction: column;
}
/* Style The Dropdown Button */
.dropbtn {
    padding: 0.25rem 0.5rem;
    border-radius: 0.5rem;
    color: var(--cs-6);
    font-weight: 500;
    cursor: pointer;
    transition: all 100ms ease-in-out;
}

/* Dropdown Content (Hidden by Default) */
.dropdown-content {
  overflow: hidden;
  max-height: 0;
  opacity: 0%;
  position: absolute;
  left: 0;
  top: var(--nav-h);
  background-color: #f9f9f9;
  min-width: 160px;
  z-index: 1000;
  transition: opacity ease-in-out 100ms;
}

/* Links inside the dropdown */
.dropdown-content .drop-link {
  color: black;
  padding: 12px 16px;
  text-decoration: none;
  display: block;
  transition: all 100ms ease-in-out;
}

/* Change color of dropdown links on hover */
.dropdown-content .drop-link:hover {
    background-color: #f1f1f1
}

/* Show the dropdown menu on hover */
.dropdown:hover .dropdown-content {
  display: block;
  max-height: 8rem;
  opacity: 100%;
}

/* Change the background color of the dropdown button when the dropdown content is shown */
.dropdown:hover .dropbtn {
  background-color: var(--cs-4);
}

@media screen and (max-width: 576px) { 
    .dropdown-content{
        top: auto;
        bottom: var(--nav-h);
        left: -40px;
    }
}
</style>