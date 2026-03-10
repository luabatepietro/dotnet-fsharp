# PROJETO ETL 

### 1.1 Configuração do ambiente 

```bash
dotnet new solution -n ProjetoETL

dotnet new classlib --language F# -o Biblioteca
dotnet sln add Biblioteca

dotnet new console --language F# -o App
dotnet sln add App

dotnet add reference ../Biblioteca

dotnet new xunit --language F# -o Testes
dotnet sln add Testes

dotnet add reference ../Biblioteca
```

Cria uma solution .NET chamada ProjetoETL. Depois cria três projetos em F#:
- Biblioteca: onde fica a lógica do ETL.
- App (console): executa o ETL usando a biblioteca.
- Testes (xUnit): para testar o código da biblioteca.

Por fim, adiciona os projetos à solution e cria referências para que App e Testes possam usar a Biblioteca.