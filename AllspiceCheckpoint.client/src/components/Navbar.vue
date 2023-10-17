<template>

<!-- FIXME: login component dissapeared, fix this -->

<section class="background-img text-light">
  <div class="row text-end"> 
    <div>
      <Login />
    </div>  
  </div>
  
  <div class="row">
    <div class="col-12">
      <h1>AllSpice</h1>
    </div>
    <div class="col-12">
      <h3>Where we bring our favorite ingredients to you</h3>
    </div>
  </div>
</section>
</template>

<script>
import Login from './Login.vue';
export default {
  setup() {
    return {}
  },
  components: { Login }
}
</script>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

.background-img{
  background-image: url('https://images.unsplash.com/photo-1471253794676-0f039a6aae9d?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2940&q=80');
  background-position: bottom;
  background-size: cover;
  min-height: 70vh;
}

@media screen and (min-width: 768px) {
  nav {
    height: 64px;
  }
}
</style>
