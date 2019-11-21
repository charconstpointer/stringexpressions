using System;
using R2D2.Interfaces;

namespace R2D2.Parser
{
    public class ExpressionCursor : IExpressionCursor
    {
        private readonly string _expression;
        private int _position;

        public ExpressionCursor(string expression)
        {
            Console.WriteLine(expression);
            _expression = expression;
            _position = 0;
        }

        public int Read()
        {
            var span = _expression.AsSpan();
            if (_position < span.Length)
            {
                return span[_position++];
            }

            return -1;
        }

        public static IExpressionCursor Create(string expression)
        {
            return new ExpressionCursor(expression);
        }
    }
}