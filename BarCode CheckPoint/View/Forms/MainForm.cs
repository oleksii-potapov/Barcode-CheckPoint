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

        public Image Camera { get; set; }
        public Image CheckPhoto { get; set; }
        public Image EmployeePhoto { get; set; }

        #endregion

        #region Events

        public event EventHandler EmployeeChecked;
        public event EventHandler SettingsClick;
        public event EventHandler ReportsClick;
        public event EventHandler CheckFormClick;
        public event EventHandler FormShow;
        public event EventHandler FormClose;

        #endregion

        private void MainForm_Shown(object sender, EventArgs e)
        {
            FormShow?.Invoke(sender, EventArgs.Empty);
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
                FormClose?.Invoke(sender, e);
            }
        }

        private void TextBarCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                EmployeeChecked?.Invoke(sender, EventArgs.Empty);
            }
        }
    }
}