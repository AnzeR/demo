-- DROP 
drop table invoice_line;
drop table invoice;
drop table client;
drop table article;


/* Create tables  */

create table client (
    id int IDENTITY(1,1) primary key,
    tax_number nvarchar(100),
    name nvarchar(100),
    adddress nvarchar(100),
    country char(2)
);

create unique index ix_client on client (tax_number, country);

create table article (
    id int IDENTITY(1,1) primary key,
    code varchar(10),
    name nvarchar(100),
    price decimal(10, 2)
);

create unique index ix_article on article (code);

create table invoice (
    id int IDENTITY(1,1) primary key,
    furs_number varchar(10),
    issue_date DATETIME,
    id_client int
);

alter table invoice add foreign key (id_client) references client (id);

create table invoice_line (
    id int IDENTITY(1,1) primary key,
    id_invoice int,
    id_article int,
    amount int
);

alter table invoice_line add foreign key (id_invoice) references invoice (id);
alter table invoice_line add foreign key (id_article) references article (id);

