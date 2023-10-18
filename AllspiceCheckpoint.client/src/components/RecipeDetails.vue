<template>
  <div class="container">
    <div class="row details-card">
      <div class="col-4">
        <img class="details-img" :src="recipe.img" :alt="recipe.title">
      </div>
      <div class="col-8">
        <div class="row">
          <div class="col-8">
            <div class="row mb-3">
              <div class="col-10">
                <h3>
                  {{ recipe.title }}
                </h3>
              </div>
              <div class="col-2">
                {{ recipe.category }}
              </div>
            </div>
          </div>
        </div>
      <div class="row">
        <div class="col-6">
          <h3>Recipe Steps</h3>
          {{ recipe.instructions }}
        </div>
        <div class="col-6">
          <h3>Ingredients</h3>
          put all of your ingredients here
          {{ recipe.ingredients }}
        </div>
      </div>
    </div>
  </div>
</div>
</template>

<script>
import { onMounted, watchEffect } from "vue";
import { Recipe } from "../models/Recipe.js";
import Pop from "../utils/Pop.js";
import { recipesService } from "../services/RecipesService.js";
import { logger } from "../utils/Logger.js";
import { AppState } from "../AppState.js";

export default {
  props: { recipe: { type: Object || Recipe, required: true } },
setup() {  

  return {

  };
},
};
</script>


<style>
.details-img{
  height: 25vh;
  aspect-ratio: 1/1;
}

.details-card{
  min-height: 50vh;
}
</style>