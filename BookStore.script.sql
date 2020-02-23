USE [master]
GO
/****** Object:  Database [BookStore]    Script Date: 10-Feb-20 19:55:39 ******/
CREATE DATABASE [BookStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookStore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\BookStore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BookStore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\BookStore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BookStore] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookStore] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BookStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookStore] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BookStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BookStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookStore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BookStore] SET  MULTI_USER 
GO
ALTER DATABASE [BookStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookStore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BookStore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BookStore] SET QUERY_STORE = OFF
GO
USE [BookStore]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 10-Feb-20 19:55:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookId] [int] NOT NULL,
	[Title] [varchar](700) NULL,
	[Author] [varchar](700) NULL,
	[Stock] [int] NULL,
	[CategoryId] [int] NOT NULL,
	[Price] [varchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 10-Feb-20 19:55:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] NOT NULL,
	[CategoryName] [varchar](750) NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer_LogIn]    Script Date: 10-Feb-20 19:55:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer_LogIn](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Role] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 10-Feb-20 19:55:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] NOT NULL,
	[FirstName] [varchar](500) NOT NULL,
	[LastName] [varchar](500) NULL,
	[BirthDate] [datetime] NULL,
	[Address] [varchar](900) NOT NULL,
	[PhoneNumber] [varchar](500) NOT NULL,
	[Email] [varchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 10-Feb-20 19:55:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[OrderItemId] [varchar](1) NOT NULL,
	[Quantity] [int] NULL,
	[BookId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 10-Feb-20 19:55:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderNumber] [int] NOT NULL,
	[DateOrdered] [datetime] NOT NULL,
	[Cost] [int] NOT NULL,
	[DateDelivered] [datetime] NULL,
	[CustomerID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[OrderNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([BookId])
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
/****** Object:  StoredProcedure [dbo].[AddABook]    Script Date: 10-Feb-20 19:55:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddABook]
@Title VARCHAR (700),
@Author VARCHAR (700),
@PublishingHouse VARCHAR (900),
@Stock INT

AS
BEGIN

INSERT INTO Books
(Title, Author, PublishingHouse, Stock)
VALUES
(@Title, @Author, @PublishingHouse, @Stock)

END;
GO
/****** Object:  StoredProcedure [dbo].[AddACategory]    Script Date: 10-Feb-20 19:55:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddACategory]
@Category VARCHAR (150)

AS 
BEGIN

INSERT INTO Categories
(Category)
VALUES
(@Category)

END;
GO
/****** Object:  StoredProcedure [dbo].[AddACustomer]    Script Date: 10-Feb-20 19:55:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddACustomer]
@FirstName VARCHAR (500),
@LastName VARCHAR (500),
@BirthDate VARCHAR (500),
@Address VARCHAR (900),
@PhoneNumber VARCHAR (500),
@Email VARCHAR (150)

AS
BEGIN

INSERT INTO Customers
(FirstName, LastName, BirthDate, Address, PhoneNumber, Email)
VALUES
(@FirstName, @LastName, @BirthDate, @Address, @PhoneNumber, @Email)

END;
GO
/****** Object:  StoredProcedure [dbo].[DeleteBook]    Script Date: 10-Feb-20 19:55:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteBook]
@BookId INT

AS
BEGIN

DELETE
FROM Books
WHERE BookId = @BookId

END;
GO
/****** Object:  StoredProcedure [dbo].[DeleteCustomer]    Script Date: 10-Feb-20 19:55:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteCustomer]
@CustomerId INT

AS
BEGIN

DELETE
FROM Customers
WHERE CustomerId = @CustomerId

END;
GO
/****** Object:  StoredProcedure [dbo].[GetABook]    Script Date: 10-Feb-20 19:55:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetABook]
@BookId INT

AS
BEGIN

SELECT * FROM Books
WHERE BookId = @BookId

END;
GO
/****** Object:  StoredProcedure [dbo].[GetCustomer]    Script Date: 10-Feb-20 19:55:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCustomer]
@CustomerId INT

AS
BEGIN

SELECT *
FROM Customers
WHERE CustomerId = @CustomerId

END;
GO
/****** Object:  StoredProcedure [dbo].[NewOrder]    Script Date: 10-Feb-20 19:55:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NewOrder]
@OrderNumber INT,
@DateOrdered DATETIME,
@Cost INT

AS
BEGIN

INSERT INTO Orders
(OrderNumber, DateOrdered, Cost)
VALUES
(@OrderNumber, @DateOrdered, @Cost)

END;
GO
/****** Object:  StoredProcedure [dbo].[SelectBookByAuthor]    Script Date: 10-Feb-20 19:55:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectBookByAuthor]
@Author VARCHAR (500)

AS
BEGIN

SELECT * FROM Books
WHERE 
Author = @Author

END;
GO
/****** Object:  StoredProcedure [dbo].[SelectBookByTitle]    Script Date: 10-Feb-20 19:55:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectBookByTitle]
@Title VARCHAR (500)

AS
BEGIN

SELECT * FROM Books
WHERE 
Title = @Title

END;
GO
/****** Object:  StoredProcedure [dbo].[SelectByCategory]    Script Date: 10-Feb-20 19:55:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectByCategory]
@Category VARCHAR

AS
BEGIN

SELECT * FROM Books
INNER JOIN Categories ON Books.CategoryId = Categories.CategoryId
WHERE 
Category = @Category

END;
GO
/****** Object:  StoredProcedure [dbo].[SelectByPublishingHouse]    Script Date: 10-Feb-20 19:55:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectByPublishingHouse]
@PublishingHouse VARCHAR (500)

AS
BEGIN

SELECT * FROM Books
WHERE 
PublishingHouse = @PublishingHouse

END;
GO
/****** Object:  StoredProcedure [dbo].[SetDeliveryDate]    Script Date: 10-Feb-20 19:55:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SetDeliveryDate]
@OrderNumber INT,
@DateDelivered DATETIME

AS
BEGIN

UPDATE Orders
SET DateDelivered = @DateDelivered
WHERE OrderNumber = @OrderNumber

END;
GO
/****** Object:  StoredProcedure [dbo].[UpdateBook]    Script Date: 10-Feb-20 19:55:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateBook]
@BookId INT,
@Title VARCHAR,
@Author VARCHAR,
@Stock VARCHAR,
@CategoryId INT

AS
BEGIN

UPDATE Books
SET
Title = @Title, Author = @Author, Stock = @Stock, CategoryId = @CategoryId
WHERE 
BookId = @BookId

END;
GO
/****** Object:  StoredProcedure [dbo].[UpdateCustomerInfo]    Script Date: 10-Feb-20 19:55:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateCustomerInfo]
@CustomerId INT,
@FirstName VARCHAR (500),
@LastName VARCHAR (500),
@BirthDate VARCHAR (500),
@Address VARCHAR (900),
@PhoneNumber VARCHAR (500),
@Email VARCHAR (150)

AS
BEGIN

UPDATE Customers
SET FirstName = @FirstName, LastName = @LastName, BirthDate = @BirthDate, Address = @Address, PhoneNumber = @PhoneNumber, Email = @Email
WHERE CustomerId = @CustomerId

END;
GO
/****** Object:  StoredProcedure [dbo].[UpdateStock]    Script Date: 10-Feb-20 19:55:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateStock]
@BookId INT,
@Stock INT

AS
BEGIN

UPDATE Books
SET Stock = @Stock
WHERE BookId = @BookId

END;
GO
USE [master]
GO
ALTER DATABASE [BookStore] SET  READ_WRITE 
GO
