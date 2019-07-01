using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CheckPoint.Model.Entities;
using CheckPoint.View.Interfaces;

namespace CheckPoint.View.Forms
{
    public partial class MainForm : Form, IMainForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region Properties

        public string BarCode
        {
            get => textBarCode.Text;
            set => textBarCode.Text = value;
        }

        public string FullName
        {
            get => labelFullName.Text;
            set => labelFullName.Text = value;
        }

        public string Post
        {
            get => labelPost.Text;
            set => labelPost.Text = value;
        }

        public DateTime? DateTimeEntry
        {
            get
            {
                if (DateTime.TryParse(labelDateTimeEntry.Text, out var dateTime))
                    return dateTime;
                return null;
            }
            set
            {
                if (value.HasValue)
                    labelDateTimeEntry.Text = value.Value.ToString("dd.MM.yyyy HH:mm:ss");
                else
                    labelDateTimeEntry.Text = "";
            }
        }

        DateTime? IMainForm.DateTimeExit
        {
            get
            {
                if (DateTime.TryParse(labelDateTimeExit.Text, out var dateTime))
                    return dateTime;
                return null;
            }
            set
            {
                if (value.HasValue)
                    labelDateTimeExit.Text = value.Value.ToString("dd.MM.yyyy HH:mm:ss");
                else
                    labelDateTimeExit.Text = "";
            }
        }

        public bool IsEntry
        {
            get => radioEntry.Checked;
            set => radioEntry.Checked = value;
        }

        public Image Camera
        {
            get => pictureCamera.Image;
            set => pictureCamera.Image = value;
        }

        public Image CheckPhoto
        {
            get => pictureCheckPhoto.Image;
            set => pictureCheckPhoto.Image = value;
        }

        public Image EmployeePhoto
        {
            get => pictureEmployeePhoto.Image;
            set => pictureEmployeePhoto.Image = value;
        }

        public string ProcessStatus
        {
            get => toolStripStatus.Text;
            set => toolStripStatus.Text = value;
        }

        #endregion

        #region Events

        public void ShowForm()
        {
            Show();
        }

        public event EventHandler OnEmployeeChecked;
        public event EventHandler OnSettingsClick;
        public event EventHandler OnReportsClick;
        public event EventHandler OnAboutClick;
        public event EventHandler OnCheckFormClick;
        public event EventHandler OnFormShow;
        public event EventHandler OnFormClose;
        public event EventHandler OnEmployeesClick;
        public event EventHandler OnPostsClick;

        #endregion

        private void MainForm_Shown(object sender, EventArgs e)
        {
            OnFormShow?.Invoke(sender, EventArgs.Empty);
            textBarCode.Focus();
        }

        public void CloseForm()
        {
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                OnFormClose?.Invoke(sender, e);
            }
        }

        private void TextBarCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                OnEmployeeChecked?.Invoke(sender, EventArgs.Empty);
            }
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnSettingsClick?.Invoke(sender, EventArgs.Empty);
        }

        private void ReportsFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnReportsClick?.Invoke(sender, EventArgs.Empty);
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnAboutClick?.Invoke(sender, EventArgs.Empty);
        }

        private void EmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnEmployeesClick?.Invoke(this, EventArgs.Empty);
        }

        private void PostsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnPostsClick?.Invoke(this, EventArgs.Empty);
        }
    }
}