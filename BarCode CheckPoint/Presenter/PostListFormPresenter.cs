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
            View = new PostListForm();
            View.Posts = _context.Posts.ToList();

            View.OnFormShow += View_OnFormShow;
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
            try
            {
                _context.Posts.Remove(postToDelete ?? throw new InvalidOperationException());
                _context.SaveChanges();
                View.Posts = _context.Posts.ToList();
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
            View.Posts = _context.Posts.ToList();
        }

        private void View_OnFormShow(object sender, EventArgs e)
        {
        }
    }
}