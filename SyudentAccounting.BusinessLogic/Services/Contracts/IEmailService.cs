namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IEmailService
    {
        void SendEmailMessage(string email, string subject, string message);
    }
}
