using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckPoint.Model.Entities
{
    public class ShiftCheck
    {
        public int ShiftCheckId { get; set; }
        [ForeignKey("Employee")] [Required] public string BarCode { get; set; }
        public virtual Employee Employee { get; set; }
        public DateTime? DateTimeEntry { get; set; }
        public DateTime? DateTimeExit { get; set; }
        public bool WrongCheck { get; set; } = false;

        public override string ToString()
        {
            return string.Format($"{BarCode} {DateTimeEntry} {DateTimeExit}");
        }
    }
}