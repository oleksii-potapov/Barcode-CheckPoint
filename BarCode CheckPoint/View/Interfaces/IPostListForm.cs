using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPoint.Model.Entities;

namespace CheckPoint.View.Interfaces
{
    public interface IPostListForm : IForm
    {
        List<Post> Posts { get; set; }
        Post CurrentPost { get; }
        int SelectedPostIndex { get; set; }
        string PostToAdd { get; set; }

        event EventHandler OnAddPost;
        event EventHandler OnEditPost;
        event EventHandler OnDeletePost;
    }
}
