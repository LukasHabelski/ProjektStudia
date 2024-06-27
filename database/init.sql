-- Existing Tables
CREATE TABLE Products (
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Price DECIMAL NOT NULL
);

CREATE TABLE Orders (
    Id SERIAL PRIMARY KEY,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    CONSTRAINT FK_Orders_Products FOREIGN KEY (ProductId) REFERENCES Products(Id)
);

-- New Table for Calendar Tasks
CREATE TABLE CalendarTasks (
    Id SERIAL PRIMARY KEY,
    Title VARCHAR(255) NOT NULL,
    TaskDate DATE NOT NULL
);

-- New Tables for Inventory Management
CREATE TABLE Inventory (
    Id SERIAL PRIMARY KEY,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    CONSTRAINT FK_Inventory_Products FOREIGN KEY (ProductId) REFERENCES Products(Id)
);

CREATE TABLE InventoryDocuments (
    Id SERIAL PRIMARY KEY,
    DocumentType VARCHAR(50) NOT NULL,
    DocumentNumber VARCHAR(50) NOT NULL,
    Date DATE NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    CONSTRAINT FK_InventoryDocuments_Products FOREIGN KEY (ProductId) REFERENCES Products(Id)
);
