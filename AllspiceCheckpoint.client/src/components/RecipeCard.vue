<template>
  <div class="recipe-card col-4">
    <img class="recipe-img" src="https://i.redd.it/ygkncmia5wc31.jpg" alt="bopa-chon">
    <p>ingredients, pizza, bopa chons</p>
  </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import {recipesService} from '../services/RecipesService.js'
import Pop from "../utils/Pop.js";
export default {
  setup(){
    onMounted(()=> getRecipes());
    async function getRecipes(){
      try {
        await recipesService.getRecipes();
      } catch (error) {
        Pop.error(error)
      }
    }
  return {  }
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