# Dinner Api

- [Dinner Api](#dinner-api)
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
    "firstName":"Mohamed",
    "lastName":"AlQadeery",
    "email":"mohamed@gmail.com",
    "password":"password123"
}
```

#### Register Response
```js
200 OK
```

```json
{
    "id":"f47ac10b-58cc-4372-a567-0e02b2c3d479",
    "firstName":"Mohamed",
    "lastName":"AlQadeery",
    "email":"mohamed@gmail.com",
    "token":"eyJhb...1NiIsInR5cCI6Ik"
}
```


### Login

```js
POST {{host}}/auth/login
```

#### Login Request
```json
{
    "email":"mohamed@gmail.com",
    "password":"password123"
}
```

#### Login Response
```js
200 OK
```

```json
{
    "id":"f47ac10b-58cc-4372-a567-0e02b2c3d479",
    "firstName":"Mohamed",
    "lastName":"AlQadeery",
    "email":"mohamed@gmail.com",
    "token":"eyJhb...1NiIsInR5cCI6Ik"
}
```