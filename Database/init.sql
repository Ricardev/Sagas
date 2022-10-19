create schema "OrderSchema";

create table "OrderSchema"."Order" (
    "OrderId" serial not null primary key,
    "Quantity" integer not null,
    "UserId" int not null,
    "ProductId" int not null
);


create schema "ProductSchema";

create table "ProductSchema"."Product" (
    "ProductId" serial not null primary key,
    "StockQuantity" integer not null,
    "Value" integer not null,
    "Name" varchar(20)
);

create schema "PaymentSchema";

create table "PaymentSchema"."Payment"(
    "PaymentId" serial not null primary key,
    "PaymentValue" integer not null,
    "OrderId" integer not null,
    "ProductId" integer not null
);

alter table "OrderSchema"."Order" 
    add constraint FK_Order_Product_ProductId 
        foreign key ("ProductId") 
            references "ProductSchema"."Product" ("ProductId");


alter table "PaymentSchema"."Payment" 
    add constraint FK_Payment_Order_OrderId 
        foreign key ("OrderId") 
            references "OrderSchema"."Order" ("OrderId");

alter table "PaymentSchema"."Payment" 
    add constraint FK_Payment_Product_ProductId 
        foreign key ("ProductId") 
            references "ProductSchema"."Product" ("ProductId");

insert into "ProductSchema"."Product" ("Name", "Value", "StockQuantity") 
values 
    ('Samsung Galaxy', 3000, 8),
    ('Nokia', 2000, 4),
    ('Colchão', 4000, 5 ),
    ('Aspirador de pó', 600, 2),
    ('Air Fryer', 250, 1),
    ('Kindle', 400, 2);




