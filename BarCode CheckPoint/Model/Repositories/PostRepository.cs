using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPoint.Model.Entities;

namespace CheckPoint.Model.Repositories
{
    class PostRepository : BaseRepository<Post>
    {
        private BindingList<Post> _bindingList = new BindingList<Post>();
        public BindingList<Post> GetBindingList()
        {
            Context.Posts.Load();
            _bindingList = Context.Posts.Local.ToBindingList();
            return _bindingList;
        }

        public bool AnyPostByPostName(string post)
        {
            return Context.Posts.Any(p => p.Name == post);
        }
    }
}
