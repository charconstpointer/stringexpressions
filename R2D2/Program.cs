﻿using System;
using System.Diagnostics;
using System.IO;
 using R2D2.Calculator;
 using R2D2.Interfaces;
 using R2D2.Parser;

 namespace R2D2
{
    class Program
    {
        static void Main(string[] args)
        {
            const string expression = "10 / 40 * 3";
            var calculator = CalculatorFactory.Create();
            var result = calculator.Evaluate(expression);
            Console.WriteLine(result);
        }
    }
}