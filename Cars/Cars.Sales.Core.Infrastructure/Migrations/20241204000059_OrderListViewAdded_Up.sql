CREATE VIEW sales.OrderListView 
AS
SELECT o.Id, o.Customer_CustomerId AS CustomerId, o.Customer_Name AS CustomerName, o.CreationDate, o.Price, o.OriginalPrice - o.Price AS Discount, o.Status
FROM sales.Orders o
WHERE o.Status != 3
GO
