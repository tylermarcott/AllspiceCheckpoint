<template>
    <div @click="setActiveRecipe(recipe.id)" class="recipe-card">
      <div class="row">
        <h5>
          {{ recipe.category }}
        </h5>
      </div>
      
      <img class="recipe-img" :src="recipe.img" :alt="recipe.name">
      
      <div class="row mt-2">
        <p>{{ recipe.title }}</p>
      </div>
    </div>
</template>


<script>
import { Recipe } from "../models/Recipe.js";
import { recipesService } from "../services/RecipesService.js";
import { logger } from "../utils/Logger.js";
import Pop from "../utils/Pop.js";
export default {
  props: {recipe: {type: Object || Recipe, required: true}},
  setup(){
  return { 
      setActiveRecipe(recipeId) {
        try {
          recipesService.setActiveRecipe(recipeId);
        } catch (error) {
          Pop.error(error)
        }
      }
    }
  }
};
</script>


<style lang="scss" scoped>

  .recipe-img{
    max-height: 20vh;
  }

  .recipe-card{
    text-align: center;
    height: 35vh;
    aspect-ratio: 1/1;
    margin-top: 1em;
    background-color: rgba(55, 55, 55, 0.676);
    padding: 1em;
    border-radius: 5px;
  }

</style>