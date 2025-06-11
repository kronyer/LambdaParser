namespace LambdaParser;

public class Var : Expr
{
    public string Name { get; }
    public Var(string name) => Name = name;
}