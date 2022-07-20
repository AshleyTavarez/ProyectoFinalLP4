using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Recetas.Models
{
    public class Ingredientes
    {
        [Key]
        public int Id_Ingredients { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Medida { get; set; }
        public float Calories { get; set; }
        public float Carbs { get; set; }
        public float Fat { get; set; }
        public float Protein { get; set; }


    }
}