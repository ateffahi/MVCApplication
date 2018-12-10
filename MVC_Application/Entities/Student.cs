using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Application.Entities
{
    public class Student
    {
        private int _Id;
        private string _Name;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get => _Id; set => _Id = value; }
        public string Name { get => _Name; set => _Name = value; }
        
        //Relations 
        public virtual ICollection<ClassRoom> ClassRooms { get; set; }


    }
}