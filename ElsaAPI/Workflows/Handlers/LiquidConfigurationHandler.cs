using Elsa.Scripting.Liquid.Messages;
using ElsaAPI.Entities;
using Fluid;
using MediatR;

namespace ElsaAPI.Workflows.Handlers
{
    public class LiquidConfigurationHandler : INotificationHandler<EvaluatingLiquidExpression>
    {
        public Task Handle(EvaluatingLiquidExpression notification, CancellationToken cancellationToken)
        {
            var context = notification.TemplateContext;
            context.Options.MemberAccessStrategy.Register<User>();
            return Task.CompletedTask;
        }
    }
}
