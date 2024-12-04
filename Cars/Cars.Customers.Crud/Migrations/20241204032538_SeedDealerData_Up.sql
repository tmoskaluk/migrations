SET IDENTITY_INSERT customers.Customers ON

INSERT INTO customers.Customers (Id, IdentityNo, FirstName, LastName, Phone, CustomerType) 
VALUES (-1, 'DEALER', 'Dealer', 'Lublin', '817771111', 2)

SET IDENTITY_INSERT customers.Customers OFF