 
 --Day 1
 drop database BookStoreDB
--create database
create database BookStoreDB1

--crating author table
create table Authors(
AuthorID int identity(1,1) primary key,
Name varchar(20) not null,
Country varchar(20)not null
)



--creating books table
create table Books(
BookID int identity(1,1) primary key,
Title varchar(30) not null,
AuthorID int foreign key (AuthorID) references Authors(AuthorID),
Price decimal Not null,
PublishedYear  date
)
 

alter table Books
drop column PublishedYear

alter table Books
add PublishedYear int
 

--creating customer table
create table Customers(
CustomerID int identity(1,1)primary key,
Name varchar(20) not null,
Email varchar(30) unique ,
PhoneNo varchar(12) unique
)

--creating Orders table
create table Orders(
OrderID int identity(1,1) primary key,
CustomerID int foreign key (CustomerID) references Customers(CustomerID),
OrderDate date,
TotalAmount decimal
)
--creating OrderItems table
create table OrderItems(
OrderItemID int identity(1,1) primary key,
OrderID int foreign key (OrderID) references Orders(OrderID),
BookID int foreign key (BookID) references Books(BookID),
Quantity int,
SubTotal decimal
)

--DML
--Authors
INSERT INTO Authors  
VALUES
('Paulo Coelho', 'Brazil'),
('James Clear', 'USA'),
('Robert C. Martin', 'USA'),
('Andrew Hunt', 'USA'),
('Cal Newport', 'USA');
select * from Authors;

--Books

INSERT INTO Books
VALUES
('The Alchemist', 1, 299.99, 1988),
('Atomic Habits', 2, 499.50, 2018),
('Clean Code', 3, 1999.00, 2024),
('The Pragmatic Programmer', 1, 3799.75, 1999),
('SQL Mastery', 4, 130.25, 2016);
select * from Books

alter table Books
drop column publishedYear

alter table Books
add  PublishedYear int


--Customers
INSERT INTO Customers  
VALUES
('Rohan Sharma', 'rohan@gmail.com', '9876543210'),
('Priya Verma', 'priya@gmail.com', '8765432109'),
('Amit Joshi', 'amit@gmail.com', '7654321098'),
('Sneha Kulkarni', 'sneha@gmail.com', '6543210987'),
('Rahul Mehta', 'rahul@gmail.com', '5432109876');

insert into Customers
values('sayali','sayali235@gmail.com','6789576890')
select * from Customers


insert into Customers
values('vaishnavi','vaish235@gmail.com','6789876890')

insert into Customers
values('aisha','aisha235@gmail.com','6709876890')

--Orders
INSERT INTO Orders 
VALUES
( 1, '2025-03-01', 799.50),
( 2, '2025-03-02', 1298.75),
( 1, '2025-03-03', 999.00),
( 2, '2025-03-04', 299.99),
( 5, '2025-03-05', 1099.50);
select * from Orders

--OrderItems
INSERT INTO  OrderItems
VALUES
(1, 2, 1, 499.50),
(2, 3, 2, 999.00),
(2, 5, 3, 599.25),
(3, 3, 1, 999.00),
(4, 1, 6, 299.99);
select * from OrderItems

--Update the price of a book titled "SQL Mastery" by increasing it by 10%. 
 select * from Books
 Update Books set Price=Price*0.10
 where Title='SQL Mastery'

select * from Books

 --Delete a customer who has not placed any orders.
Delete from  Customers
where CustomerID not in(select CustomerID from Orders)
select * from Customers
 --Operators

 --1. Retrieve all books with a price greater than 2000.

 select * from Books
 where Price > 2000

 --2.Find the total number of books available. 

 select count(BookID)as [Total Number of Books Available] from OrderItems


 --3. Find books published between 2015 and 2023. 

 select * from Books
 where PublishedYear between 2015 and 2023

 --4.Find all customers who have placed at least one order.

SELECT * FROM Customers
WHERE CustomerID IN (SELECT CustomerID FROM Orders);

-- 5.Retrieve books where the title contains the word "SQL".
select * from Books
where Title Like'%SQL%'

--6.Find the most expensive book in the store. 
select max(Price) as [Expensive Book]
from Books

--7.Retrieve customers whose name starts with "A" or "J".

select Name as [Customer Name]
from Customers
where Name Like 'A%' Or Name Like 'J%'

--8.Calculate the total revenue from all orders.
select sum(TotalAmount) as [Total Revenue]
from Orders
 
 --Joins

 --1.Retrieve all book titles along with their respective author names.

 select b.Title,a.Name
 from Books b
 Join Authors a on b.AuthorID = a.AuthorID

 --2. List all customers and their orders (if any). 

 select c.Name,o.OrderID,o.OrderDate,o.TotalAmount
 from Customers c
left join Orders o on c.CustomerID=o.CustomerID


--3.Find all books that have never been ordered. 

 select b.Title
 from Books b
 left join OrderItems od on b.BookID=od.BookID
 where od.BookID is null

 --4.Retrieve the total number of orders placed by each customer.

select c.CustomerID, c.Name, count(o.OrderID) as TotalOrders
from Customers c
left join Orders o on c.CustomerID=o.CustomerID
group by c.CustomerID,c.Name

--5. Find the books ordered along with the quantity for each order. 
select o.OrderID,b.Title,od.Quantity
from OrderItems od
join Books b on b.BookID=od.BookID
join Orders o on o.OrderID=od.OrderID

--6.Display all customers, even those who haven’t placed any orders. 
select c.CustomerID, c.Name,o.OrderID,o.OrderDate,o.TotalAmount
from Customers c
left join Orders o on c.CustomerID=o.OrderID

--7. Find authors who have not written any books
select a.AuthorID,a.Name
from Authors a
left join Books b on a.AuthorID=b.AuthorID
where b.BookID is null


--Day 2

--Subqueries
--1.Find the customer(s) who placed the first order (earliest OrderDate).

select * from Customers
where customerID in
(select customerID from Orders
where orderDate=(
(select min(OrderDate) from Orders)))


--2. Find the customer(s) who placed the most orders. 
 
SELECT C.CustomerID, C.Name
FROM Customers C
WHERE C.CustomerID IN (
    SELECT O.CustomerID
    FROM Orders O
    GROUP BY O.CustomerID
    HAVING COUNT(O.OrderID) = (
        SELECT MAX(OrderCount)
        FROM (
            SELECT COUNT(OrderID) AS OrderCount
            FROM Orders
            GROUP BY CustomerID
        ) AS OrderCounts
    )
);

--3.Find customers who have not placed any orders
 select * from Customers
 where CustomerID not in(
 select customerID from Orders
 )

--4. Retrieve all books cheaper than the most expensive book written by( any  author based on your data) 
select * from Books
where price < (select max(Price) from Books)
--5. List all customers whose total spending is greater than the average spending of all customers

select* from Customers
where CustomerID in(
select CustomerID
from Orders where TotalAmount > (select avg(TotalAmount)
from Orders))

--Stored Procedure
--1.Write a stored procedure that accepts a CustomerID and returns all orders placed by that customer
create procedure GetCustomerOrders
@CustomerID int
as
begin
 select orderID,OrderDate,TotalAmount
  from Orders
  where CustomerID=@CustomerID;
End

exec GetCustomerOrders 5;

--2.Create a procedure that accepts MinPrice and MaxPrice as parameters and returns all books within that range

create procedure GetBooksByPriceRange
@minPrice decimal,
@maxPrice decimal
as
begin 
select BookID,Title,AuthorID,Price
from Books
where Price between @minPrice and  @maxPrice;
end

exec GetBooksByPriceRange 500,2000;



--Views--
--1.Create a view named AvailableBooks that shows only books that are in stock, including BookID, Title, AuthorID, Price, and PublishedYear
select * from Books
create view AvailableBooks
as
select * from Books
where  PublishedYear >2000

select * from AvailableBooks 

