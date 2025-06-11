using LambdaParser;

string input = @"x y z";
var lexer = new Lexer(input);
var parser = new Parser(lexer);
Expr ast = parser.Parse();

Console.WriteLine("AST gerada com sucesso!");

PrintAst(ast);
PrintAstBfs(ast);



void PrintAst(Expr expr, int indent = 0)
{
    string pad = new string(' ', indent);
    switch (expr)
    {
        case Var v:
            Console.WriteLine($"{pad}Var({v.Name})");
            break;
        case Abs a:
            Console.WriteLine($"{pad}Abs({a.Param})");
            PrintAst(a.Body, indent + 2);
            break;
        case App app:
            Console.WriteLine($"{pad}App(");
            PrintAst(app.Func, indent + 2);
            PrintAst(app.Arg, indent + 2);
            Console.WriteLine($"{pad})");
            break;
    }
    
   
}



void PrintAstBfs(Expr root)
{
    var queue = new Queue<(Expr expr, int level)>();
    queue.Enqueue((root, 0));
    int lastLevel = -1;

    while (queue.Count > 0)
    {
        var (expr, level) = queue.Dequeue();
        if (level != lastLevel)
        {
            Console.WriteLine($"Nível {level}:");
            lastLevel = level;
        }

        switch (expr)
        {
            case Var v:
                Console.WriteLine($"  Var({v.Name})");
                break;
            case Abs a:
                Console.WriteLine($"  Abs({a.Param})");
                queue.Enqueue((a.Body, level + 1));
                break;
            case App app:
                Console.WriteLine("  App");
                queue.Enqueue((app.Func, level + 1));
                queue.Enqueue((app.Arg, level + 1));
                break;
        }
    }
}