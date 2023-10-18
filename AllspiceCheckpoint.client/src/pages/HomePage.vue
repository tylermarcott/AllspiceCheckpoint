<template>
  <main class="container-fluid bg-dark">
    <div class="row">
      <div class="col-4 d-flex align-items-center justify-content-center" v-for="recipe in recipes" :key="recipe.id">
        <!-- <RecipeCard :recipe="recipe"/> -->
          <ModalWrapper id="show-recipe-details" v-if="user.isAuthenticated">
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
import { logger } from "../utils/Logger.js";

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
  }
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

</style>
