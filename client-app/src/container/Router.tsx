import React from 'react'
import {
  BrowserRouter,
  Routes,
  Route,
  Link
} from "react-router-dom"
import AddRecipe from '../pages/AddRecipe/AddRecipe'
import AllRecipes from '../pages/AllRecipes/AllRecipes'
import FindRecipes from '../pages/FindRecipes/FindRecipes'
import Home from '../pages/Home/Home'

const Router = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/add-recipe" element={<AddRecipe />} />
        <Route path="/find-recipes" element={<FindRecipes />} />
        <Route path="/recipes" element={<AllRecipes />} />
        <Route path="/" element={<Home />} />
      </Routes>
    </BrowserRouter>
  )
}

export default Router
