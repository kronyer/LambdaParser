using LambdaParser;

namespace LambdaParserTesting
{
    public class ParserTests
    {
        [TestCase(@"\x. x", "Abs(x,Var(x))")]
        [TestCase(@"\x. x x", "Abs(x,App(Var(x),Var(x)))")]
        [TestCase(@"\x. \y. x y", "Abs(x,Abs(y,App(Var(x),Var(y))))")]
        [TestCase(@"(\x. x) y", "App(Abs(x,Var(x)),Var(y))")]
        [TestCase(@"(\x. x x) (\x. x x)", "App(Abs(x,App(Var(x),Var(x))),Abs(x,App(Var(x),Var(x))))")]
        [TestCase(@"\x. \y. \z. x (y z)", "Abs(x,Abs(y,Abs(z,App(Var(x),App(Var(y),Var(z))))))")]
        [TestCase(@"x y z", "App(App(Var(x),Var(y)),Var(z))")]
        public void Parser_Generates_Correct_AST(string input, string expectedAst)
        {
            var lexer = new Lexer(input);
            var parser = new Parser(lexer);
            Expr ast = parser.Parse();

            string astString = AstToString(ast);
            Assert.That(astString, Is.EqualTo(expectedAst));        }

        private string AstToString(Expr expr)
        {
            return expr switch
            {
                Var v => $"Var({v.Name})",
                Abs a => $"Abs({a.Param},{AstToString(a.Body)})",
                App app => $"App({AstToString(app.Func)},{AstToString(app.Arg)})",
                _ => "?"
            };
        }
    }
}