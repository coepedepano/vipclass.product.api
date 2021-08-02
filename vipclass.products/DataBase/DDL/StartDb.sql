DROP TABLE Courses
CREATE TABLE dbo.Courses
(
    IdCourse BIGINT IDENTITY(1,1) NOT NULL,
    IdCategorie INT,
    Title NVARCHAR(400) NOT NULL,
    Description NVARCHAR(MAX) NOT NULL,
    ImageCover VARBINARY(MAX),
    Price DECIMAL NOT NULL,
    Active BIT
)

DROP TABLE Producer
CREATE TABLE dbo.Producer
(
    IdProducer BIGINT IDENTITY(1,1) NOT NULL,
    IdCourse BIGINT NOT NULL,
    Wallet NVARCHAR(MAX),
    Royalts DECIMAL NOT NULL,
    Active BIT
)

DROP TABLE CoProducer
CREATE TABLE dbo.CoProducer
(
    IdCoProducer BIGINT IDENTITY(1,1) NOT NULL,
    IdCourse BIGINT NOT NULL,
    Wallet NVARCHAR(MAX),
    Royalts DECIMAL NOT NULL,
    Active BIT
)

DROP TABLE Categories
CREATE TABLE dbo.Categories
(
    IdCategorie INT IDENTITY(1,1) NOT NULL,
    Description NVARCHAR(300) NOT NULL,
    Active BIT
)

DROP TABLE Coins
CREATE TABLE dbo.Coins
(
    IdCoin INT IDENTITY(1,1) NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(300) NOT NULL,
    Active BIT    
)