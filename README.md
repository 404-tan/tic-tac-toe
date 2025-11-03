#  Guia de Execução Local (Docker Compose)

Este guia detalha como executar a aplicação completa (Backend ASP.NET Core, Frontend Angular e Banco de Dados PostgreSQL) usando o Docker Compose para um ambiente de desenvolvimento isolado.

##  O Projeto: Tic-Tac-Toe (Jogo da Velha)

Este repositório contém uma implementação do clássico jogo de estratégia Tic-Tac-Toe (Jogo da Velha).

* **Regras:** Dois jogadores ('X' e 'O') se revezam preenchendo um tabuleiro 3x3. O objetivo é ser o primeiro a conseguir alinhar três de seus símbolos em uma linha (horizontal, vertical ou diagonal).
* **Arquitetura:**
    * **Frontend (Angular):** Gerencia a interface do tabuleiro e a interação do usuário.
    * **Backend (ASP.NET Core):** Lida com a persistência de dados (gravar resultados de vitória/empate) e a comunicação com o banco de dados.

##  Pré-requisitos

Certifique-se de ter instalado em sua máquina:

1.  **[Docker Desktop](https://www.docker.com/products/docker-desktop/)** (Inclui Docker Engine e Docker Compose).
2.  **[Visual Studio Code (VS Code)](https://code.visualstudio.com/)** com as extensões:
    * **C# Dev Kit** ou **C#** (ms-dotnettools.csharp)
    * **Docker** (ms-azuretools.vscode-docker)

## Como Executar o Projeto

Utilizaremos o arquivo `docker-compose.dev.yml` para orquestrar os três serviços.

### 1. Preparação (Primeira Execução)

Antes de executar, se você fez alterações no `Dockerfile.dev` ou nos arquivos de configuração do Compose, execute o comando de *build* e *up*.

```bash
docker compose -f docker-compose.dev.yml up -d --build
```
### 2. Acessar as páginas:
- Frontend: http://localhost:4200
- API: http://localhost:8080
