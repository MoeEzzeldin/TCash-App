import { createApp } from 'vue'
import Tenmo from './App.vue'
import { createStore } from 'vuex'
import router from './router'
import axios from 'axios'
import './assets/main.css'


/* sets the base url for server API communication with axios */
axios.defaults.baseURL = import.meta.env.VITE_REMOTE_API

/*
 * The authorization header is set for axios when you login but what happens when
 * you come back or the page is refreshed. When that happens you need to check
 * for the token in local storage and if it exists you should set the header
 * so that it will be attached to each request.
 */
let currentToken = localStorage.getItem('token')
let currentUser = JSON.parse(localStorage.getItem('user'))

if (currentToken) {
  // Set token axios requests
  axios.defaults.headers.common['Authorization'] = `Bearer ${currentToken}`
}

// Create the Vuex store passing in the stored credentials
const tenmo = createStore(currentToken, currentUser)

const app = createApp(Tenmo)
app.use(tenmo)
app.use(router)
app.mount('#app')
