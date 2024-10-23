<template>
  <div id="login" class="login-container">
    <span class="background-img"></span>
    <form @submit.prevent="login" class="login-form">
      <h1 class="login-title">Please Sign In</h1>
      <div role="alert" v-if="invalidCredentials" class="alert alert-danger">
        Invalid username and password!
      </div>
      <div
        role="alert"
        v-if="this.$route.query.registration"
        class="alert alert-success"
      >
        Thank you for registering, please sign in.
      </div>
      <div class="form-input-group">
        <label for="username">Username</label>
        <input
          type="text"
          id="username"
          v-model="user.username"
          required
          autofocus
          class="form-control"
        />
      </div>
      <div class="form-input-group">
        <label for="password">Password</label>
        <input
          type="password"
          id="password"
          v-model="user.password"
          required
          class="form-control"
        />
      </div>
      <button @click="login" type="submit" class="btn btn-primary">
        Sign In
      </button>

      <p class="register-link">
        <router-link :to="{ name: 'register' }"
          >Need an account? Sign up.</router-link
        >
      </p>
    </form>
  </div>

</template>

<script>
// import { RouterLink } from 'vue-router';
import authService from '../services/AuthService';


export default {
  data() {
    return {
      user: {
        username: '',
        password: '',
      },
      invalidCredentials: false,
    };
  },
  methods: {
    login() {
      authService
        .login(this.user)
        .then((response) => {
          if (response.status === 200) {
            this.$store.commit('SET_AUTH_TOKEN', response.data.token);
            this.$store.commit('SET_USER', response.data.user);
            this.$router.push('/home');
          }
        })
        .catch((error) => {
          if (error.response && error.response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    },

  },
  created() {
  },
};
</script>

<style scoped>

.login-container {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  background-color: #f8f9fa;
}

.background-img {
  position: absolute;
  height: 100vh;
  width: 100%;
  z-index: 0;
  background-size: cover;
  background-position: center;
  background-repeat: no-repeat;
  background-image: url('../assets/vecteezy_woman-holding-multi-coloured-shopping-bags_2037496.jpg');
}
.login-form {
  position: absolute;
  top: 30%;
  font: 1rem 'Open Sans', sans-serif;
  width: 100%;
  max-width: 400px;
  padding: 15px;
  margin: 0 auto;
  border: 1px solid #ddd;
  border-radius: 10px;
  background: rgba(255, 255, 255, 0.5); /* semi-transparent background */
  backdrop-filter: blur(10px); /* blur effect */
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  z-index: 1;
}

.login-title {
  margin-bottom: 1.5rem;
  text-align: center;
}

.form-input-group {
  margin-bottom: 1.5rem;
}

label {
  display: block;
  margin-bottom: 0.5rem;
}

.form-control {
  width: 100%;
  padding: 0.75rem;
  border: 1px solid #ccc;
  border-radius: 5px;
  box-sizing: border-box;
}

.btn {
  width: 100%;
  padding: 0.75rem;
  border: none;
  border-radius: 5px;
  background-color: #007bff;
  color: #fff;
  font-size: 1rem;
  cursor: pointer;
}

.btn:hover {
  background-color: #0056b3;
}

.alert {
  padding: 0.75rem;
  margin-bottom: 1rem;
  border: 1px solid transparent;
  border-radius: 5px;
}

.alert-danger {
  color: #721c24;
  background-color: #f8d7da;
  border-color: #f5c6cb;
}

.alert-success {
  color: #155724;
  background-color: #d4edda;
  border-color: #c3e6cb;
}

.register-link {
  text-align: center;
  margin-top: 1rem;
}

.register-link a {
  color: #007bff;
  text-decoration: none;
}

.register-link a:hover {
  text-decoration: underline;
}
</style>
