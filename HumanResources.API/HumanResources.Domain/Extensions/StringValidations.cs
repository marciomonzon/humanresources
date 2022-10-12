namespace HumanResources.Domain.Extensions
{
    internal static class StringValidations
    {
        public static bool IsValidEmail(this string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
                return false; 

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
    }
}
