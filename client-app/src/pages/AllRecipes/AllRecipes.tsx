import React, { useEffect, useState } from 'react'
import { httpClient } from '../../services/httpClient'
const AllRecipes = () => {
  const [recipes, setRecipes] = useState([])
  useEffect(() => {
    httpClient.get("/api/recipes").then(res => {
      console.log(res)
      setRecipes(res.data)
    })
  }, [])
  return (
    <div>
      {JSON.stringify(recipes, undefined, 2)}
    </div>
  )
}

export default AllRecipes
