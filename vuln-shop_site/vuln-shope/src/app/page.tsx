"use client";
import { useEffect, useState } from "react"
import { Header, ProductListItem } from "../../components"
import { getProducts } from "../../api/store-api"


export default function Home() {
  const [products, setProducts] = useState<Product[]>([])
  const getProduct = async () => {
    const result = await getProducts()
    setProducts(result)
  }
  useEffect(() => {getProduct()},[])
  return (
    <div>
      <Header />
      <h1>Todos os produtos</h1>
      {
        products.map(product =>
        (
          <ProductListItem
            image={product.image}
            price={product.price}
            title={product.title}
          />
        )
        )
      }
    </div>
  )
}
