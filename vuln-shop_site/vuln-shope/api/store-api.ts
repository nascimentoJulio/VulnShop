import { useAxios } from "../hooks/axios-hook";
const instance = useAxios('https://localhost:7231')

export const getProducts = async () => {
    const res = await instance.get<Product>('/api/Products?Limit=10&Page=1')
    return res.data
}