CREATE DATABASE BookshelfDB;

CREATE TABLE Bookshelves (
    Id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    ShelfName VARCHAR(100) NOT NULL,
);

CREATE TABLE Books (
    Id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    Title VARCHAR(100) NOT NULL,
    Author VARCHAR(100) NOT NULL,
    Pages INT NOT NULL,
    BookDescription VARCHAR(1000) NOT NULL,
    BookshelfId INT NOT NULL,
    FOREIGN KEY (BookshelfId) REFERENCES Bookshelves(Id)
);