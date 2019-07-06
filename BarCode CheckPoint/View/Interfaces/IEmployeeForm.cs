using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPoint.Model.Entities;
using CheckPoint.View.Services;

namespace CheckPoint.View.Interfaces
{
    public interface IEmployeeForm : IForm
    {
        Image EmployeePhoto { get; set; }
        Employee CurrentEmployee { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Patronymic { get; set; }
        int PostId { get; set; }
        string BarCode { get; set; }

        bool IsCodeActive { get; set; }
        List<Post> PostList { get; set; }

        event EventHandler OnFormShow;
        event EventHandler OnApplyChanges;
        event EventHandler<EventPhotoArgs> OnChoosePhoto;
    }

}
