import { useState } from "react";
import { Header } from "../../../components";
import { login } from "../../../api/auth-api";

export default function Login(){
    const [username, setUsername] = useState<string>("")
    const [password, setPassword] = useState<string>("")
    const SendLogin = async (e: any) =>{
        e.preventDefault()
        login(username, password)
    }
    return(
        <div>
            <Header/>
            <form action="">
                <input type="text" placeholder="username" value={username}  onChange={(e) => setUsername(e.target.value)}/>
                <input type="password" placeholder="senha" value={password} onChange={(e) => setPassword(e.target.value)}/>
                <button onClick={(e) => SendLogin(e)}>logar</button>
            </form>
        </div>
    )
}