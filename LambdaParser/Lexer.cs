namespace LambdaParser;

public class Lexer
{
    private readonly string _input;
    private int _pos;

    public Lexer(string input)
    {
        _input = input;
        _pos = 0;
    }

    public Token NextToken()
    {
        while (_pos < _input.Length && char.IsWhiteSpace(_input[_pos]))
            _pos++;

        if (_pos >= _input.Length)
            return new Token(TokenType.EOF);

        char c = _input[_pos];

        if (c == '\\' || c == 'λ')
        {
            _pos++;
            return new Token(TokenType.Lambda);
        }
        if (c == '.')
        {
            _pos++;
            return new Token(TokenType.Dot);
        }
        if (c == '(')
        {
            _pos++;
            return new Token(TokenType.LPar);
        }
        if (c == ')')
        {
            _pos++;
            return new Token(TokenType.RPar);
        }
        if (char.IsLetter(c))
        {
            int start = _pos;
            while (_pos < _input.Length && char.IsLetterOrDigit(_input[_pos]))
                _pos++;
            string id = _input.Substring(start, _pos - start);
            return new Token(TokenType.Identifier, id);
        }

        throw new Exception($"Caractere inesperado: {c}");
    }
}