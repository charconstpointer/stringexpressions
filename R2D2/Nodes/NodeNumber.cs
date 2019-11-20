using R2D2.Interfaces;

namespace R2D2.Nodes
{
    public class NodeNumber : INode
    {
        public NodeNumber(double value)
        {
            Value = value;
        }
        private double Value { get; }
        public double Evaluate() => Value;
    }
}