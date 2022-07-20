drop table products;
drop table сategories;

CREATE OR REPLACE TABLE сategories
( id SERIAL NOT NULL,
  name char(20),
  PRIMARY KEY (id)
);

CREATE TABLE products
( id SERIAL NOT NULL,
  name char(20),
  сategories_id int REFERENCES сategories(Id),
  PRIMARY KEY (id)
);

INSERT INTO сategories (name) VALUES ('еда');
INSERT INTO сategories (name) VALUES ('напитки');
INSERT INTO сategories (name) VALUES ('одежда');
INSERT INTO сategories (name) VALUES ('бытовое');
INSERT INTO сategories (name) VALUES ('пресса');
INSERT INTO сategories (name) VALUES ('игрушки');

INSERT INTO сategories (name) VALUES ('полуфабрикат');
INSERT INTO сategories (name) VALUES ('выпечка');

INSERT INTO сategories (name) VALUES ('газированные');
INSERT INTO сategories (name) VALUES ('минеральные');
INSERT INTO сategories (name) VALUES ('молочные');

INSERT INTO сategories (name) VALUES ('мужская');
INSERT INTO сategories (name) VALUES ('женская');

INSERT INTO сategories (name) VALUES ('принадлежности');
INSERT INTO сategories (name) VALUES ('химия');

INSERT INTO сategories (name) VALUES ('газеты');
INSERT INTO сategories (name) VALUES ('журналы');

INSERT INTO сategories (name) VALUES ('мягкие');
INSERT INTO сategories (name) VALUES ('надувные');
INSERT INTO сategories (name) VALUES ('обычные');

SELECT * FROM сategories;


INSERT INTO products (name,сategories_id) VALUES ('вода',2);
INSERT INTO products (name,сategories_id) VALUES ('вода',10);

INSERT INTO products (name,сategories_id) VALUES ('пельмени',1);
INSERT INTO products (name,сategories_id) VALUES ('пельмени',7);

INSERT INTO products (name,сategories_id) VALUES ('чулки',3);
INSERT INTO products (name,сategories_id) VALUES ('чулки',13);

INSERT INTO products (name) VALUES ('телефон');

INSERT INTO products (name,сategories_id) VALUES ('подгузники',4);

INSERT INTO products (name,сategories_id) VALUES ('газета правда',5);
INSERT INTO products (name,сategories_id) VALUES ('газета правда',16);

INSERT INTO products (name,сategories_id) VALUES ('журнал огонек',5);
INSERT INTO products (name,сategories_id) VALUES ('журнал огонек',17);

INSERT INTO products (name) VALUES ('шины');

INSERT INTO products (name,сategories_id) VALUES ('боржоми',2);
INSERT INTO products (name,сategories_id) VALUES ('боржоми',9);
INSERT INTO products (name,сategories_id) VALUES ('боржоми',10);

INSERT INTO products (name) VALUES ('наушники');

SELECT * FROM products;




SELECT products.name,сategories.name FROM products left join сategories on products.сategories_id=сategories.id;