using System.Threading;
using System.Threading.Tasks;
using MediatR;
using R2D2.Commands;
using R2D2.Interfaces;

namespace R2D2.Handlers
{
    public class EvaluateExpressionHandler : IRequestHandler<EvaluateExpression, double>
    {
        private readonly IExpressionCalculator _calculator;

        public EvaluateExpressionHandler(IExpressionCalculator calculator)
        {
            _calculator = calculator;
        }

        public Task<double> Handle(EvaluateExpression request, CancellationToken cancellationToken)
        {
            var value = _calculator.Evaluate(request.Expression);
            return Task.FromResult(value);
        }
    }
}