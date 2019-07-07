using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CheckPoint.Model.Entities;

namespace CheckPoint.Model.Repositories
{
    class EmployeeRepository : BaseRepository<Employee>
    {
        private BindingList<Employee> _bindingList = new BindingList<Employee>();

        public BindingList<Employee> GetBindingList()
        {
            Context.Employees.Include("Post").Load();
            _bindingList = Context.Employees.Local.ToBindingList();
            return _bindingList;
        }
    }
}
