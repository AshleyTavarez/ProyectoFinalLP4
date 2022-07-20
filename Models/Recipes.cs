using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Recetas.Models
{
    public class Recipes
    {
        [Key]
        public int Id_recipe { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public int Id_Categoria { get; set; }
        [Required]
        public int Id_Ingredientes { get; set; }
        [Required]
        public int Preptime { get; set; }
        [Required]
        public int Cooktime { get; set; }
        [Required]
        public int ReadyIn { get; set; }
        
       
        public decimal Calories { get; set; }
        public decimal Fat { get; set;}
        public decimal Carbs { get; set;}
        public decimal Protein { get; set; }




    }
}