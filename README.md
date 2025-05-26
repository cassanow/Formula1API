API REST para consulta e gerenciamento de dados da Fórmula 1, atualmente com suporte para as entidades Pilotos e Equipes, desenvolvida em ASP.NET Core utilizando Entity Framework para acesso ao banco de dados.  

A API segue os princípios REST, com endpoints claros e padronizados para operações CRUD.  
Futuramente, serão adicionados recursos para Circuitos e Temporadas.

## Tecnologias Utilizadas

- ASP.NET Core Web API  
- Entity Framework Core (ORM)  
- Banco de dados relacional (ex: SQL Server)  
- Arquitetura REST (Representational State Transfer)  

## Funcionalidades Atuais

- Consulta, criação, atualização e exclusão de Pilotos e Equipes (CRUD)  
- Endpoints RESTful com verbos HTTP adequados (GET, POST, PUT, DELETE)  
- Rotas padronizadas para fácil consumo  
- Validação de dados e tratamento consistente de erros  

## Funcionalidades Futuras

- Implementação de endpoints para Circuitos  
- Implementação de endpoints para Temporadas  

## Estrutura da API

### Pilotos

- GET /pilotos — Lista todos os pilotos  
- GET /pilotos/{id} — Obtém detalhes de um piloto específico  
- POST /pilotos — Adiciona um novo piloto  
- PUT /pilotos/{id} — Atualiza dados de um piloto  
- DELETE /pilotos/{id} — Remove um piloto  

### Equipes

- GET /equipes — Lista todas as equipes  
- GET /equipes/{id} — Obtém detalhes de uma equipe específica  
- POST /equipes — Adiciona uma nova equipe  
- PUT /equipes/{id} — Atualiza dados de uma equipe  
- DELETE /equipes/{id} — Remove uma equipe  

*(Em breve: endpoints para Circuitos e Temporadas)*
