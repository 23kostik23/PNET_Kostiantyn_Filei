INSERT INTO Departments (DEPT_ID, NAME, INFO) VALUES (1, 'Grocery', 'Food Storage');

INSERT INTO Goods (GOOD_ID, QUANTITY, PRODUCER, DEPT_ID, DESCRIPTION, Price) VALUES 
(101, 5, 'Nestle', 1, 'Chocolate bar', 50.00),
(102, 20, 'Nestle', 1, 'Coffee', 150.00),
(103, 2, 'MilkFarm', 1, 'Milk 1L', 40.00);

INSERT INTO Sales (SALE_ID, CHECK_NO, GOOD_ID, DATE_SALE, QUANTITY) VALUES 
(1, 777, 101, GETDATE(), 5),
(2, 888, 102, GETDATE(), 5),
(3, 999, 101, GETDATE(), 5);