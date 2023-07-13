export const ProductListItem = (product : Product) => 
(
    <button className="drop-shadow-lg bg-white p-3 rounded w-48 mr-2 ml-2 mt-2">
        <img src={product.image} alt={product.title} />
        <p title={product.title}>{product.title.length <= 20?  product.title : product.title.substring(0,19).concat("...")}</p>
        <p>{product.price}</p>
    </button>
)