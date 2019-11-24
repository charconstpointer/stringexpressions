using R2D2.Interfaces;
using R2D2.Parser;

namespace R2D2.Calculator
{
    public class ExpressionCalculator : IExpressionCalculator
    {
        private readonly IExpressionParser _parser;

        public ExpressionCalculator(IExpressionParser parser)
        {
            _parser = parser;
        }

        public double Evaluate(string expression)
        {
            var expressionTree = _parser.Parse(expression);
            return expressionTree.Evaluate();
        }
    }
}