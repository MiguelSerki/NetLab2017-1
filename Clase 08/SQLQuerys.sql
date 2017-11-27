-- 1) Una lista de todos los detalles de la tabla de empleados.
/*
SELECT *
FROM dbo.Employees
*/


-- 2) Una lista de los nombres y apellidos de todos los empleados.
/*
SELECT LastName, FirstName
FROM dbo.Employees
*/


-- 3) Una lista de todos los nombres de las ciudades que aparecen en la tabla de empleados.
-- No mostrar 2 veces un mismo nombre de ciudad.
/*
SELECT DISTINCT City
FROM dbo.Employees
*/


-- 4) Una lista de los nombres de productos y precios unitarios.
/*
SELECT ProductName, UnitPrice
FROM dbo.Products
*/


-- 5) En la tabla de empleados: una lista de los detalles completos de los empleados que
-- viven en EE.UU./*SELECT *FROM dbo.EmployeesWHERE Country = 'USA'*/-- 6) A partir de la tabla Pedidos, listar todos los pedidos que-- tienen un gasto de envió > 50./*SELECT *FROM dbo.OrdersWHERE Freight > 50*/-- 7) De la tabla de clientes: listar nombre de la empresa de todos los clientes donde el
-- cargo es igual a Propietario./*SELECT CompanyNameFROM dbo.CustomersWHERE ContactTitle = 'Owner'*/-- 8) A partir de los clientes una lista de todos donde el nombre del cliente comienza con
-- la letra "A”./*SELECT *FROM dbo.CustomersWHERE LEFT(ContactName,1) = 'A'*/-- 9) Una lista de los nombres de clientes donde la región no está en blanco./*SELECT ContactNameFROM dbo.CustomersWHERE Region IS NOT NULL*/-- 10) Una lista de todos los productos, ordenado por precio unitario-- (el más barato primero)./*SELECT *FROM dbo.ProductsORDER BY UnitPrice ASC*/-- 11)  Una lista de todos los productos, ordenado por precio unitario-- (el más caro primero)./*SELECT *FROM dbo.ProductsORDER BY UnitPrice DESC*/-- 12) El número total de empleados. Nombre de la columna de salida "TotalEmpleados"./*SELECT COUNT(*) AS TotalEmpleadosFROM dbo.Employees*/-- 13) De la tabla de Pedidos, el pedido con el menor gasto de envió, el gasto de envió
-- promedio y el máximo gasto de envió (puede estar separado en 3 consultas distintas)./*SELECT MIN(Freight) AS Menor, MAX(Freight) AS Mayor, AVG(Freight) AS PromedioFROM dbo.Orders;*/-- 14) Utilizando la tabla de clientes una lista de los nombres de ciudades y el número de
-- clientes en cada ciudad./*SELECT COUNT(CustomerID) AS Clientes, City
FROM dbo.Customers
GROUP BY City
*/


-- 15) Utilizando la tabla de clientes una lista de los nombres de ciudades y el número de
-- clientes en cada ciudad. Solo las ciudades con al menos 2 clientes deben aparecer en
-- la lista./*SELECT COUNT(CustomerID) AS Clientes, City
FROM dbo.Customers
GROUP BY City
HAVING COUNT(CustomerID) >= 2
*/


-- 16) Insertar el cliente nuevo completando todos los campos de la tabla./*INSERT INTO dbo.CustomersVALUES ('DWARE', 'Devil Ware', 'Kevin Morelli', 'Owner', 'Casablanca 1559',	'Rosario', 'Santa Fe', '2000', 'Argentina', '3416967878', NULL)*/-- 17) Actualizar el nombre del nuevo cliente pasando número de ID obtenido en el punto 16./*
UPDATE dbo.Customers
SET ContactName = 'El Kevo'
WHERE CustomerID = 'DWARE';
*/


-- 18) Eliminar el cliente insertado en el punto 16.
/*
DELETE FROM dbo.Customers
WHERE CustomerID = 'DWARE';
*/