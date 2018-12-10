using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Application.ViewModels
{
    public class StudentAttendanceViewModel
    {
        #region properties
        private int _Id;
        private DateTime _AttedanceDate;
        private Boolean _IsPresent;
        private StudentViewModel _StudentName;
        private int _IdClassRoom;
        private string _ClassRoom;
      
        #endregion

        public int Id { get => _Id; set => _Id = value; }
        [Required]
        public DateTime Date { get => _AttedanceDate; set => _AttedanceDate = value; }
        [Required]
        public bool IsPresent { get => _IsPresent; set => _IsPresent = value; }
        [Required]
        public StudentViewModel StudentName { get => _StudentName; set => _StudentName = value; }
        [Required]
        public int IdClassRoom { get => _IdClassRoom; set => _IdClassRoom = value; }
        [Required]
        public string ClassRoom { get => _ClassRoom; set => _ClassRoom = value; }
    }
}