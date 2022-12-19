using System.Security.Claims;

namespace KouArge.Core.DTOs
{
	public class LoginViewModel
	{
		public AppUserDto User { get; set; }

		public List<string> Role { get; set; } = new List<string>();

		public List<Claim> Claims { get; set; }

        public List<ErrorViewModel> Errors { get; set; }
    }
}
