import { useAxios } from "../hooks/axios-hook";
const instance = useAxios('https://localhost:44305')

export const login = async (username: string, password: string) => {
    const params = new URLSearchParams();
    params.append('client_secret', 'secret');
    params.append('client_Id', 'cwm.client');
    params.append('grant_type', 'password');
    params.append('username', username);
    params.append('password', password);
    params.append('scope', 'myApi.read');
    const res = await instance.post('/connect/token', params);
    localStorage.setItem("TOKEN", res.data.access_token)
}