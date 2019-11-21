using System;
using System.Data;
using R2D2.Interfaces;

namespace R2D2.Calculator
{
    public class DatatableExpressionCalculator : IExpressionCalculator
    {
        private readonly DataTable _dataTable;
        private DatatableExpressionCalculator()
        {
            _dataTable = new DataTable();
        }
        public double Evaluate(string expression)
        {
            var evaluation = _dataTable.Compute(expression, string.Empty);
            var evaluationConverted = Convert.ToDouble(evaluation);
            return evaluationConverted;
        }
        
        public static IExpressionCalculator Create() => new DatatableExpressionCalculator();
    }
}