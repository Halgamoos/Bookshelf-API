# Bookshelf-API

## Why Bookshelf API?

I have so many books in my book shelf and lose track of the books that I have. At the moment, to find out if I have a book in my book shelf I have to manually search for each book in my shelf which worst case takes linear time. With this API, I can make a GET request and find out if I currently have the book instantly!

#### Database and relationship Diagram
<img width="799" alt="Screenshot 2022-11-28 at 2 33 51 PM" src="https://user-images.githubusercontent.com/24259728/204365009-8bced4b3-a6fd-4da4-b73e-6d3f208ff649.png">

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
  POST ../api/Bookshelf/
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
