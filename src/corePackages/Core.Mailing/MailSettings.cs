namespace Core.Mailing;

public class MailSettings
{
    public string Server { get; set; }
    public int Port { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string SenderFullName { get; set; }
    public string SenderEmail { get; set; }
}