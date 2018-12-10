using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Application.Entities
{
    public class ClassRoom
    {
        private int _Id;
        private int _Number;
        private string _Name;

        //Relations
        public virtual ICollection<Student> Students { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get => _Id; set => _Id = value; }
        public int Number { get => _Number; set => _Number = value; }
        public string Name { get => _Name; set => _Name = value; }
    }
}