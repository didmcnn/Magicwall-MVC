namespace CoreLayer.Utilities.MailUtilities
{
    public interface IMailService
    {
        Task<bool> SendMailsAsync(string[] mail, string subject, string message);
        Task<bool> SendMailAsync(string mail, string subject, string message);
    }
}
