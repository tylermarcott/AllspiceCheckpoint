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
          <div v-for="i in ingredients" :key="i.id">
            {{ i.name }} {{ i.quantity }}
          </div>
        </div>
      </div>
    </div>
  </div>
</div>
</template>

<script>
import { computed } from "vue";
import { Recipe } from "../models/Recipe.js";
import { AppState } from "../AppState.js";


export default {
  props: { recipe: { type: Object || Recipe, required: true } },
setup() {  

  return {
        ingredients: computed(() => AppState.activeIngredients)
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