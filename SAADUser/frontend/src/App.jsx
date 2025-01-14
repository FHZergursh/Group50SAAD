import React, { useEffect, useState } from 'react'
import Navbar from './components/Navbar'
import Tablelist from './components/Tablelist'
import axios from 'axios'


function App() {
  const [data,setData]=useState();

  const getData=async()=>{
    const response=await axios.get("http://localhost:8800/getData")
    setData(response.data);
  }

  useEffect(()=>{
    getData()
  },[])


  return (
    <>
      <Navbar></Navbar>
      <Tablelist></Tablelist>>
      <div>{data}</div>
    
    </>
  )
}

export default App