CREATE DATABASE BookHaven;
GO

USE BookHaven;
GO

CREATE TABLE UserRoles (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    role_name NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE Users (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    role_id UNIQUEIDENTIFIER NOT NULL,
    username NVARCHAR(50) NOT NULL,
    password_hash NVARCHAR(255) NOT NULL,
    is_deleted BIT DEFAULT 0 NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (role_id) REFERENCES UserRoles(id)
);
GO

CREATE TABLE BookGenres (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    genre_name NVARCHAR(100) NOT NULL,
    is_deleted BIT DEFAULT 0 NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE Books (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    genre_id UNIQUEIDENTIFIER NOT NULL,
    title NVARCHAR(255) NOT NULL,
    author NVARCHAR(255) NOT NULL,
    isbn NVARCHAR(20) NOT NULL,
    price DECIMAL(10,2) NOT NULL CHECK (price > 0),
    stock_quantity INT DEFAULT 0 CHECK (stock_quantity >= 0),
    is_deleted BIT DEFAULT 0 NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (genre_id) REFERENCES BookGenres(id)
);
GO

CREATE TABLE Customers (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    name NVARCHAR(255) NOT NULL,
    email NVARCHAR(255) NULL,
    phone NVARCHAR(15) NULL,
    address NVARCHAR(500) NULL,
    is_deleted BIT DEFAULT 0 NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE Sales (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    customer_id UNIQUEIDENTIFIER NULL,
    user_id UNIQUEIDENTIFIER NOT NULL,
    total_amount DECIMAL(10,2) NOT NULL CHECK (total_amount >= 0),
    discount DECIMAL(10,2) DEFAULT 0 CHECK (discount >= 0),
    sale_date DATETIME DEFAULT GETDATE(),
    is_deleted BIT DEFAULT 0 NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (customer_id) REFERENCES Customers(id),
    FOREIGN KEY (user_id) REFERENCES Users(id)
);
GO

CREATE TABLE SalesDetails (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    sale_id UNIQUEIDENTIFIER NOT NULL,
    book_id UNIQUEIDENTIFIER NOT NULL,
    quantity INT NOT NULL CHECK (quantity > 0),
    price DECIMAL(10,2) NOT NULL CHECK (price >= 0),
    is_deleted BIT DEFAULT 0 NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (sale_id) REFERENCES Sales(id) ON DELETE CASCADE,
    FOREIGN KEY (book_id) REFERENCES Books(id) ON DELETE CASCADE
);
GO

CREATE TABLE Orders (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    customer_id UNIQUEIDENTIFIER NOT NULL,
    user_id UNIQUEIDENTIFIER NOT NULL,
    order_status NVARCHAR(20) CHECK (order_status IN ('Pending', 'Completed', 'Cancelled')) DEFAULT 'Pending',
    total_amount DECIMAL(10,2) NOT NULL CHECK (total_amount >= 0),
    order_date DATETIME DEFAULT GETDATE(),
    delivery_address NVARCHAR(500) NULL,
    is_deleted BIT DEFAULT 0 NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (customer_id) REFERENCES Customers(id),
    FOREIGN KEY (user_id) REFERENCES Users(id)
);
GO

CREATE TABLE OrderDetails (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    order_id UNIQUEIDENTIFIER NOT NULL,
    book_id UNIQUEIDENTIFIER NOT NULL,
    quantity INT NOT NULL CHECK (quantity > 0),
    price DECIMAL(10,2) NOT NULL CHECK (price >= 0),
    is_deleted BIT DEFAULT 0 NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (order_id) REFERENCES Orders(id) ON DELETE CASCADE,
    FOREIGN KEY (book_id) REFERENCES Books(id) ON DELETE CASCADE
);
GO

CREATE TABLE Suppliers (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    name NVARCHAR(255) NOT NULL,
    contact_person NVARCHAR(255) NULL,
    email NVARCHAR(255) NULL,
    phone NVARCHAR(15) NULL,
    address NVARCHAR(500) NULL,
    is_deleted BIT DEFAULT 0 NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE SupplierOrders (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    supplier_id UNIQUEIDENTIFIER NOT NULL,
    order_date DATETIME DEFAULT GETDATE(),
    order_status NVARCHAR(20) CHECK (order_status IN ('Pending', 'Received', 'Cancelled')) DEFAULT 'Pending',
    total_amount DECIMAL(10,2) NOT NULL CHECK (total_amount >= 0),
    is_deleted BIT DEFAULT 0 NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (supplier_id) REFERENCES Suppliers(id)
);
GO

CREATE TABLE SupplierOrderDetails (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    supplier_order_id UNIQUEIDENTIFIER NOT NULL,
    book_id UNIQUEIDENTIFIER NOT NULL,
    quantity INT NOT NULL CHECK (quantity > 0),
    price DECIMAL(10,2) NOT NULL CHECK (price >= 0),
    is_deleted BIT DEFAULT 0 NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (supplier_order_id) REFERENCES SupplierOrders(id) ON DELETE CASCADE,
    FOREIGN KEY (book_id) REFERENCES Books(id) ON DELETE CASCADE
);
GO

CREATE TABLE SalesReports (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    best_selling_book_id UNIQUEIDENTIFIER NULL,
    report_date DATE NOT NULL,
    total_sales DECIMAL(10,2) NOT NULL CHECK (total_sales >= 0),
    is_deleted BIT DEFAULT 0 NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (best_selling_book_id) REFERENCES Books(id)
);
GO

INSERT INTO UserRoles (id, role_name) VALUES (NEWID(), 'Admin');
INSERT INTO UserRoles (id, role_name) VALUES (NEWID(), 'Sales Clerk');

INSERT INTO BookGenres (id, genre_name) VALUES (NEWID(), 'Fiction');
INSERT INTO BookGenres (id, genre_name) VALUES (NEWID(), 'Non-Fiction');
INSERT INTO BookGenres (id, genre_name) VALUES (NEWID(), 'Science Fiction');
INSERT INTO BookGenres (id, genre_name) VALUES (NEWID(), 'Educational');
INSERT INTO BookGenres (id, genre_name) VALUES (NEWID(), 'Collectibles');
