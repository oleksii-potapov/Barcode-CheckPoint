using System.Windows.Forms;
using CheckPoint.Properties;
using CheckPoint.View.Interfaces;

namespace CheckPoint.View.Services
{
    public class MessageService : IMessageService
    {
        public void ShowMessage(string message)
        {
            MessageBox.Show(message, Resources.MessageCaptionMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void ShowWarning(string warning)
        {
            MessageBox.Show(warning, Resources.MessageCaptionWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void ShowError(string error)
        {
            MessageBox.Show(error, Resources.MessageCaptionError, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public bool ShowQuestion(string question)
        {
            if (MessageBox.Show(question, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                return true;
            return false;
        }
    }
}
