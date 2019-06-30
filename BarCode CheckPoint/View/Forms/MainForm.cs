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
            get
            {
                var picture = pictureCamera.Image;
                return picture;
            }
            set => pictureCamera.Image = value;
        }

        public Image CheckPhoto
        {
            get
            {
                var picture = pictureCheckPhoto.Image;
                return picture;
            }
            set => pictureCheckPhoto.Image = value;
        }
        public Image EmployeePhoto { get; set; }
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

        public event EventHandler EmployeeChecked;
        public event EventHandler SettingsClick;
        public event EventHandler ReportsClick;
        public event EventHandler AboutClick;
        public event EventHandler CheckFormClick;
        public event EventHandler OnFormShow;
        public event EventHandler OnFormClose;
        public event EventHandler EmployeesClick;
        public event EventHandler PostsClick;

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
                EmployeeChecked?.Invoke(sender, EventArgs.Empty);
            }
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsClick?.Invoke(sender, EventArgs.Empty);
        }

        private void ReportsFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportsClick?.Invoke(sender, EventArgs.Empty);
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutClick?.Invoke(sender, EventArgs.Empty);
        }

        private void EmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeesClick?.Invoke(this, EventArgs.Empty);
        }

        private void PostsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PostsClick?.Invoke(this, EventArgs.Empty);
        }
    }
}