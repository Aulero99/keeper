<template>
    <div class="dropdown">
        <div class="button-container">
            <div class="dropbtn" type="button" title="Create Dropdown">
                Create
            </div>
        </div>
        <div class="dropdown-content elevation-3">
            <a @click="newKeep()">
                New Keep
            </a>
            <a @click="newVault()">
                New Vault
            </a>
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

<style scoped>
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
}

/* Dropdown Content (Hidden by Default) */
.dropdown-content {
  display: none;
  position: absolute;
  top: var(--nav-h);
  background-color: #f9f9f9;
  min-width: 160px;
  z-index: 1000;
}

/* Links inside the dropdown */
.dropdown-content a {
  color: black;
  padding: 12px 16px;
  text-decoration: none;
  display: block;
}

/* Change color of dropdown links on hover */
.dropdown-content a:hover {
    background-color: #f1f1f1
}

/* Show the dropdown menu on hover */
.dropdown:hover .dropdown-content {
  display: block;
}

/* Change the background color of the dropdown button when the dropdown content is shown */
.dropdown:hover .dropbtn {
  background-color: var(--cs-4);
}

@media screen and (max-width: 576px) { 
    .dropdown-content{
        top: auto;
        bottom: var(--nav-h);
    }
}
</style>