using R2D2.Interfaces;

namespace R2D2.Nodes
{
    /// <summary>
    /// Represents a numeric value
    /// </summary>
    public class Number : INode
    {
        public Number(double value)
        {
            Value = value;
        }
        private double Value { get; }
        public double Evaluate() => Value;
    }
}