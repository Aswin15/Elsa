using Elsa.Persistence.EntityFramework.Core.Extensions;
using Elsa.Providers.Workflows;
using ElsaAPI.Workflows.Items;
using Microsoft.EntityFrameworkCore;
using Storage.Net;

namespace ElsaAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWorkflowServices(this IServiceCollection services, Action<DbContextOptionsBuilder> configureDb, IConfiguration configuration)
        {
            return services.AddElsa(configureDb, configuration);
        }

        private static IServiceCollection AddElsa(this IServiceCollection services, Action<DbContextOptionsBuilder> configureDb, IConfiguration configuration)
        {
            services
                .AddElsa(elsa => elsa

                    // Use EF Core's SQLite provider to store workflow instances and bookmarks.
                    .UseEntityFrameworkPersistence(configureDb)

                    // Ue Console activities for testing & demo purposes.
                    .AddConsoleActivities()

                    // Configure HTTP activities.
                    .AddHttpActivities(configuration.GetSection("Elsa:Server").Bind)
                    .AddWorkflow<HelloWorldWorkFlow>()
                );

            // Get directory path to current assembly.
            string? currentAssemblyPath = Path.GetDirectoryName(typeof(ServiceCollectionExtensions).Assembly.Location);

            // Configure Storage for BlobStorageWorkflowProvider with a directory on disk from where to load workflow definition JSON files from the local "Workflows" folder.
            services.Configure<BlobStorageWorkflowProviderOptions>(
                options => options.BlobStorageFactory = () => StorageFactory.Blobs.DirectoryFiles(
                    Path.Combine(currentAssemblyPath, "Workflows")));

            return services;
        }
    }
}
