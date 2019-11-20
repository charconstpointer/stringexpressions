using System;
using R2D2.Interfaces;

namespace R2D2
{
    internal class NodeUnary : INode
    {
        public NodeUnary(INode right, Func<double, double> operation)
        {
            Right = right;
            Operation = operation;
        }

        private INode Right { get; }
        private Func<double,double> Operation { get; }
        public double Eval() => Operation(Right.Eval());
    }
}