CREATE PROCEDURE dbo.pr_GetOrderSummary
	@StartDate date, 
	@EndDate date, 
	@EmployeeID int, 
	@CustomerID nvarchar(10)
AS
begin
	select TitleOfCourtesy,FirstName,LastName,OrderDate,Customers.CompanyName,
	Shippers.CompanyName,Orders.OrderID,Count(Orders.OrderID) AS NumberOfDifferentProducts, Sum([Order Details].Quantity * UnitPrice) as TotalOrderValue,Freight
	from Orders
	LEFT JOIN dbo.Employees ON Orders.EmployeeID = Employees.EmployeeID
	LEFT JOIN dbo.Customers ON Orders.CustomerID = Customers.CustomerID
	LEFT JOIN dbo.Shippers ON Orders.ShipVia = Shippers.ShipperID
	LEFT JOIN dbo.[Order Details] ON Orders.OrderID = [Order Details].OrderID
	where OrderDate between @StartDate and @EndDate
	and Employees.EmployeeID = COALESCE(@EmployeeID,Employees.EmployeeID)
	and Customers.CustomerID = COALESCE(@CustomerID,Customers.CustomerID)
	Group by Orders.OrderID,TitleOfCourtesy,FirstName,LastName,OrderDate,Customers.CompanyName,Shippers.CompanyName,Orders.OrderID,Freight
end


--ProductID,