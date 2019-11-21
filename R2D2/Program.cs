﻿using System;
 using R2D2.Calculator;

 namespace R2D2
{
    class Program
    {
        static void Main()
        {
            const string expression = "10 / 40 * 3";
            var calculator = ExpressionCalculator.Create();
            var dataTableCalculator = DatatableExpressionCalculator.Create();
            var result = calculator.Evaluate(expression);
            var anotherResult = dataTableCalculator.Evaluate(expression);
            Console.WriteLine($"{result}, {anotherResult}");
        }
    }
}