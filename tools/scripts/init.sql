create table products(
	id int generated always as identity,
	title varchar(100) not null,
	price money not null,
	description varchar(200) not null,
	category varchar(50) not null,
	image varchar(300) not null
);

INSERT INTO public.products
(title, price, description, category, image)
VALUES('Fjallraven - Foldsack No. 1 Backpack, Fits 15 Laptops', 109.95, 'Your perfect pack for everyday use and walks in the forest. Stash your laptop (up to 15 inches) in the padded sleeve, your everyday', 'men clothing', 'https://fakestoreapi.com/img/81fPKd-2AYL._AC_SL1500_.jpg');
