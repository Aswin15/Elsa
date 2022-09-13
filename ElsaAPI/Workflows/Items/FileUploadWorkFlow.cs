using Elsa.Activities.Http;
using Elsa.Builders;
using System.Net;

namespace ElsaAPI.Workflows.Items
{
    public class FileUploadWorkFlow : IWorkflow
    {
        public void Build(IWorkflowBuilder builder)
        {
            builder
                 .WithDisplayName("file-upload")
                .HttpEndpoint("/v1/approval")
                .WriteHttpResponse(HttpStatusCode.OK, "<h1>File Upload!</h1>", "application/json")
                .HttpEndpoint("/v1/helloworld");
        }
    }
}
