using Elsa.Activities.ControlFlow;
using Elsa.Activities.Http;
using Elsa.Builders;
using Fluid.Ast;
using System.Net;

namespace ElsaAPI.Workflows.Items
{
    public class FileUploadWorkFlow : IWorkflow
    {
        public void Build(IWorkflowBuilder builder)
        {
            builder
                .HttpEndpoint(activity => activity
                    .WithPath("/v1/helloworld")
                    .WithMethod(HttpMethod.Get.Method)
                    .WithReadContent());
        }
    }
}
