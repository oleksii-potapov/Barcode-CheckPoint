using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CheckPoint.Model.Entities;
using CheckPoint.View.Interfaces;
using CheckPoint.View.Services;

namespace CheckPoint.View.Forms
{
    public partial class EmployeeForm : Form, IEmployeeForm
    {
        public EmployeeForm()
        {
            InitializeComponent();
            this.Shown += EmployeeForm_Shown;
            buttonCancel.Click += ButtonCancel_Click;
            buttonOk.Click += ButtonOk_Click;
            buttonChoosePhoto.Click += ButtonChoosePhoto_Click;
        }

        private void EmployeeForm_Shown(object sender, EventArgs e)
        {
            OnFormShow?.Invoke(this, EventArgs.Empty);
        }

        public void ShowForm()
        {
            Show();
        }

        public void CloseForm()
        {
            Close();
        }

        public Image EmployeePhoto
        {
            get => pictureEmployeePhoto.Image;
            set => pictureEmployeePhoto.Image = value;
        }
        public Employee CurrentEmployee { get; set; }

        public string FirstName
        {
            get => textFirstName.Text;
            set => textFirstName.Text = value;
        }

        public string LastName
        {
            get => textLastName.Text;
            set => textLastName.Text = value;
        }

        public string Patronymic
        {
            get => textPatronymic.Text;
            set => textPatronymic.Text = value;
        }

        public int PostId
        {
            get => (int) comboPosts.SelectedValue;
            set => comboPosts.SelectedValue = value;
        }

        public string BarCode
        {
            get => textBarCode.Text;
            set => textBarCode.Text = value;
        }

        public BindingList<Post> PostList
        {
            get => (BindingList<Post>) comboPosts.DataSource;
            set => comboPosts.DataSource = value;
        }

        public event EventHandler OnFormShow;
        public event EventHandler OnApplyChanges;
        public event EventHandler<EventPhotoArgs> OnChoosePhoto;

        private void ButtonChoosePhoto_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
                OnChoosePhoto?.Invoke(this, new EventPhotoArgs(openFileDialog.FileName));
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            OnApplyChanges?.Invoke(this, EventArgs.Empty);
        }
    }
}
