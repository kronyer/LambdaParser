# LambdaParser

Este projeto é um interpretador e parser para expressões lambda, desenvolvido em C#.

## Estrutura do Projeto

- **LambdaParser/**: Contém a implementação principal do parser, incluindo as classes para análise léxica, sintática e representação das expressões lambda.
  - `Lexer.cs`: Responsável pela análise léxica (tokenização) das entradas.
  - `Token.cs` e `TokenType.cs`: Definem os tipos de tokens utilizados pelo lexer.
  - `Expr.cs`, `Abs.cs`, `App.cs`, `Var.cs`: Representam as diferentes formas de expressões lambda (abstração, aplicação e variáveis).
  - `Program.cs`: Ponto de entrada do programa.
  - `LambdaParser.csproj`: Arquivo de configuração do projeto C#.

- **LambdaParserTesting/**: Projeto de testes unitários para garantir o correto funcionamento do parser e interpretador.
  - `UnitTest1.cs`: Contém testes automatizados.
  
## Como Executar

1. Certifique-se de ter o .NET 9.0 SDK instalado.
2. Compile o projeto principal:
   ```bash
   dotnet build LambdaParser/LambdaParser.csproj
   ```
3. Execute o programa:
   ```bash
   dotnet run --project LambdaParser/LambdaParser.csproj
   ```
4. Para rodar os testes:
   ```bash
   dotnet test LambdaParserTesting/LambdaParserTesting.csproj
   ```

## Funcionalidades
- Tokenização de expressões lambda.
- Parsing de expressões para AST (Abstract Syntax Tree).
- Interpretação e avaliação de expressões lambda.
- Testes automatizados para validação das funcionalidades.

## Exemplo de Uso

```text
(λx.x) y
```

## Licença

Este projeto é distribuído sob a licença GNU GPL.
