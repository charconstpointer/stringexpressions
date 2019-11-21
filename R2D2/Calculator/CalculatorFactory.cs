using R2D2.Interfaces;

namespace R2D2.Calculator
{
    public static class CalculatorFactory
    {
        public static IExpressionCalculator Create() => new ExpressionCalculator();
    }
}