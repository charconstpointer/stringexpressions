﻿using System;
using R2D2.Interfaces;

namespace R2D2
{
    public class ExpressionParser
    {
        private readonly ITokenizer _tokenizer;

        public ExpressionParser(ITokenizer tokenizer)
        {
            _tokenizer = tokenizer;
        }

        public INode Parse()
        {
            var expression = ParseAddSubtract();

            if (_tokenizer.Token != Token.Eof)
                throw new Exception("Unexpected characters at end of expression");

            return expression;
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
                _tokenizer.NextToken();
                var right = ParseUnary();
                left = new NodeBinary(left, right, operation);
            }
        }

        private INode ParseUnary()
        {
            switch (_tokenizer.Token)
            {
                case Token.Add:
                    _tokenizer.NextToken();
                    return ParseUnary();
                case Token.Subtract:
                {
                    _tokenizer.NextToken();
                    var right = ParseUnary();
                    return new NodeUnary(right, a => -a);
                }
                default:
                    return ParseLeaf();
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
                _tokenizer.NextToken();
                var right = ParseMultiplyDivide();
                left = new NodeBinary(left, right, operation);
            }
        }

        private INode ParseLeaf()
        {
            if (_tokenizer.Token != Token.Number) throw new Exception($"Unexpect token: {_tokenizer.Token}");
            var node = new NodeNumber(_tokenizer.Number);
            _tokenizer.NextToken();
            return node;
        }
    }
}