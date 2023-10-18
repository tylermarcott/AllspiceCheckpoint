<template>
  <div class="container">
    <form @submit="createRecipe">
      <div class="mb-3">
        <label for="title" class="form-label">Title</label>
        <input v-model="recipeData.title" type="title" class="form-control" id="recipeTitle" placeholder="the name of your recipe">
      </div>
      <div class="mb-3">
        <label for="instructions" class="form-label">Recipe Instructions</label>
        <textarea v-model="recipeData.instructions" class="form-control" id="recipeInstructions" rows="3"></textarea>
      </div>
      <div class="mb-3">
    <label for="img" class="form-label">Recipe Image URL</label>
    <input v-model="recipeData.img" type="url" class="form-control" id="recipeImg" placeholder="url">
    </div>
    <div class="mb-3">
      <label for="category" class="form-label">Recipe Category</label>
      <input v-model="recipeData.category" class="form-control" id="recipeCategory" placeholder="appetizer">
    </div>
    <button class="btn btn-dark">Submit</button>
  </form>
</div>  
</template>

<script>
import { ref } from "vue";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";
import { useRouter } from "vue-router";
import { Modal } from "bootstrap";

export default {
setup() {
  const recipeData = ref({})
  // const router = useRouter()
  function resetForm() {
    recipeData.value = { type: '' }
  }
return {
  recipeData,
    async createRecipe(){
      try {
        let newRecipe = await recipesService.createRecipe(recipeData.value)
        Pop.toast('Recipe created!', 'success')
        resetForm()
        Modal.getOrCreateInstance('#create-event').hide()
        // FIXME: once you have details page created, reactivate this.
        // router.push({ name: 'Event Details', params: { eventId: newRecipe.id } })

      } catch (error) {
        Pop.error(error)
      }
    }
  };
},
};
</script>


<style>
</style>