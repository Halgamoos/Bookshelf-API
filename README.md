# Bookshelf-API

## Why Bookshelf API?

I have so many books in my book shelf and lose track of the books that I have. At the moment, to find out if I have a book in my book shelf I have to manually search for each book in my shelf which worst case takes linear time. With this API, I can make a GET request and find out if I currently have the book instantly!

Another reason for using an API for books in bookshelves is the fact that you can really compartmentalize as many bookshelves as you like where as in the real world there is a physical limitation. You can have as many bookshelves with their own specific genres as you like. 

For example, a dedicated bookshelf for solely manga. 
<img width="714" alt="Screenshot 2022-11-28 at 3 28 50 PM" src="https://user-images.githubusercontent.com/24259728/204374549-02d28641-46f4-45f0-b9e3-f40f0716c0c9.png">


#### Database and relationship Diagram
<img width="799" alt="Screenshot 2022-11-28 at 2 33 51 PM" src="https://user-images.githubusercontent.com/24259728/204365009-8bced4b3-a6fd-4da4-b73e-6d3f208ff649.png">

### Bookshelves API Documentation

#### Get all Bookshelves

```
GET .../api/Bookshelf/
```

#### Get Bookshelf by Id

```
GET .../api/Bookshelf/{id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int`    | **Required**. Id of Bookshelf to fetch |

#### Create a new Bookshelf

```
POST ../api/Bookshelf/
```

##### JSON Request Body Requirements

```json
{
    "ShelfName": "String"
}
```

##### Example JSON Body Response

```json
{
}
```


#### Update an existing Bookshelf

```
PUT .../api/Bookshelf/{id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int`    | **Required**. Id of Bookshelf to update|

#### Delete an existing Bookshelf

```
Delete .../api/Bookshelf/{id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required**. Id of Bookshelf to delete |

### Books Documentation

#### Get all Bookshelves

```
GET .../api/Bookshelf/
```

```
GET .../api/Bookshelf/{id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required**. Id of Book to fetch |
