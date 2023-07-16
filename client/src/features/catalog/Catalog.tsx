import { useEffect, useState } from "react";
import { Product } from "../../app/models/product";
import ProductList from "./ProductList";

//可以回看复习course 29以理解Typescript的写法

export default function Catalog() {//or use destructure like Catalog({products, addProduct}: Props) {
   
    const[products, setProducts] = useState<Product[]>([]);
    //react hook syntax: products: object name, setProducts: its setter function
  
    useEffect(() => {
      fetch('http://localhost:5164/api/products')
      .then(response => response.json())
      .then(data => setProducts(data))
    }, [])
   
    return (
        <>
            <ProductList products={products}/>
        </>
        
    )
}