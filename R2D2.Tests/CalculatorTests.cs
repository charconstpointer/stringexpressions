using System;
using R2D2.Interfaces;
using Xunit;

namespace R2D2.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData("4+5*2", 14.0)]
        [InlineData("4+5/2", 6.5)]
        [InlineData("4+5/2-1", 5.5)]
        [InlineData("13*13-13+13/14+14/15*15*15", 366.928571)]

        public void ExpressionParser_ValidExpression_GivesCorrectResult(string expression, double expected)
        {
            var tokenizer = new Tokenizer(new ExpressionCursor(expression));
            var calculator = new ExpressionParser(tokenizer);
            var expressionValue = calculator.Parse().Eval();
            Assert.Equal(expected, Math.Round(expressionValue, 6));
        }
    }
}