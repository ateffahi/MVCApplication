using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Application.ViewModels
{
    public class StudentViewModel
    {
        private int _Id;
        private string _Name;

        public int Id { get => _Id; set => _Id = value; }
        [Required, StringLength(50), Display(Name = "Nom")]
        public string Name { get => _Name; set => _Name = value; }

    }
}