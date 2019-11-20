using System;
using R2D2.Interfaces;

namespace R2D2.Nodes
{
    public class NodeBinary : INode
    {
        private INode Left { get; }
        private INode Right { get; }
        private Func<double, double, double> Operation { get; }

        public NodeBinary(INode left, INode right, Func<double, double, double> operation)
        {
            Left = left;
            Right = right;
            Operation = operation;
        }
        public double Evaluate() => Operation(Left.Evaluate(), Right.Evaluate());
    }
}