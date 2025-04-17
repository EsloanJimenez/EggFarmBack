CREATE DATABASE ARE;
GO

USE ARE;
GO

CREATE TABLE Role(
	RoleId INT IDENTITY(1,1) PRIMARY KEY,
	RoleName VARCHAR(20) NOT NULL,
	Description VARCHAR(100),
    UserCreation INT,
    UserModify INT,
    UserDelete INT,
    CreationDate DATETIME DEFAULT GETDATE() NOT NULL,
    ModifyDate DATE,
    DeletedDate DATE,
    Deleted BIT DEFAULT 0 NOT NULL
);
GO

CREATE TABLE Users(
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    RoleId INT NOT NULL,
    UserName VARCHAR(25) NOT NULL UNIQUE,
    PasswordHash TEXT NOT NULL,
    UserCreation INT,
    UserModify INT,
    UserDelete INT,
    CreationDate DATETIME DEFAULT GETDATE() NOT NULL,
    ModifyDate DATE,
    DeletedDate DATE,
    Deleted BIT DEFAULT 0 NOT NULL
	FOREIGN KEY (RoleId) REFERENCES Role(RoleId),
	FOREIGN KEY (UserCreation) REFERENCES Users(UserId),
	FOREIGN KEY (UserModify) REFERENCES Users(UserId),
	FOREIGN KEY (UserDelete) REFERENCES Users(UserId)
);
GO

ALTER TABLE Role
ADD CONSTRAINT 
FK_Role_UserCreation FOREIGN KEY (UserCreation) REFERENCES Users(UserId);

ALTER TABLE Role
ADD CONSTRAINT 
FK_Role_UserModify FOREIGN KEY (UserModify) REFERENCES Users(UserId);

ALTER TABLE Role
ADD CONSTRAINT 
FK_Role_UserDelete FOREIGN KEY (UserDelete) REFERENCES Users(UserId);
GO

INSERT INTO Role (RoleName, Description)
VALUES
('Admin', 'Rol de administrador del sistema'),
('Editor', 'Rol de editor de contenido'),
('Viewer', 'Rol de visualizador de contenido'),
('Manager', 'Rol de gerente de proyectos'),
('Guest', 'Rol de invitado con acceso limitado');
GO

INSERT INTO Users (RoleId, UserName, PasswordHash)
VALUES (1, 'prueba1', '123');
GO

UPDATE Role SET UserCreation = 1;
GO

UPDATE Users SET UserCreation = 1;
GO

ALTER TABLE Role
ALTER COLUMN
UserCreation INT NOT NULL;
GO

ALTER TABLE Users
ALTER COLUMN
UserCreation INT NOT NULL;
GO

CREATE TABLE Customers(
    CustomerId INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(25) NOT NULL,
    LastName VARCHAR(25) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    Phone VARCHAR(15) NOT NULL UNIQUE,
    Address VARCHAR(100),
    UserCreation INT NOT NULL,
    UserModify INT,
    UserDelete INT,
    CreationDate DATETIME DEFAULT GETDATE() NOT NULL,
    ModifyDate DATETIME,
    DeletedDate DATETIME,
    Deleted BIT DEFAULT 0 NOT NULL
	FOREIGN KEY (UserCreation) REFERENCES Users(UserId),
	FOREIGN KEY (UserModify) REFERENCES Users(UserId),
	FOREIGN KEY (UserDelete) REFERENCES Users(UserId)
);
GO

INSERT INTO Customers (FirstName, LastName, Email, Phone, Address, UserCreation)
VALUES 
('Juan', 'Pérez', 'juan.perez@example.com', '8091234567', 'Av. Bolívar #101', 1),
('María', 'Gómez', 'maria.gomez@example.com', '8097654321', 'Calle Duarte #55', 1),
('Pedro', 'Martínez', 'pedro.martinez@example.com', '8291234567', 'Av. Winston Churchill #30', 1),
('Ana', 'Rodríguez', 'ana.rodriguez@example.com', '8495556677', 'Calle El Conde #20', 1),
('Luis', 'Fernández', 'luis.fernandez@example.com', '8093344556', 'Av. 27 de Febrero #80', 1);
GO

CREATE TABLE Products(
    ProductId INT IDENTITY(1,1) PRIMARY KEY,
    ProductName VARCHAR(50) NOT NULL,
    Description VARCHAR(200),
    Price DECIMAL(10,2) NOT NULL,
    UserCreation INT NOT NULL,
    UserModify INT,
    UserDelete INT,
    CreationDate DATETIME DEFAULT GETDATE() NOT NULL,
    ModifyDate DATETIME,
    DeletedDate DATETIME,
    Deleted BIT DEFAULT 0 NOT NULL
	FOREIGN KEY (UserCreation) REFERENCES Users(UserId),
	FOREIGN KEY (UserModify) REFERENCES Users(UserId),
	FOREIGN KEY (UserDelete) REFERENCES Users(UserId)
);
GO

INSERT INTO Products (ProductName, Description, Price, UserCreation)
VALUES 
('Huevos Blancos', 'Huevos frescos de gallina blanca, ideales para el desayuno.', 150.00, 1),
('Huevo Orgánico', 'Huevos producidos sin químicos ni hormonas.', 200.00, 1),
('Huevos de Codorniz', 'Huevos pequeños y nutritivos, perfectos para bocadillos.', 120.00, 1),
('Huevos Jumbo', 'Huevos de gran tamaño, excelente opción para repostería.', 180.00, 1),
('Huevo Criollo', 'Provenientes de gallinas criadas libremente en campo abierto.', 220.00, 1);
GO

CREATE TABLE Inventory(
    InventoryId INT IDENTITY(1,1) PRIMARY KEY,
    ProductId INT NOT NULL,
    QuantityAdded INT NOT NULL,
    QuantityAvailable INT NOT NULL,
    Notes VARCHAR(200),
    UserCreation INT NOT NULL,
    UserModify INT,
    UserDelete INT,
    CreationDate DATETIME DEFAULT GETDATE() NOT NULL,
    ModifyDate DATETIME,
    DeletedDate DATETIME,
    Deleted BIT DEFAULT 0 NOT NULL,
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId),
	FOREIGN KEY (UserCreation) REFERENCES Users(UserId),
	FOREIGN KEY (UserModify) REFERENCES Users(UserId),
	FOREIGN KEY (UserDelete) REFERENCES Users(UserId)
);
GO

CREATE TABLE Orders(
    OrderId INT IDENTITY(1,1) PRIMARY KEY,
    CustomerId INT NOT NULL,
    TotalAmount DECIMAL(10,2) NOT NULL,
    Status VARCHAR(50) NOT NULL, -- pendiente, pagado
    UserCreation INT NOT NULL,
    UserModify INT,
    UserDelete INT,
    CreationDate DATETIME DEFAULT GETDATE() NOT NULL,
    ModifyDate DATETIME,
    DeletedDate DATETIME,
    Deleted BIT DEFAULT 0 NOT NULL,
    FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId),
	FOREIGN KEY (UserCreation) REFERENCES Users(UserId),
	FOREIGN KEY (UserModify) REFERENCES Users(UserId),
	FOREIGN KEY (UserDelete) REFERENCES Users(UserId)
);
GO

CREATE TABLE OrderDetails(
    OrderDetailId INT IDENTITY(1,1) PRIMARY KEY,
    OrderId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10,2) NOT NULL,
    SubTotal DECIMAL(10,2) NOT NULL,
    UserCreation INT NOT NULL,
    UserModify INT,
    UserDelete INT,
    CreationDate DATETIME DEFAULT GETDATE() NOT NULL,
    ModifyDate DATETIME,
    DeletedDate DATETIME,
    Deleted BIT DEFAULT 0 NOT NULL,
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId),
	FOREIGN KEY (UserCreation) REFERENCES Users(UserId),
	FOREIGN KEY (UserModify) REFERENCES Users(UserId),
	FOREIGN KEY (UserDelete) REFERENCES Users(UserId)
);
GO