namespace CheckPoint.View.Interfaces
{
    public interface IMessageService
    {
        void ShowError(string error);
        void ShowMessage(string message);
        void ShowWarning(string warning);
        bool ShowQuestion(string question);
    }
}