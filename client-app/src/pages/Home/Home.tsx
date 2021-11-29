import React from 'react'
import { Link } from 'react-router-dom'

const Home = () => {
  return (
    <div>
      <p>Welcome! What would you like to do?</p>
      <Link to="/recipes">View All Recipes</Link>
      <Link to="/find-recipes">Find Recipes</Link>
      <Link to="/add-recipe">Add New Recipes</Link>
    </div>
  )
}

export default Home
