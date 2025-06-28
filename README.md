---

# 💎 API para Leitura e Persistência de Dados de Funcionários CSV

Este projeto é uma **API desenvolvida em .NET** com foco em aprimorar conhecimentos sobre a criação e estruturação de APIs utilizando **Clean Architecture**. Ele demonstra a manipulação de arquivos CSV para extração de dados de funcionários e sua posterior persistência em um banco de dados relacional.

---

## Motivação do Projeto

Este projeto foi criado com os seguintes objetivos:

* **Dominar a Clean Architecture**: Aprender a estruturar um projeto de forma organizada e escalável, separando as preocupações em camadas distintas (Domain, Service, Repository, Controller).
* **Aprofundar em Desenvolvimento de APIs .NET**: Praticar a criação de controladores, serviços, domínios e repositórios, entendendo suas interações e responsabilidades.
* **Manipulação de Documentos CSV**: Adquirir experiência na leitura e processamento de arquivos CSV, extraindo informações relevantes para serem utilizadas pela aplicação.

---

## Fluxo da API

A API segue o seguinte fluxo para processar e persistir os dados dos funcionários:

1.  **Recebimento do Arquivo CSV**: O endpoint `POST /LerCSVFuncionario/salvarFuncionarioCSV` recebe um documento CSV contendo os dados dos funcionários.
2.  **Tratamento do Documento**: O método `LerArquivoCSV` da `LerAquivoCSVFuncionariosServices` é responsável por processar o documento CSV recebido.
3.  **Leitura e Mapeamento**: A `LerAquivoCSVFuncionariosServices` encaminha o documento para o `CSVFuncionariosReader`, que lê o conteúdo do CSV e retorna uma lista de objetos de funcionários.
4.  **Persistência no Banco de Dados**: Cada funcionário da lista retornada pelo `CSVFuncionariosReader` é então enviado para o método `PostFuncionarios` do `FuncionariosRepository`, salvando os dados em um banco de dados MySQL.
5.  **Consulta de Dados Persistidos**: Após a persistência, um segundo método do repositório, `GetAllFuncionarios`, é chamado para trazer uma lista atualizada de todos os funcionários do banco de dados.
6.  **Retorno da Resposta**: Essa lista de funcionários é então retornada pela `LerAquivoCSVFuncionariosServices`, finalizando a resposta ao endpoint `POST /LerCSVFuncionario/salvarFuncionarioCSV`.
