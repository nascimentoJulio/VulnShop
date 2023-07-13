import axios from "axios"

export const useAxios = (baseUrl: string)  => {
    return axios.create({ baseURL: baseUrl })
}