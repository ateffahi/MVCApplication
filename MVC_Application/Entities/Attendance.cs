using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Application.Entities
{
    public class Attendance
    {
        private int _Id;
        private DateTime _AttedanceDate;
        private Boolean _IsPresent;
        private int _IdStudent;
        private int _IdClassRoom;


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get => _Id; set => _Id = value; }
        public DateTime Date { get => _AttedanceDate; set => _AttedanceDate = value; }
        public bool IsPresent { get => _IsPresent; set => _IsPresent = value; }
        [ForeignKey("Student"), Column("StudentId")]
        public int IdStudent { get => _IdStudent; set => _IdStudent = value; }
        [ForeignKey("ClassRoom"), Column("ClassRoomId")]
        public int IdClassRoom { get => _IdClassRoom; set => _IdClassRoom = value; }

        // Relations 
        public virtual Student Student { get; set; }
        public virtual ClassRoom ClassRoom { get; set; }
        
    }
}