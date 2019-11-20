using R2D2.Interfaces;

namespace R2D2
{
    public class NodeNumber : INode
    {
        public NodeNumber(double value)
        {
            Value = value;
        }
        private double Value { get; }
        public double Eval() => Value;
    }
}