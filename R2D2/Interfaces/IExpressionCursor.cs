﻿using System;

namespace R2D2.Interfaces
{
    public interface IExpressionCursor
    {
        int Read();
        int Read(ReadOnlySpan<char> expression);
    }

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

        public int Read(ReadOnlySpan<char> expression)
        {
            if (_position < expression.Length)
            {
                return expression[_position++];
            }

            return -1;
        }
    }
}