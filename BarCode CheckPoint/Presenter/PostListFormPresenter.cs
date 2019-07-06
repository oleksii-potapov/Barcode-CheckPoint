using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPoint.Model;
using CheckPoint.Model.Entities;
using CheckPoint.View.Forms;
using CheckPoint.View.Interfaces;

namespace CheckPoint.Presenter
{
    class PostListFormPresenter
    {
        private readonly IMessageService _messageService;
        private readonly ApplicationContext _context;
        public IPostListForm View { get; }

        public PostListFormPresenter(IMessageService messageService, ApplicationContext context)
        {
            _messageService = messageService;
            _context = context;
            _context.Posts.Load();
            View = new PostListForm {Posts = _context.Posts.Local.ToList()};

            View.OnAddPost += View_OnAddPost;
            View.OnDeletePost += View_OnDeletePost;
            View.OnEditPost += View_OnEditPost;
        }

        private void View_OnEditPost(object sender, EventArgs e)
        {
            _context.SaveChanges();
        }

        private void View_OnDeletePost(object sender, EventArgs e)
        {
            var postToDelete = _context.Posts.Find(View.CurrentPost.PostId);
            if (postToDelete == null) return;
            if (_context.Employees.FirstOrDefault(emp => emp.PostId == View.CurrentPost.PostId) != null)
            {
                _messageService.ShowError("There are records in Employee table with this post." +
                                          Environment.NewLine + "Deletion of this record is impossible.");
                return;
            }
            try
            {
                _context.Posts.Remove(postToDelete);
                _context.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                _messageService.ShowError("Record was not deleted." + Environment.NewLine +
                                          "Error message: " + exception.Message);
            }
        }

        private void View_OnAddPost(object sender, EventArgs e)
        {
            if (View.PostToAdd == string.Empty) return;
            if (_context.Posts.FirstOrDefault(s => s.Name == View.PostToAdd) != null) return;
            var postToAdd = new Post() {Name = View.PostToAdd};
            _context.Posts.Add(postToAdd);
            _context.SaveChanges();
        }

    }
}