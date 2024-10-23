<template>
<div>
  <h1>Users</h1>
  <button @click="differetUsers" class="btn btn-primary">Get Different Users</button>
  <div v-if="data" class="alert alert-success">
    Thank you for registering, please sign in.
  </div>
  <div class="form-input-group">
    <label for="username">Username</label>
    <input type="text" id="username" v-model="user.username" required autofocus class="form-control">
</div>
<div class="form-input-group">
  <label for="password">Password</label>
  <input type="password" id="password" v-model="user.password" required class="form-control">
</div>
<button @click="login" type="submit" class="btn btn-primary">Sign In</button>
  </div>
</template>

<script>
import AuthService from './services/AuthService';


export default {

  data() {
    return {
      user: {
        username: 'moeezz',
        password: 'password',
      },
      data: null,
      invalidCredentials: false,

    };
  },
  methods: {
   differetUsers() {
      AuthService.getDifferentUsers()
        .then((response) => {
          this.data = response.data;
          console.log(response.data);
        })
        .catch((error) => {
          console.log(error);
        });
    },
    login() {
      AuthService.login(this.user)
        .then((response) => {
          if (response.status === 200) {
            console.log(response);
            this.$router.push({ name: 'home' });
          }
        })
        .catch(() => {
          this.invalidCredentials = true;
        });
    },

  },
  mounted() {
  },
};
</script>
