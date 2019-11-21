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
            var parser = new ExpressionParser();
            var calculator = new ExpressionCalculator(parser);
            var result = calculator.Evaluate(expression);
//            var tokenizer = new Tokenizer(new ExpressionCursor(expression));
//            var parser = new ExpressionParser(tokenizer);
            Console.WriteLine(result);
        }
    }
}