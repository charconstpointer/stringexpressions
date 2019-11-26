using System;
using R2D2.Interfaces;
using R2D2.Nodes;

namespace R2D2.Parser
{
    public interface IExpressionParser
    {
        INode Parse(string expression);
    }

    public class ExpressionParser : IExpressionParser
    {
        private ITokenizer _tokenizer;

        public static IExpressionParser Create() => new ExpressionParser();

        public INode Parse(string expression)
        {
            _tokenizer = Tokenizer.Create(expression);
            var root = ParseAddSubtract();

            if (_tokenizer.Token != Token.Eof)
                throw new Exception("Invalid expression");

            return root;
        }

        private INode ParseMultiplyDivide()
        {
            var left = ParseUnary();
            while (true)
            {
                Func<double, double, double> operation = _tokenizer.Token switch
                {
                    Token.Multiply => ((a, b) => a * b),
                    Token.Divide => ((a, b) => a / b),
                    _ => null
                };

                if (operation == null) return left;
                _tokenizer.MoveNext();
                var right = ParseUnary();
                left = new BinaryOperation(left, right, operation);
            }
        }

        private INode ParseUnary()
        {
            switch (_tokenizer.Token)
            {
                case Token.Add:
                    _tokenizer.MoveNext();
                    return ParseUnary();
                case Token.Subtract:
                {
                    _tokenizer.MoveNext();
                    var right = ParseUnary();
                    return new UnaryOperation(right, a => -a);
                }
                default:
                    return ParseToken();
            }
        }

        private INode ParseAddSubtract()
        {
            var left = ParseMultiplyDivide();

            while (true)
            {
                Func<double, double, double> operation = _tokenizer.Token switch
                {
                    Token.Add => ((a, b) => a + b),
                    Token.Subtract => ((a, b) => a - b),
                    _ => null
                };

                if (operation == null) return left;
                _tokenizer.MoveNext();
                var right = ParseMultiplyDivide();
                left = new BinaryOperation(left, right, operation);
            }
        }

        private INode ParseToken()
        {
            if (_tokenizer.Token != Token.Number) throw new Exception($"Unexpect token: {_tokenizer.Token}");
            var node = new Number(_tokenizer.Number);
            _tokenizer.MoveNext();
            return node;
        }
    }
}