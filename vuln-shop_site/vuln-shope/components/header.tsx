
export const Header = () =>
(
    <div className="flex bg-black h-16 justify-around items-center">
        <p className="text-white">WSS</p>
        <input type="text" className="h-8 rounded-md w-96" />
        <div>
            <button className="text-white pr-1">login</button>
            <button className="text-white pl-1">cart</button>
        </div>
    </div>
)
