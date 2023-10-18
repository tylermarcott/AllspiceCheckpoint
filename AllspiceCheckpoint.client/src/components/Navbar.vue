<template>

<!-- FIXME: login component dissapeared, fix this -->

<section class="background-img text-light">
  <div class="row text-end"> 
    <div class="px-2 mt-1">
      <Login />
    </div>  
  </div>
  
  <div class="row text-center opaque-card">
    <div class="col-12 margin">
      <h1>AllSpice</h1>
    </div>
    <div class="col-12">
      <h3>Where we bring our favorite ingredients to you</h3>
    </div>
  </div>
</section>

  <div class="row nav-bar bg-dark justify-content-center">
    <div class="col-1">
      <button class="btn btn-light">
        Home
      </button>
    </div>
    <div class="col-1">
      <button class="btn btn-light">
        My Recipes
      </button>
    </div>
    <div class="col-1">
      <button class="btn btn-light">
        Favorites
      </button>
    </div>
      <div class="col-1">
        <!-- TODO: put v-if="user.isAuthenticated" here -->
        <ModalWrapper id="create-event">
          <template #button>
            <button class="btn btn-light">
              Create Recipe
            </button>
          </template>
          <template #body>
            <RecipeForm/>
          </template>
        </ModalWrapper>
      </div>
  </div>

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

.nav-bar{
  position: relative;
  margin-top: 1em;
}

.opaque-card{
  background-color: rgba(15, 15, 15, 0.666);
  margin-top: 20vh;
}

@media screen and (min-width: 768px) {
  nav {
    height: 64px;
  }
}
</style>
