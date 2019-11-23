using System;
using System.Data;
using System.IO;
using Moq;
using R2D2.Calculator;
using R2D2.Interfaces;
using R2D2.Parser;
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

        public void ExpressionCalculator_ValidExpression_GivesCorrectResult(string expression, double expected)
        {
            var expressionParser = new ExpressionParser();
            var calculator = new ExpressionCalculator(expressionParser);
            var expressionValue = calculator.Evaluate(expression);
            Assert.Equal(expected, Math.Round(expressionValue, 6));
        }
        [Theory]
        [InlineData("4+5*2", 14.0)]
        [InlineData("4+5/2", 6.5)]
        [InlineData("4+5/2-1", 5.5)]
        [InlineData("13*13-13+13/14+14/15*15*15", 366.928571)]
        public void DataTableExpressionCalculator_ValidExpression_GivesCorrectResult(string expression, double expected)
        {
            var calculator = DatatableExpressionCalculator.Create();
            var expressionValue = calculator.Evaluate(expression);
            Assert.Equal(expected, Math.Round(expressionValue, 6));
        }
        
        [Theory]
        [InlineData("a+c*13")]
        public void DataTableExpressionCalculator_InvalidExpression_ThrowsException(string expression)
        {
            var calculator = DatatableExpressionCalculator.Create();
            Assert.Throws<EvaluateException>(() => calculator.Evaluate(expression));
        }
        
        [Theory]
        [InlineData(" + *")]
        public void DataTableExpressionCalculator_IncorrectSyntax_ThrowsException(string expression)
        {
            var calculator = DatatableExpressionCalculator.Create();
            Assert.Throws<SyntaxErrorException>(() => calculator.Evaluate(expression));
        }
        
        [Theory]
        [InlineData("a+c*13")]
        public void ExpressionCalculator_InvalidExpression_ThrowsException(string expression)
        {
            var expressionParser = new ExpressionParser();
            var calculator = new ExpressionCalculator(expressionParser);
            Assert.Throws<InvalidDataException>(() => calculator.Evaluate(expression));
        }
        
        [Theory]
        [InlineData(" + * ")]
        public void ExpressionCalculator_IncorrectSyntax_ThrowsException(string expression)
        {
            var expressionParser = new ExpressionParser();
            var calculator = new ExpressionCalculator(expressionParser);
            Assert.Throws<Exception>(() => calculator.Evaluate(expression));
        }
    }
}