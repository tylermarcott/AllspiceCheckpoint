<template>
  <div class="recipe-card col-4">
    <img class="recipe-img" :src="recipe.img" :alt="recipe.name">
    <p>{{ recipe.title }}</p>
  </div>
</template>


<script>
import { Recipe } from "../models/Recipe.js";
export default {
  props: {recipe: {type: Object || Recipe, required: true}},
  setup(){
  return { 
    
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
    max-height: 30vh;
    aspect-ratio: 1/1;
    margin-top: 1em;
    background-color: gray;
  }

</style>