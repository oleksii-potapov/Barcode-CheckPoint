namespace CheckPoint.View.Forms
{
    partial class PostListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridPost = new System.Windows.Forms.DataGridView();
            this.PostName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.textPostToAdd = new System.Windows.Forms.TextBox();
            this.labelAddPost = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridPost)).BeginInit();
            this.SuspendLayout();
            // 
            // gridPost
            // 
            this.gridPost.AllowUserToAddRows = false;
            this.gridPost.AllowUserToDeleteRows = false;
            this.gridPost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPost.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PostName,
            this.PostId});
            this.gridPost.Location = new System.Drawing.Point(12, 12);
            this.gridPost.MultiSelect = false;
            this.gridPost.Name = "gridPost";
            this.gridPost.Size = new System.Drawing.Size(467, 248);
            this.gridPost.TabIndex = 0;
            // 
            // PostName
            // 
            this.PostName.DataPropertyName = "Name";
            this.PostName.HeaderText = "Post";
            this.PostName.Name = "PostName";
            this.PostName.Width = 400;
            // 
            // PostId
            // 
            this.PostId.DataPropertyName = "PostId";
            this.PostId.HeaderText = "Id";
            this.PostId.Name = "PostId";
            this.PostId.Visible = false;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAdd.Location = new System.Drawing.Point(12, 314);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(148, 42);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Add post to list";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEdit.Location = new System.Drawing.Point(331, 266);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(148, 42);
            this.buttonEdit.TabIndex = 2;
            this.buttonEdit.Text = "Save changes in posts";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Location = new System.Drawing.Point(331, 314);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(148, 42);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Delete selected post";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // textPostToAdd
            // 
            this.textPostToAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textPostToAdd.Location = new System.Drawing.Point(12, 288);
            this.textPostToAdd.Name = "textPostToAdd";
            this.textPostToAdd.Size = new System.Drawing.Size(286, 20);
            this.textPostToAdd.TabIndex = 4;
            // 
            // labelAddPost
            // 
            this.labelAddPost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelAddPost.AutoSize = true;
            this.labelAddPost.Location = new System.Drawing.Point(12, 272);
            this.labelAddPost.Name = "labelAddPost";
            this.labelAddPost.Size = new System.Drawing.Size(61, 13);
            this.labelAddPost.TabIndex = 5;
            this.labelAddPost.Text = "Post to add";
            // 
            // PostListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 368);
            this.Controls.Add(this.labelAddPost);
            this.Controls.Add(this.textPostToAdd);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.gridPost);
            this.MinimumSize = new System.Drawing.Size(508, 406);
            this.Name = "PostListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PostListForm";
            ((System.ComponentModel.ISupportInitialize)(this.gridPost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridPost;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostId;
        private System.Windows.Forms.TextBox textPostToAdd;
        private System.Windows.Forms.Label labelAddPost;
    }
}