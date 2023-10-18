import { AppState } from "../AppState.js";
import { Ingredient } from "../models/Ingredient.js";
import { Recipe } from "../models/Recipe.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";



class RecipesService{
  async getRecipes(){
    const res = await api.get('api/recipes');
    AppState.recipes = res.data.map(recipe => new Recipe(recipe))
  }

  async getIngredientsByRecipe(recipeId){
    logger.log('getting ingredients for the following recipe:', recipeId)
    const res = await api.get(`api/recipes/${recipeId}/ingredients`)
    AppState.activeIngredients = res.data.map(i => new Ingredient(i))
  }

  setActiveRecipe(recipeId){
    const foundRecipe = AppState.recipes.find(r => r.id == recipeId)

    AppState.activeRecipe = foundRecipe;
  }

  async createRecipe(formData){

    logger.log('here is our form data we want to make a recipe with:', formData)

    const res = await api.post('api/recipes', formData)
    const newRecipe = new Recipe(res.data)
    AppState.recipes.unshift(newRecipe)
    logger.log('new recipe created with the following data!: ', res.data)
    return newRecipe
  }
}

export const recipesService = new RecipesService;