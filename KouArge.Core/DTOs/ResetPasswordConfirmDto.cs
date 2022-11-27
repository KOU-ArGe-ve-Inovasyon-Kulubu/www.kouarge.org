namespace KouArge.Core.DTOs
{
    public class ResetPasswordConfirmDto
    {
        public string AppUserId { get; set; }
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}
