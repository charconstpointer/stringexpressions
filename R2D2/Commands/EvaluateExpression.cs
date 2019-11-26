using MediatR;

namespace R2D2.Commands
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class EvaluateExpression : IRequest<double>
    {
        public string Expression { get; set; }
    }
}