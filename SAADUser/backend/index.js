import express from "express"
import mysql, { createConnection } from "mysql"
import cors from "cors"


const app = express()
app.use(cors())

const db = mysql.createConnection({
    host: "localhost",
    user: "root",
    password: "root123",
    database: "saad"
  });

  app.get("/", (req,res)=>{
    res.json("Hello this is the backend")
  })

  app.get("/users", (req,res)=>{
    const q = "SELECT * FROM users"
    db.query(q,(err,data)=>{
        if(err) return res.json("Error message!")
            return res.json(data)
    })

  })

  app.get("/media", (req,res)=>{
    const q = "SELECT * FROM media"
    db.query(q,(err,data)=>{
        if(err) return res.json("Error message!")
            return res.json(data)
    })

  })

  app.get("/mediaInsert", (req,res)=>{
    const q = "INSERT INTO media (name, type, description, stock) VALUES('test1', 'test1', 'test1', '201')";

    db.query(q,(err,data)=>{
      if(err) return res.json(err)
        return res.json("Book has been created successfully")
    })

  })

  app.get("/getData", (req,res)=>{
    res.send("Axios connected successfully")
  })


app.listen(8800, ()=>{
    console.log("Connected to backend!")
})