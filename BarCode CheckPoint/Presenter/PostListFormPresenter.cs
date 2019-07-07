using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPoint.Model;
using CheckPoint.Model.Entities;
using CheckPoint.Model.Repositories;
using CheckPoint.View.Forms;
using CheckPoint.View.Interfaces;

namespace CheckPoint.Presenter
{
    class PostListFormPresenter
    {
        private readonly IMessageService _messageService;
        private readonly PostRepository _postRepository;
        private readonly EmployeeRepository _employeeRepository;
        public IPostListForm View { get; }

        public PostListFormPresenter(IMessageService messageService, ApplicationContext context)
        {
            _messageService = messageService;
            _postRepository = new PostRepository();
            _employeeRepository = new EmployeeRepository();
            View = new PostListForm {Posts = _postRepository.GetBindingList()};

            View.OnAddPost += View_OnAddPost;
            View.OnDeletePost += View_OnDeletePost;
            View.OnEditPost += View_OnEditPost;
        }

        private void View_OnEditPost(object sender, EventArgs e)
        {
            _postRepository.Update(View.CurrentPost);
        }

        private void View_OnDeletePost(object sender, EventArgs e)
        {
            var postToDelete = _postRepository.GetOne(View.CurrentPost.PostId);
            if (postToDelete == null) return;
            if (_employeeRepository.GetSome(emp => emp.PostId == View.CurrentPost.PostId).Count > 0)
            {
                _messageService.ShowError("There are records in Employee table with this post." +
                                          Environment.NewLine + "Deletion of this record is impossible.");
                return;
            }
            try
            {
                _postRepository.Delete(postToDelete);
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
            if (_postRepository.AnyPostByPostName(View.PostToAdd)) return;
            var postToAdd = new Post() {Name = View.PostToAdd};
            _postRepository.Add(postToAdd);
        }
    }
}