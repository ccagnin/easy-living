# Easy Living Api

## Table of Contents
- [Easy Living Api](#easy-living-api)
  - [Table of Contents](#table-of-contents)
  - [Auth](#auth)
    - [Register](#register)
      - [Register Request](#register-request)
      - [Register Response](#register-response)
    - [Login](#login)
      - [Login Request](#login-request)
      - [Login Response](#login-response)

## Auth

### Register

```js
POST {{host}}/auth/register
```

#### Register Request

```json
{
  "firstName": "John",
  "lastName": "Doe",
  "email": "exemple@email.com",
  "password": "123456"
}
```

#### Register Response

```js
200 OK
```

```json
{
  "id": "d89c4a8e-3b2b-4b7a-9f1a-8b1b2b3b4b5b",
  "firstName": "John",
  "lastName": "Doe",
  "email": "exemple@email.com",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9"
}
```

### Login

```js
POST {{host}}/auth/login
```

#### Login Request

```json
{
  "email": "exemple@email.com",
  "password": "123456"
}
```


#### Login Response

```json
{
  "id": "d89c4a8e-3b2b-4b7a-9f1a-8b1b2b3b4b5b",
  "firstName": "John",
  "lastName": "Doe",
  "email": "exemple@email.com",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9"
}
```
