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

namespace CheckPoint.View.Forms
{
    public partial class PostListForm : Form, IPostListForm
    {
        public PostListForm()
        {
            InitializeComponent();
            gridPost.SelectionChanged += GridPost_SelectionChanged;
            this.Shown += PostListForm_Shown;
        }

        private void PostListForm_Shown(object sender, EventArgs e)
        {
            OnFormShow?.Invoke(this, EventArgs.Empty);
        }

        private void GridPost_SelectionChanged(object sender, EventArgs e)
        {
            if (gridPost.Rows.Count > 0)
            {
                SelectedPostIndex = gridPost.CurrentCell.RowIndex;
                CurrentPost = Posts[SelectedPostIndex];
            }

            OnCurrentPostChanged?.Invoke(this, EventArgs.Empty);
        }

        public BindingList<Post> Posts
        {
            get => (BindingList<Post>) gridPost.DataSource;
            set => gridPost.DataSource = value;
        }

        public Post CurrentPost { get; set; }
        public int SelectedPostIndex { get; set; }

        public string PostToAdd
        {
            get => textPostToAdd.Text;
            set => textPostToAdd.Text = value;
        }

        public event EventHandler OnAddPost;
        public event EventHandler OnEditPost;
        public event EventHandler OnDeletePost;
        public event EventHandler OnCurrentPostChanged;
        public event EventHandler OnFormShow;

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            OnAddPost?.Invoke(this, EventArgs.Empty);
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            OnEditPost?.Invoke(this, EventArgs.Empty);
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            OnDeletePost?.Invoke(this, EventArgs.Empty);
        }

        public void ShowForm()
        {
            Show();
        }

        public void CloseForm()
        {
            Close();
        }
    }
}