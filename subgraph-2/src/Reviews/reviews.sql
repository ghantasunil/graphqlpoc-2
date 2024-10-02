-- Create a review table
-- CREATE TABLE IF NOT EXISTS reviews (
--     id INTEGER PRIMARY KEY AUTOINCREMENT,
--     user_id INTEGER NOT NULL,
--     product_id INTEGER NOT NULL,
--     rating INTEGER NOT NULL,
--     review TEXT NOT NULL,
--     created_at TEXT NOT NULL,
--     FOREIGN KEY (product_id) REFERENCES products (id)
-- );

-- insert into reviews (user_id, product_id, rating, review, created_at) values (1, 1, 5, 'Great product', '2021-01-01');
-- insert into reviews (user_id, product_id, rating, review, created_at) values (2, 2, 4, 'Good product', '2021-01-02');
-- insert into reviews (user_id, product_id, rating, review, created_at) values (3, 3, 3, 'Average product', '2021-01-03');
-- insert into reviews (user_id, product_id, rating, review, created_at) values (4, 4, 2, 'Bad product', '2021-01-04');
-- insert into reviews (user_id, product_id, rating, review, created_at) values (5, 5, 1, 'Terrible product', '2021-01-05');


-- Create a product table
-- CREATE TABLE IF NOT EXISTS products (
--     id INTEGER PRIMARY KEY AUTOINCREMENT,
--     name TEXT NOT NULL,
--     price INTEGER NOT NULL,
--     created_at TEXT NOT NULL
-- );

-- insert into products (name, price, created_at) values ('Product 1', 100, '2021-01-01');
-- insert into products (name, price, created_at) values ('Product 2', 200, '2021-01-02');
-- insert into products (name, price, created_at) values ('Product 3', 300, '2021-01-03');
-- insert into products (name, price, created_at) values ('Product 4', 400, '2021-01-04');
-- insert into products (name, price, created_at) values ('Product 5', 500, '2021-01-05');

