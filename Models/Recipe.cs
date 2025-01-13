using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavorFusion.Models
{
    [Table("Recipe")] // Specifică numele tabelului în baza de date
    public class Recipe
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } // ID unic pentru fiecare rețetă

        [Column("Name")]
        public string Name { get; set; } // Numele rețetei

        [Column("Instructions")]
        public string Instructions { get; set; } // Instrucțiuni pentru rețetă

        [Column("CategoryId")]
        public int CategoryId { get; set; } // Referință la categoria din care face parte

        [Column("UserId")]
        public int UserId { get; set; } // Referință la utilizatorul care a creat rețeta

        [Ignore]
        public string CategoryName { get; set; }

        [Ignore]
        public string UserName { get; set; }
    }
}