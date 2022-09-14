using Elsa;
using Elsa.ActivityResults;
using Elsa.Attributes;
using Elsa.Services;
using Elsa.Services.Models;
using ElsaAPI.Context;
using ElsaAPI.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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

        [ActivityInput(Hint = "The name of new user.")]
        public string Username { get; set; }

        protected override IActivityExecutionResult OnExecute(ActivityExecutionContext context)
        {
            var newUser = new User
            {
                Name = Username
            };
            _userService.CreateUser(newUser);

            // Return an outcome.
            return Outcome("Done");
        }
    }
}
