using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckPoint.Model.Entities
{
    public class Employee
    {
        [Key] public string BarCode { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        [ForeignKey("Post")] public int? PostId { get; set; }
        public virtual Post Post { get; set; }

        public string FullName => string.Format($"{LastName} {FirstName} {Patronymic}")
                                        .Trim();

        public override string ToString() => FullName;
    }
}