using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using R2D2.Commands;
using R2D2.Interfaces;

namespace R2D2.Handlers
{
    public class EvaluateExpressionHandler : IRequestHandler<EvaluateExpressionCommand, double>
    {
        private readonly IExpressionCalculator _calculator;
        private readonly IMemoryCache _cache;

        public EvaluateExpressionHandler(IExpressionCalculator calculator, IMemoryCache cache)
        {
            _calculator = calculator;
            _cache = cache;
        }

        public Task<double> Handle(EvaluateExpressionCommand request, CancellationToken cancellationToken)
        {
            if (_cache.TryGetValue(request.Expression, out var cachedValue))
            {
                return Task.FromResult((double) cachedValue);
            }

            var value = _calculator.Evaluate(request.Expression);
            _cache.Set(request.Expression, value, TimeSpan.FromMinutes(5));
            return Task.FromResult(value);
        }
    }
}