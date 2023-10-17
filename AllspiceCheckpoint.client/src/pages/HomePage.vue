<template>
  <header class="container-fluid">
    <div class="row">
      <RecipeCard/>
    </div>
    
  </header>
</template>

<script>
export default {
  setup() {

    // TODO: need to start with getting recipes to the page.
    
    return {}
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
