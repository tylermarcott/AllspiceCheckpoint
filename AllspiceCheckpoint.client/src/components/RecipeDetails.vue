<template>
  {{ recipe }}
</template>

<script>
import { Recipe } from "../models/Recipe.js";

export default {
  props: { recipe: { type: Object || Recipe, required: true } },
setup() {
  return {};
},
};
</script>


<style>
</style>