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

##### Example JSON Body Response

```json
{
    "statusCode": 200,
    "statusDescription": "List of all bookshelves",
    "items": [
        {
            "id": 4,
            "shelfName": "Non-Fiction",
            "books": []
        },
        {
            "id": 5,
            "shelfName": "Manga",
            "books": [
                {
                    "id": 2,
                    "bookshelfName": "Manga",
                    "title": "Dragon Ball Z Volume 2",
                    "author": "Akira Toriyama",
                    "pages": 192,
                    "description": "Goku is dead--but his journey is just beginning. Now he must travel through the afterlife along the million-kilometer Serpent Road to find Kaiô-sama, the Lord of Worlds, who will teach him martial arts techniques so powerful they're reserved for the gods!"
                },
                {
                    "id": 1,
                    "bookshelfName": "Manga",
                    "title": "Dragon Ball Z Volume 1",
                    "author": "Akira Toriyama",
                    "pages": 192,
                    "description": "After years of training and adventure, Goku has become Earth's ultimate warrior. And his son, Gohan, shows even greater promise. But the stakes are increasing as even deadlier enemies threaten the planet. DRAGON BALL Z is the ultimate science fiction-martial arts manga."
                }
            ]
        },
        {
            "id": 7,
            "shelfName": "Russian Literature",
            "books": []
        }
    ]
}
```

#### Get Bookshelf by Id

```
GET .../api/Bookshelf/{id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int`    | **Required**. Id of Bookshelf to fetch |

##### Example JSON Body Response

In this case "Russian Literature" is an empty bookshelf

```json
{
    "statusCode": 200,
    "statusDescription": "Bookshelf of id 7 and name 'Russian Literature'",
    "items": {
        "id": 7,
        "shelfName": "Russian Literature",
        "books": []
    }
}
```

#### Create a new Bookshelf

```
POST ../api/Bookshelf/
```

##### Example JSON Request Body Requirements

```json
{
    "ShelfName": "Russian Literature"
}
```

##### Example JSON Body Response

```json
{
    "statusCode": 201,
    "statusDescription": "Bookshelf of id 7 and name 'Russian Literature' is created",
    "items": {
        "id": 7,
        "shelfName": "Russian Literature",
        "books": []
    }
}
```


#### Update an existing Bookshelf

```
PUT .../api/Bookshelf/{id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int`    | **Required**. Id of Bookshelf to update|

##### Example JSON Request Body Requirements

```json
{
    "ShelfName": "Game of Thrones"
}
```

##### Example JSON Body Response

```json
{
    "statusCode": 200,
    "statusDescription": "Bookshelf of id 7 and name 'Game of Thrones' has been updated",
    "items": {
        "id": 7,
        "shelfName": "Game of Thrones",
        "books": []
    }
}
```

#### Delete an existing Bookshelf

```
Delete .../api/Bookshelf/{id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required**. Id of Bookshelf to delete |

##### Example JSON Body Response

```json
{
    "statusCode": 200,
    "statusDescription": "Bookshelf of id 3 and name 'Game of Thrones' is deleted",
    "items": {
        "id": 3,
        "shelfName": "Game of Thrones",
        "books": []
    }
}
```

### Books Documentation

#### Get all Books

```
GET .../api/Bookshelf/
```

##### Example JSON Body Response
```json
{
    "statusCode": 200,
    "statusDescription": "List of all books",
    "items": [
        {
            "id": 1,
            "bookshelfName": "Manga",
            "title": "Dragon Ball Z Volume 1",
            "author": "Akira Toriyama",
            "pages": 192,
            "description": "After years of training and adventure, Goku has become Earth's ultimate warrior. And his son, Gohan, shows even greater promise. But the stakes are increasing as even deadlier enemies threaten the planet. DRAGON BALL Z is the ultimate science fiction-martial arts manga."
        },
        {
            "id": 2,
            "bookshelfName": "Manga",
            "title": "Dragon Ball Z Volume 2",
            "author": "Akira Toriyama",
            "pages": 192,
            "description": "Goku is dead--but his journey is just beginning. Now he must travel through the afterlife along the million-kilometer Serpent Road to find Kaiô-sama, the Lord of Worlds, who will teach him martial arts techniques so powerful they're reserved for the gods!"
        },
        {
            "id": 3,
            "bookshelfName": "Game of Thrones",
            "title": "Fire & Blood: 300 Years Before A Game of Thrones",
            "author": "George R. R. Martin",
            "pages": 736,
            "description": "Centuries before the events of A Game of Thrones, House Targaryen—the only family of dragonlords to survive the Doom of Valyria—took up residence on Dragonstone. Fire & Blood begins their tale with the legendary Aegon the Conqueror, creator of the Iron Throne, and goes on to recount the generations of Targaryens who fought to hold that iconic seat, all the way up to the civil war that nearly tore their dynasty apart."
        }
    ]
}
```


```
POST .../api/Bookshelf/
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required**. Id of Book to fetch |
| `BookshelfId`      | `int` | **Required**. Id of Bookshelf to add book to |

##### Example JSON Request Body Requirements

```json
{
    "Title": "Fire & Blood: 300 Years Before A Game of Thrones",
    "Author": "George R. R. Martin",
    "Pages": 736,
    "Description": "Centuries before the events of A Game of Thrones, House Targaryen—the only family of dragonlords to survive the Doom of Valyria—took up residence on Dragonstone. Fire & Blood begins their tale with the legendary Aegon the Conqueror, creator of the Iron Throne, and goes on to recount the generations of Targaryens who fought to hold that iconic seat, all the way up to the civil war that nearly tore their dynasty apart.",
    "BookshelfId": 7
}
```

##### Example JSON Body Response
```json
{
    "statusCode": 201,
    "statusDescription": "Book of id 3 and title 'Fire & Blood: 300 Years Before A Game of Thrones' is created in Bookshelf named Game of Thrones",
    "items": {
        "id": 3,
        "bookshelfName": "Game of Thrones",
        "title": "Fire & Blood: 300 Years Before A Game of Thrones",
        "author": "George R. R. Martin",
        "pages": 736,
        "description": "Centuries before the events of A Game of Thrones, House Targaryen—the only family of dragonlords to survive the Doom of Valyria—took up residence on Dragonstone. Fire & Blood begins their tale with the legendary Aegon the Conqueror, creator of the Iron Throne, and goes on to recount the generations of Targaryens who fought to hold that iconic seat, all the way up to the civil war that nearly tore their dynasty apart."
    }
}
```
