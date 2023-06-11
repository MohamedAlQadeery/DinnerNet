# DinnerNet API

- [DinnerNet API](#dinnernet-api)
  - [Auth](#auth)
    - [Register](#register)
      - [Register Request](#register-request)
      - [Register Response](#register-response)
    - [Login](#login)
      - [Login Request](#login-request)
      - [Login Response](#login-response)

## Auth

### Register

#### Register Request

```js
POST /auth/register
```

```json
{
    "firstName": "mohamed",
    "lastName": "AlQadeery",
    "email": "mohamed@gmail.com",
    "password": "Password123!"
}
```

#### Register Response

```js
200 OK
```

```json
{
  "id": "d89c2d9a-eb3e-4075-95ff-b920b55aa104",
  "firstName": "Mohamed",
  "lastName": "AlQadeery",
  "email": "mohamed@gmail.com",
  "token": "eyJhb..z9dqcnXoY"
}
```

### Login

#### Login Request

```js
POST /auth/login
```

```json
{
    "email": "Mohamed@gmail.com",
    "password": "Passwword123!"
}
```

```js
200 OK
```

#### Login Response

```json
{
  "id": "d89c2d9a-eb3e-4075-95ff-b920b55aa104",
  "firstName": "mohamed",
  "lastName": "AlQadeery",
  "email": "mohamed@gmail.com",
  "token": "eyJhb..hbbQ"
}
```