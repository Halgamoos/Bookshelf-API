# Bookshelf-API

## Why Bookshelf API?

#### Database and relationship Diagram

#### SQL Script

```sql
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
```

### Bookshelves API Documentation

#### Get all Bookshelves

```http
  GET .../api/Bookshelf/
```

#### Get Bookshelf by Id

```http
  GET .../api/Bookshelf/{id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int`    | **Required**. Id of Bookshelf to fetch |

#### Create a new Bookshelf

```http
  POST .../api/Bookshelf/
```

##### JSON Request Body Requirements

```http
{
    "ShelfName": "String"
}
```

##### Example JSON Body Response

```http
{
}
```


#### Update an existing Bookshelf

```http
  PUT .../api/Bookshelf/{id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int`    | **Required**. Id of Bookshelf to update|

#### Delete an existing Bookshelf

```http
  Delete .../api/Bookshelf/{id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required**. Id of Bookshelf to delete |

### Books Documentation

#### Get all Bookshelves

```http
  GET .../api/Bookshelf/
```

```http
  GET .../api/Bookshelf/{id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required**. Id of Book to fetch |