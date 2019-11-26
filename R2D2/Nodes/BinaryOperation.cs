using System;
using R2D2.Interfaces;

namespace R2D2.Nodes
{
    /// <summary>
    /// Represents two operands operation
    /// </summary>
    public class BinaryOperation : INode
    {
        private INode Left { get; }
        private INode Right { get; }
        private Func<double, double, double> Operation { get; }

        public BinaryOperation(INode left, INode right, Func<double, double, double> operation)
        {
            Left = left;
            Right = right;
            Operation = operation;
        }
        public double Evaluate() => Operation(Left.Evaluate(), Right.Evaluate());
    }
}