<template>
  <header class="container-fluid">
    <div class="row">
      <div v-for="recipe in recipes" :key="recipe.id">
        <RecipeCard :recipe="recipe"/>
      </div>
    </div>
    
  </header>
</template>

<script>
import { computed, onMounted } from "vue";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";
import { AppState } from "../AppState.js";

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
      recipes: computed(()=> AppState.recipes)
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
