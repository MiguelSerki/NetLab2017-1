﻿-- 1) Una lista de todos los detalles de la tabla de empleados.
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
-- viven en EE.UU.
-- cargo es igual a Propietario.
-- la letra "A”.
-- promedio y el máximo gasto de envió (puede estar separado en 3 consultas distintas).
-- clientes en cada ciudad.
FROM dbo.Customers
GROUP BY City
*/


-- 15) Utilizando la tabla de clientes una lista de los nombres de ciudades y el número de
-- clientes en cada ciudad. Solo las ciudades con al menos 2 clientes deben aparecer en
-- la lista.
FROM dbo.Customers
GROUP BY City
HAVING COUNT(CustomerID) >= 2
*/


-- 16) Insertar el cliente nuevo completando todos los campos de la tabla.
UPDATE dbo.Customers
SET ContactName = 'El Kevo'
WHERE CustomerID = 'DWARE';
*/


-- 18) Eliminar el cliente insertado en el punto 16.
/*
DELETE FROM dbo.Customers
WHERE CustomerID = 'DWARE';
*/