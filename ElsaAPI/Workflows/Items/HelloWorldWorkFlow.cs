using Elsa.Activities.ControlFlow;
using Elsa.Activities.Http.Models;
using Elsa.Activities.Http;
using Elsa.Builders;
using System.Net;

namespace ElsaAPI.Workflows.Items
{
    public class HelloWorldWorkFlow : IWorkflow
    {
        public void Build(IWorkflowBuilder builder)
        {
            builder
                 .WithDisplayName("Hello-world")
                .HttpEndpoint("/v1/helloworld")
                .WriteHttpResponse(HttpStatusCode.OK, "<h1>Hello World!</h1>", "application/json");
        }
    }
}
