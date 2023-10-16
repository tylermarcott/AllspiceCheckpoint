<template>
  <header class="container-fluid">
    <div>ingredients, pizza, bopa chons</div>
  </header>
</template>

<script>
export default {
  setup() {

    
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

  .home-card {
    width: 50vw;

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }

  .background-img{
  background-image: url('https://images.unsplash.com/photo-1471253794676-0f039a6aae9d?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2940&q=80');
  background-position: bottom;
  background-size: cover;
  min-height: 70vh;
}
}
</style>
