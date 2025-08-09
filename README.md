# 💎 API para Leitura e Persistência de Dados de Funcionários CSV

Este projeto é uma **API desenvolvida em .NET** com foco em aprimorar conhecimentos sobre a criação e estruturação de APIs utilizando **Clean Architecture**. Ele demonstra a manipulação de arquivos CSV para extração de dados de funcionários e sua posterior persistência em um banco de dados relacional.

---

## ✨ Features

*   Leitura de dados de funcionários a partir de arquivos CSV.
*   Persistência de dados em um banco de dados relacional.
*   Arquitetura limpa para um código organizado e escalável.
*   Endpoints para verificar o status da aplicação e para fazer o upload do arquivo CSV.

---

## 🛠️ Technologies Used

*   [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
*   [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
*   [MySQL](https://www.mysql.com/)
*   [Docker](https://www.docker.com/)

---

## 🚀 Getting Started

### Prerequisites

Para executar este projeto, você precisará ter as seguintes ferramentas instaladas em sua máquina:

*   [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
*   [Docker](https://www.docker.com/products/docker-desktop/) (Opcional, para execução com Docker)
*   Um cliente SQL de sua preferência (como [DBeaver](https://dbeaver.io/) ou [MySQL Workbench](https://www.mysql.com/products/workbench/))

### Running the project with Docker

A maneira mais simples de executar o projeto é usando o Docker. Com o Docker em execução, basta executar o seguinte comando na raiz do projeto:

```bash
docker-compose up -d
```

A API estará disponível em `http://localhost:8080`.

### Running the project locally

Se preferir executar o projeto localmente sem o Docker, siga estas etapas:

1.  **Clone o repositório:**

    ```bash
    git clone https://github.com/seu-usuario/seu-repositorio.git
    cd seu-repositorio
    ```

2.  **Configure a string de conexão:**

    Abra o arquivo `appsettings.json` e atualize a string de conexão do MySQL com suas credenciais.

3.  **Execute as migrações do banco de dados:**

    ```bash
    dotnet ef database update
    ```

4.  **Execute a aplicação:**

    ```bash
    dotnet run --project ApiLerCSVFuncionario/ApiLerCSVFuncionario.API.csproj
    ```

A API estará disponível em `http://localhost:5000` (ou outra porta, dependendo da sua configuração).

---

## Endpoints da API

A API possui os seguintes endpoints:

### Checar Status da Aplicação

*   **GET** `/on`

    Retorna uma mensagem indicando que o servidor está online.

    **Exemplo de Resposta:**

    ```json
    {
      "success": true,
      "message": "Servidor esta online"
    }
    ```

### Salvar Funcionários via CSV

*   **POST** `/salvarFuncionarioCSV`

    Recebe um arquivo CSV com os dados dos funcionários, processa o arquivo e salva os dados no banco de dados.

    **Corpo da Requisição:**

    *   `fileCSV`: O arquivo CSV a ser processado.

    **Exemplo de Resposta (Sucesso):**

    ```json
    {
      "success": true,
      "data": [
        {
          "id": 1,
          "nome": "João da Silva",
          "cargo": "Desenvolvedor"
        }
      ]
    }
    ```

---

## 📂 Project Structure

O projeto utiliza os princípios da Clean Architecture para separar as responsabilidades em diferentes camadas:

*   **`ApiLerCSVFuncionario.API`**: A camada de apresentação, responsável por expor os endpoints da API.
*   **`ApiLerCSVFuncionario.Aplications`**: A camada de aplicação, que contém a lógica de negócios da aplicação.
*   **`APILerCSVFuncionario.Domain`**: A camada de domínio, que contém as entidades, DTOs e interfaces.
*   **`ApiLerCSVFuncionario.Infrastructure`**: A camada de infraestrutura, responsável pela comunicação com recursos externos, como o banco de dados e o sistema de arquivos.

---