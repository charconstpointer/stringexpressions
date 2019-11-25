using System.Globalization;
using System.IO;
using System.Text;
using R2D2.Interfaces;

namespace R2D2.Parser
{
    public class Tokenizer : ITokenizer
    {
        public Tokenizer(IExpressionCursor cursor)
        {
            
            _cursor = cursor;
            NextChar();
            MoveNext();
        }

        private readonly IExpressionCursor _cursor;
        private char _currentChar;

        public Token Token { get; private set; }

        public double Number { get; private set; }

        private void NextChar()
        {
            var character = _cursor.Read();
            _currentChar = character < 0 ? '\0' : (char) character;
        }

        public static ITokenizer Create(string expression)
        {
            var expressionCursor = ExpressionCursor.Create(expression);
            return new Tokenizer(expressionCursor);
        }
        
        public void MoveNext()
        {
            while (char.IsWhiteSpace(_currentChar))
            {
                NextChar();
            }

            switch (_currentChar)
            {
                case '\0':
                    Token = Token.Eof;
                    return;

                case '+':
                    NextChar();
                    Token = Token.Add;
                    return;

                case '-':
                    NextChar();
                    Token = Token.Subtract;
                    return;

                case '*':
                    NextChar();
                    Token = Token.Multiply;
                    return;

                case '/':
                    NextChar();
                    Token = Token.Divide;
                    return;
            }

            if (!char.IsDigit(_currentChar) && _currentChar != '.')
                throw new InvalidDataException($"Unexpected character: {_currentChar}");
            var sb = new StringBuilder();
            var haveDecimalPoint = false;
            while (char.IsDigit(_currentChar) || (!haveDecimalPoint && _currentChar == '.'))
            {
                sb.Append(_currentChar);
                haveDecimalPoint = _currentChar == '.';
                NextChar();
            }

            Number = double.Parse(sb.ToString(), CultureInfo.InvariantCulture);
            Token = Token.Number;
        }
    }
}