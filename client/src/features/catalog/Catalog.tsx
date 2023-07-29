import { useEffect, useState } from "react";
import { Product } from "../../app/models/product";
import ProductList from "./ProductList";
import agent from "../../app/api/agent";
import LoadingComponent from "../../app/layout/LoadingComponent";

//可以回看复习course 29以理解Typescript的写法

export default function Catalog() {//or use destructure like Catalog({products, addProduct}: Props) {
   
    const[products, setProducts] = useState<Product[]>([]);
    const[loading, setLoading] = useState(true);
    //react hook syntax: products: object name, setProducts: its setter function
  
    useEffect(() => {
      agent.Catalog.list()
      .then(products => setProducts(products))
      .catch(error => console.log(error))
      .finally(() => setLoading(false))
    }, [])  

    if(loading) return <LoadingComponent message='Loading products...' />

    return (
        <>
            <ProductList products={products}/>
        </>
        
    )
}