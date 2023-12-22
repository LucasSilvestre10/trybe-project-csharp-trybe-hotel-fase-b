 # Trybe Hotel - Fase B 

### Requisito 1 - Implementação das Models da Aplicação

Neste primeiro passo, todas as models foram implementadas no diretório `/src/TrybeHotel/Models/`, utilizando como base o projeto da fase anterior. As models existentes foram copiadas, e duas novas models, `User` e `Booking`, foram adicionadas conforme as especificações do diagrama de entidade-relacionamento.

**O que foi feito:**

- Models foram implementadas, aproveitando a estrutura do projeto anterior.
- Chaves primárias e estrangeiras foram definidas adequadamente.

---

### Requisito 2 - Desenvolvimento do Endpoint POST /user

No segundo requisito, foi criado o endpoint responsável por inserir uma nova pessoa usuária. A lógica da controller no método `Add()` e a interação com o banco de dados no método `Add()` da `UserRepository.cs` foram implementadas. As classes `UserDto` para a resposta e `UserDtoInsert` para o corpo da requisição foram criadas.

**O que foi feito:**

1. Inserção inválida de pessoa usuária com e-mail repetido.
   - Status 409 e corpo da resposta com a mensagem "User email already exists".
   
2. Inserção bem-sucedida de pessoa usuária.
   - Status 201 e corpo da resposta com os detalhes da pessoa usuária cadastrada.
   ```json
   {
      "userId": 1,
      "name": "Rebeca",
      "email": "rebeca.santos@trybehotel.com",
      "userType": "client"
   }
   ```

---

### Requisito 3 - Desenvolvimento do Endpoint POST /login

No terceiro requisito, foi implementado o endpoint responsável por realizar o login. A lógica da controller no método `Login()` e a interação com o banco de dados no método `Login()` da `UserRepository.cs` foram desenvolvidas. A classe `LoginDto` foi criada para o corpo da requisição.

**O que foi feito:**

1. Tentativa de login com credenciais incorretas.
   - Status 401 e corpo da resposta com a mensagem "Incorrect e-mail or password".
   
2. Login bem-sucedido.
   - Status 200 e corpo da resposta com o token gerado.
   ```json
   {
      "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJyb2xlIjoiYWRtaW4iLCJlbWFpbCI6ImRhbmlsby5zaWx2YUBiZXRyeWJlLmNvbSIsIm5iZiI6MTY4ODQxMTIxMiwiZXhwIjoxNjg4NDk3NjEyLCJpYXQiOjE2ODg0MTEyMTJ9.q1cNj2_xspeQC6Uz1maV79P95hVtWH4Z7auZgOen-Qo"
   }
   ```

---

### Requisito 4 - Adição da Autorização de Admin no Endpoint POST /hotel

O quarto requisito envolveu a adição da permissão de admin ao endpoint já desenvolvido na fase anterior. A política `Admin` foi criada no arquivo `src/TrybeHotel/Program.cs`, e a autorização foi adicionada no controller `HotelController.cs`.

**O que foi feito:**

1. Realização de operações do endpoint com a autorização de admin.
2. Status proibido se o acesso não for admin.
3. Status não autorizado se o acesso não existir.

---

### Requisito 5 - Adição da Autorização de Admin no Endpoint POST /room

No quinto requisito, a permissão de admin foi adicionada ao endpoint já desenvolvido. Seguindo as instruções, a política `Admin` foi criada e a autorização foi incluída no controller `RoomController.cs`.

**O que foi feito:**

1. Realização de operações do endpoint com a autorização de admin.
2. Status proibido se o acesso não for admin.
3. Status não autorizado se o acesso não existir.

---

### Requisito 6 - Adição da Autorização de Admin no Endpoint DELETE /room

No sexto requisito, a permissão de admin foi acrescentada ao endpoint de exclusão de quartos. A política `Admin` foi criada, e a autorização foi implementada no controller `RoomController.cs`.

**O que foi feito:**

1. Realização de operações do endpoint com a autorização de admin.
2. Status proibido se o acesso não for admin.
3. Status não autorizado se o acesso não existir.

---

### Requisito 7 - Desenvolvimento do Endpoint POST /booking

No sétimo requisito, foi implementado o endpoint responsável por inserir uma nova reserva. A lógica da controller no método `Add()` e a interação com o banco de dados no método `Add()` da `BookingRepository.cs` foram desenvolvidas. A classe `BookingDtoInsert` foi criada para o corpo da requisição, e `BookingResponse` para a resposta.

**O que foi feito:**

1. Tentativa de inserção de reserva com quantidade de hóspedes maior do que a capacidade do quarto.
   - Status 400 e corpo da resposta com a mensagem "Guest quantity over room capacity".
   
2. Inserção bem-sucedida de nova reserva.
   - Status 201 e corpo da resposta com os detalhes da reserva.
   ```json
   {
      "bookingId": 1,
      "checkIn": "2030-08-27T00:00:00",
      "checkOut": "2030-08-28T00:00:00",
      "guestQuant": 1,
      "room": {
         "roomId": 1,
         "name": "Suite básica",
         "capacity": 2,
         "image": "image suite",
         "hotel": {
            "hotelId": 1,
            "name": "Trybe Hotel RJ",
            "address": "Avenida Atlântica, 1400",
            "cityId": 1,
            "cityName": "Rio de Janeiro"
         }
      }
   }
   ```

---

### Requisito 8 - Desenvolvimento do Endpoint GET /booking

No oitavo requisito, foi implementado o endpoint responsável por listar uma única reserva. A lógica da controller no método `GetBooking()` e a interação com o banco de dados no método `GetBooking()` da `BookingRepository.cs` foram desenvolvidas.

**O que foi feito:**

1. Tentativa de consulta de reserva com credencial inválida.
   - Status 401.
   
2. Consulta bem

-sucedida de reserva.
   - Status 200 e corpo da resposta com os detalhes da reserva.
   ```json
   {
      "bookingId": 1002,
      "checkIn": "2023-08-27T00:00:00",
      "checkOut": "2023-08-28T00:00:00",
      "guestQuant": 1,
      "room": {
         "roomId": 1,
         "name": "Suite básica",
         "capacity": 2,
         "image": "image suite",
         "hotel": {
            "hotelId": 1,
            "name": "Trybe Hotel RJ",
            "address": "Avenida Atlântica, 1400",
            "cityId": 1,
            "cityName": "Rio de Janeiro"
         }
      }
   }
   ```

---

### Requisito 9 - Desenvolvimento do Endpoint GET /user

No nono requisito, foi desenvolvido o endpoint responsável por listar todas as pessoas usuárias. A lógica da controller no método `GetUsers()` e a interação com o banco de dados no método `GetUsers()` da `UserRepository.cs` foram implementadas.

**O que foi feito:**

1. Tentativa de consulta de pessoas usuárias com credencial inválida.
   - Status 401.
   
2. Consulta bem-sucedida de pessoas usuárias.
   - Status 200 e corpo da resposta com os detalhes das pessoas usuárias.
   ```json
   [
      {
         "userId": 1,
         "name": "Rebeca",
         "email": "rebeca.santos@trybehotel.com",
         "userType": "client"
      },
      /*...*/
   ]
   ```
