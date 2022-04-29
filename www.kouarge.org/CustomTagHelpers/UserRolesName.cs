using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using www.kouarge.org.Identity;

namespace www.kouarge.org.CustomTagHelpers
{
    [HtmlTargetElement("td",Attributes ="user-roles")]
    public class UserRolesName : TagHelper
    {
        public UserManager<User> UserManager { get; set; }

        public UserRolesName(UserManager<User> userManager)
        {
            this.UserManager = userManager;
        }
        [HtmlAttributeName("user-roles")]
        public string UserId { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
           User user = await UserManager.FindByIdAsync(UserId);
            IList<string> roles =await UserManager.GetRolesAsync(user);

            string htmml=string.Empty;
            roles.ToList().ForEach(x =>
            {
                htmml += $"<span class='badge badge-info'>{x}</span>";
            });
            output.Content.SetHtmlContent(htmml);
        }
    }
}
