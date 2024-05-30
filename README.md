# README - API de Caderneta Vacinal

## Visão Geral

A API de Caderneta Vacinal é projetada para simplificar o trabalho dos agentes das Unidades Básicas de Saúde (UBS), aprimorando o sistema de cadastro de pacientes e suas informações de vacinação. Este sistema robusto oferece um CRUD (Create, Read, Update, Delete) com controle de acesso rigoroso, garantindo que os dados sejam gerenciados de forma segura e eficiente.

## Funcionalidades

- **Cadastro de Pacientes:** Permite o registro de novos pacientes com informações detalhadas sobre suas vacinas.
- **Consulta de Informações:** Facilita a consulta das informações de vacinação dos pacientes cadastrados.
- **Atualização de Dados:** Agentes da UBS podem atualizar os registros que criaram; administradores podem atualizar qualquer registro.
- **Exclusão de Registros:** Agentes da UBS podem excluir os registros que criaram; administradores podem excluir qualquer registro.
- **Acesso Multi-Dispositivo:** A API pode ser acessada tanto via mobile quanto desktop.

## Tipos de Usuários

- **Administrador:**
  - Permissões: Criar, ler, atualizar e excluir qualquer registro.
- **Agente da UBS:**
  - Permissões: Criar, ler, atualizar e excluir apenas os registros que criou.

## Endpoints da API

### Autenticação

- **Login**
  - `POST /api/login`
  - Autentica o usuário e retorna um token de acesso.

- **Logout**
  - `POST /api/logout`
  - Encerra a sessão do usuário autenticado.

### Pacientes

- **Criar Paciente**
  - `POST /api/pacientes`
  - Corpo da Requisição:
    ```json
    {
      "nome": "string",
      "data_nascimento": "date",
      "sexo": "string",
      "endereco": "string",
      "telefone": "string"
    }
    ```

- **Listar Pacientes**
  - `GET /api/pacientes`
  - Retorna a lista de pacientes cadastrados.

- **Consultar Paciente**
  - `GET /api/pacientes/{id}`
  - Parâmetros:
    - `id`: ID do paciente.
  - Retorna as informações detalhadas do paciente.

- **Atualizar Paciente**
  - `PUT /api/pacientes/{id}`
  - Parâmetros:
    - `id`: ID do paciente.
  - Corpo da Requisição:
    ```json
    {
      "nome": "string",
      "data_nascimento": "date",
      "sexo": "string",
      "endereco": "string",
      "telefone": "string"
    }
    ```

- **Excluir Paciente**
  - `DELETE /api/pacientes/{id}`
  - Parâmetros:
    - `id`: ID do paciente.

### Vacinas

- **Registrar Vacina**
  - `POST /api/vacinas`
  - Corpo da Requisição:
    ```json
    {
      "paciente_id": "integer",
      "tipo_vacina": "string",
      "data_aplicacao": "date",
      "dose": "string",
      "responsavel_aplicacao": "string"
    }
    ```

- **Listar Vacinas**
  - `GET /api/vacinas`
  - Retorna a lista de vacinas registradas.

- **Consultar Vacina**
  - `GET /api/vacinas/{id}`
  - Parâmetros:
    - `id`: ID da vacina.
  - Retorna as informações detalhadas da vacina.

- **Atualizar Vacina**
  - `PUT /api/vacinas/{id}`
  - Parâmetros:
    - `id`: ID da vacina.
  - Corpo da Requisição:
    ```json
    {
      "paciente_id": "integer",
      "tipo_vacina": "string",
      "data_aplicacao": "date",
      "dose": "string",
      "responsavel_aplicacao": "string"
    }
    ```

- **Excluir Vacina**
  - `DELETE /api/vacinas/{id}`
  - Parâmetros:
    - `id`: ID da vacina.

## Controle de Acesso

- **Administrador:** Tem permissão total para criar, ler, atualizar e excluir qualquer registro.
- **Agente da UBS:** Pode criar novos registros, bem como ler, atualizar e excluir apenas os registros que ele mesmo criou.

## Autenticação

A API utiliza autenticação baseada em tokens. Para acessar os endpoints protegidos, é necessário incluir o token de acesso no cabeçalho da requisição:

```http
Authorization: Bearer {token}
```

## Instalação e Configuração

### Pré-requisitos

- ASP.NET
- C#
- Bootstrap

### Passos

1. Clone o repositório:
   ```sh
   git clone https://github.com/rodrigoo-soouza/cardeneta-vacina
   ```

2. Instale as dependências:
   ```sh
   cd repositorio
   npm install
   ```

3. Configure as variáveis de ambiente no arquivo `.env`.

4. Inicialize o banco de dados:
   ```sh
   npx sequelize db:migrate
   ```

5. Inicie o servidor:
   ```sh
   npm start
   ```

## Contribuição

1. Faça um fork do projeto.
2. Crie uma nova branch:
   ```sh
   git checkout -b minha-feature
   ```
3. Faça suas alterações e commit:
   ```sh
   git commit -m 'Minha nova feature'
   ```
4. Envie para o seu fork:
   ```sh
   git push origin minha-feature
   ```
5. Abra um Pull Request no repositório original.

## Licença

Este projeto é licenciado sob a licença MIT. Veja o arquivo LICENSE para mais detalhes.

---

**Contato:**
Para mais informações ou suporte, entre em contato pelo email suporte@ubsapi.com.br.

---

Este README foi criado para proporcionar uma visão clara e detalhada das funcionalidades da API de Caderneta Vacinal, facilitando seu uso e contribuindo para a eficiência dos agentes das UBS.
