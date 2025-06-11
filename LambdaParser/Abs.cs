namespace LambdaParser;

public class Abs : Expr
{
    public string Param { get; }
    public Expr Body { get; }
    
    public Abs(string param, Expr body)
    {
        Param = param;
        Body = body;
    }
}