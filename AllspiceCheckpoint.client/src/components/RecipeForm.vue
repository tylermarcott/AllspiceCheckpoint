<template>
  <div class="mb-3">
    <label for="recipeTitle" class="form-label">Title</label>
    <input type="title" class="form-control" id="recipeTitle" placeholder="the name of your recipe">
  </div>
  <div class="mb-3">
    <label for="recipeInstructions" class="form-label">Recipe Instructions</label>
    <textarea class="form-control" id="recipeInstructions" rows="3"></textarea>
  </div>
    <div class="mb-3">
      <label for="recipeImg" class="form-label">Recipe Image URL</label>
      <input type="url" class="form-control" id="recipeImg" placeholder="url">
    </div>
    <div class="mb-3">
      <label for="recipeCategory" class="form-label">Recipe Category</label>
      <input class="form-control" id="recipeCategory" placeholder="appetizer">
    </div>
</template>

<script>
export default {
setup() {
  return {};
},
};
</script>


<style>
</style>