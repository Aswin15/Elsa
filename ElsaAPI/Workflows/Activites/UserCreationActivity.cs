using Elsa;
using Elsa.Activities.Http.Models;
using Elsa.ActivityResults;
using Elsa.Attributes;
using Elsa.Expressions;
using Elsa.Services;
using Elsa.Services.Models;
using ElsaAPI.Context;
using ElsaAPI.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Namotion.Reflection;

namespace ElsaAPI.Workflows.Activites
{
    [Activity(Category = "Demo",
    DisplayName = "User Creation",
    Description = "Activity to create a user",
    Outcomes = new[] { OutcomeNames.Done })]
    public class UserCreationActivity : Activity
    {
        private readonly UserService _userService;
        public UserCreationActivity(UserService userService)
        {
            _userService = userService;
        }

        [ActivityInput(Hint = "The name of new user.", SupportedSyntaxes = new[] { SyntaxNames.JavaScript, SyntaxNames.Liquid })]
        public dynamic User { get; set; }

        protected override IActivityExecutionResult OnExecute(ActivityExecutionContext context)
        {
            var userType = typeof(HttpRequestModel);
            var userName = userType.GetProperty("Body").GetValue(User, null);
            var newUser = new User
            {
                Name = userName.Name,
            };

            _userService.CreateUser(newUser);

            // Return an outcome.
            return Outcome("Done");
        }
    }
}
