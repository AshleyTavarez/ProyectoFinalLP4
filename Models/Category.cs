using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Recetas.Models
{
    public class Category
    {
        [Key]
        public int Id_Categoria { get; set; }
        [Required]
        public string Nombre { get; set; }


    }
}