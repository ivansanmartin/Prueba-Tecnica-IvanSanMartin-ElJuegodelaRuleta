# 🎰 Roulette - Prueba Técnica

Prueba técnica que trata sobre el desarrollo de "El Juego de la Ruleta", frontend realizado utilizando Vue.js y JavaScript, backend construido con ASP.NET Core en .NET 8

## 📋 Endpoints disponibles

### 🎯 Roulette

- `GET /api/spin-roulette`  
  Gira la ruleta y devuelve el resultado.

Respuesta JSON ejemplo:
  ~~~
  {
      "number": 35,
      "color": "black",
      "parity": "odd"
  }
  ~~~

### 👤 User

- `GET /api/users/{username}`  
  Obtiene información del usuario por nombre de usuario.

- `POST /api/users`  
  Crea un nuevo usuario.

  Ejemplo Body:
  ~~~
    {
        "username": "ivan",
        "amount": 1200
    }
  ~~~

  Respuesta JSON ejemplo:
  ~~~
    {
        "ok": true,
        "message": "Usuario creado correctamente",
        "data": {
            "username": "ivan",
            "amount": 1200
        }
    }
  ~~~

- `PUT /api/users`  
  Actualiza los datos de un usuario existente.

  Ejemplo Body:
  ~~~
    {
        "username": "ivan",
        "amount": 2000
    }
  ~~~
  Respuesta JSON ejemplo:
  ~~~
    {
        "ok": true,
        "message": "Usuario actualizado correctamente",
        "data": {
            "username": "ivan",
            "amount": 2194
        }
    }
  ~~~

### 🏆 Winning

- `POST /api/winning`  
  Obtemos monto ganado segun datos del frontend.

  Respuesta JSON ejemplo:
  ~~~
    {
        "is_winner": true,
        "amount_won": 50,
        "message": "Haz recibido $50 de ganancia, ¡felicidades!"
    }
  ~~~

