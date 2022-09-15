using Elsa.Activities.ControlFlow;
using Elsa.Activities.Http.Models;
using Elsa.Activities.Http;
using Elsa.Builders;
using System.Net;
using Elsa.Activities.Primitives;
using DotLiquid;
using ElsaAPI.Workflows.Activites;
using Newtonsoft.Json.Linq;
using Esprima.Ast;
using Fluid.Values;
using Elsa.Events;

namespace ElsaAPI.Workflows.Items
{
    public class HelloWorldWorkFlow : IWorkflow
    {
        private readonly IConfiguration _config;
        private readonly UserService _userService;
        public HelloWorldWorkFlow(IConfiguration config, UserService userService)
        {
            _config = config;
            var abc = $"{_config["Elsa:Server:BaseUrl"]}/v1/file-create";
            _userService = userService;
        }
        public void Build(IWorkflowBuilder builder)
        {
            builder
                 .WithDisplayName("Approval & UserCreation")

                 // handle approval http request
                .HttpEndpoint(activity => activity
                    .WithPath("/v1/approval")
                    .WithMethod(HttpMethod.Post.Method)
                    .WithReadContent())
                .SetVariable("Username", context => context.GetInput<HttpRequestModel>()!.Body)
                .WriteHttpResponse(HttpStatusCode.OK, "<h1>Approval Done</h1>", "application/json")

                // activity for user creation

                // http reqeust - for file creation
                .SendHttpRequest(a => a
                .WithUrl(new Uri($"{_config["Elsa:Server:BaseUrl"]}/v1/file-create"))
                .WithMethod(HttpMethod.Post.Method)
                .WithContent(context => $"{context.GetVariable<dynamic>("Username")!.name}")
                .WithContentType("application/json"));
        }
    }
}
