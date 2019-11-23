using System;
using System.Threading.Tasks;
using MediatR;
using R2D2.Commands;

namespace R2D2
{
    public class Startup
    {
        private readonly IMediator _mediator;

        public Startup(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Run()
        {
            const string expression = "10 / 40 * 3";
            var result = await _mediator.Send(new EvaluateExpressionCommand {Expression = expression});
            Console.WriteLine(result);
        }
    }
}