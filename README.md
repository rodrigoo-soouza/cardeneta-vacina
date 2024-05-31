# README - Aplicação Web Caderneta Vacinal

## Visão Geral

A Aplicação de Caderneta Vacinal é projetada para simplificar o trabalho dos agentes das Unidades Básicas de Saúde (UBS), aprimorando o sistema de cadastro de pacientes e suas informações de vacinação. Este sistema robusto oferece um CRUD (Create, Read, Update, Delete) com controle de acesso rigoroso, garantindo que os dados sejam gerenciados de forma segura e eficiente.

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

## Endpoints da Aplicação nos Controllers

### Autenticação

- **Login**
  - `POST /login`
  - Autentica o usuário e retorna um token de acesso.

- **Logout**
  - `POST /logout`
  - Encerra a sessão do usuário autenticado.

### Pacientes

- **Criar Paciente**
  - `POST /pacientes`
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
### Modelo (Model):
Representa os dados e a lógica de negócios por trás da aplicação. Ele gerencia o comportamento e os dados da aplicação, respondendo a consultas sobre seu estado e alterando esse estado quando apropriado. Em muitos casos, os modelos são conectados a um banco de dados para armazenar e recuperar informações.

### Visão (View):
É a camada de apresentação da aplicação. Ele exibe as informações ao usuário e fornece uma interface com a qual o usuário pode interagir. As visões geralmente são responsáveis por formatar os dados do modelo de maneira adequada para exibição.

### Controlador (Controller):
Age como um intermediário entre o modelo e a visão. Ele recebe as entradas do usuário, processa essas entradas (frequentemente invocando métodos no modelo) e atualiza a visão de acordo. O controlador geralmente contém a lógica que coordena o fluxo de controle da aplicação.

A arquitetura MVC promove a separação de preocupações, facilitando a manutenção e a escalabilidade do código. Por exemplo, se você precisar fazer alterações na interface do usuário, pode mexer apenas na camada de visualização, sem precisar modificar a lógica de negócios subjacente no modelo ou no controlador. Isso também facilita o teste, já que cada componente pode ser testado separadamente.


- **Listar Pacientes**
  - `GET /pacientes`
  - Retorna a lista de pacientes cadastrados.

- **Consultar Paciente**
  - `GET /api/pacientes/{id}`
  - Parâmetros:
    - `id`: ID do paciente.
  - Retorna as informações detalhadas do paciente.

- **Atualizar Paciente**
  - `PUT /pacientes/{id}`
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
  - `DELETE /pacientes/{id}`
  - Parâmetros:
    - `id`: ID do paciente.

### Vacinas

- **Registrar Vacina**
  - `POST /vacinas`
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
  - `GET /vacinas`
  - Retorna a lista de vacinas registradas.

- **Consultar Vacina**
  - `GET /vacinas/{id}`
  - Parâmetros:
    - `id`: ID da vacina.
  - Retorna as informações detalhadas da vacina.

- **Atualizar Vacina**
  - `PUT /vacinas/{id}`
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
  - `DELETE /vacinas/{id}`
  - Parâmetros:
    - `id`: ID da vacina.

## Controle de Acesso

- **Administrador:** Tem permissão total para criar, ler, atualizar e excluir qualquer registro.
- **Agente da UBS:** Pode criar novos registros, bem como ler, atualizar e excluir apenas os registros que ele mesmo criou.

## Autenticação

A Web Aplicação utiliza autenticação baseada em autorização e autenticação. Para acessar os controllers protegidos, é necessário seguir as políticas de acesso e autorização:

```
Microsoft.AspNetCore.Identity.EntityFrameworkCore
```

## Instalação e Configuração

### Tecnologias Utilizadas

- ASP.NET 
- C#
- Html e CSS
- Bootstrap 5

### Passos

1. Clone o repositório:
   ```sh
   git clone https://github.com/rodrigoo-soouza/cardeneta-vacina
   ```

2. Instale os pacotes com as referências:
   ```sh
   
   pacotes Dotnet da Microsoft
   "Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore" Version="7.0.16"
   "Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="7.0.16"
   "Microsoft.AspNetCore.Identity.UI" Version="7.0.16"
   "Microsoft.EntityFrameworkCore" Version="7.0.19"
   "Microsoft.EntityFrameworkCore.Design" Version="7.0.19"
   "Microsoft.EntityFrameworkCore.SqlServer" Version="7.0.16"
   "Microsoft.EntityFrameworkCore.Tools" Version="7.0.18"
   "Microsoft.VisualStudio.Web.CodeGeneration" Version="7.0.12"
   "Microsoft.VisualStudio.Web.CodeGeneration.Design" Version="7.0.12"
   ```

3. Configure e gere as chaves e segredos no Azure para proteger a Connection String.

4. Inicialize o banco de dados:
   ```sh
   Banco de dados SQL Server com uso de migrações
   ```

5. Inicie o servidor:
   ```sh
   Inicializado numa Web Application MVC, deploy para modo de produção na Azure.  
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
