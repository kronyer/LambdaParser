namespace LambdaParser;

public class App : Expr
{
    public Expr Func { get; }
    public Expr Arg { get; }
    
    public App(Expr func, Expr arg)
    {
        Func = func;
        Arg = arg;
    }
}

public class Parser
{
    private readonly Lexer _lexer;
    private Token _current;

    public Parser(Lexer lexer)
    {
        _lexer = lexer;
        _current = _lexer.NextToken();
    }

    private void Eat(TokenType type)
    {
        if (_current.Type == type)
            _current = _lexer.NextToken();
        else
            throw new Exception($"Esperado {type}, encontrado {_current.Type}");
    }

    public Expr Parse()
    {
        return ParseExpr();
    }

    private Expr ParseExpr()
    {
        Expr expr = ParseAtom();
        while (_current.Type == TokenType.Identifier || _current.Type == TokenType.LPar || _current.Type == TokenType.Lambda)
        {
            expr = new App(expr, ParseAtom());
        }
        return expr;
    }

    private Expr ParseAtom()
    {
        if (_current.Type == TokenType.Lambda)
        {
            Eat(TokenType.Lambda);
            string param = _current.Value!;
            Eat(TokenType.Identifier);
            Eat(TokenType.Dot);
            Expr body = ParseExpr();
            return new Abs(param, body);
        }
        else if (_current.Type == TokenType.Identifier)
        {
            string name = _current.Value!;
            Eat(TokenType.Identifier);
            return new Var(name);
        }
        else if (_current.Type == TokenType.LPar)
        {
            Eat(TokenType.LPar);
            Expr expr = ParseExpr();
            Eat(TokenType.RPar);
            return expr;
        }
        else
        {
            throw new Exception("Expressão inesperada");
        }
    }
}



