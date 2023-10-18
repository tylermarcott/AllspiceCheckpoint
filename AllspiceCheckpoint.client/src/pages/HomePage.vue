<template>
  <main class="container-fluid bg-dark">
    <div class="row nav-bar bg-dark justify-content-center">
      <div class="col-1">
        <button class="btn btn-light">

          <!-- TODO: do if/else ifs at the bottom to filter between all, myRecipes and favorited recipes -->
          <!-- TODO: do @clicks for all of the buttons, and have them set to filterBy = 'whatever here' -->
          Home
        </button>
      </div>
      <div class="col-1">
        <button class="btn btn-light">
          My Recipes
        </button>
      </div>
      <div class="col-1">
        <button @click="getMyRecipes" class="btn btn-light">
          Favorites
        </button>
      </div>
        <div class="col-1">
          <ModalWrapper id="create-event" v-if="user.isAuthenticated">
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

    <div class="row">
      <div class="col-4 d-flex align-items-center justify-content-center" v-for="recipe in recipes" :key="recipe.id">
        <!-- <RecipeCard :recipe="recipe"/> -->
          <ModalWrapper id="show-recipe-details">
            <template #button>
              <RecipeCard :recipe="recipe"/>
            </template>
            <template #body>
              <RecipeDetails :recipe="recipe"/>
            </template>
          </ModalWrapper>
      </div>
    </div>
    
  </main>
</template>

<script>
import { computed, onMounted } from "vue";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";
import { AppState } from "../AppState.js";
import ModalWrapper from '../components/ModalWrapper.vue'
export default {
  setup() {
    onMounted(() => getRecipes());
    async function getRecipes() {
      try {
        await recipesService.getRecipes();
      } catch (error) {
        Pop.error(error)
      }
    }
    
    return {
      recipes: computed(()=> AppState.recipes),
      user: computed(()=> AppState.user),
    }
  },
  components: { ModalWrapper }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;
}

.nav-bar{
  position: relative;
  margin-top: 1em;
}

</style>
