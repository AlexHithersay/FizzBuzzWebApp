using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace FizzBuzzWebApp.Data
{
    // Model class for storing the data. Entity Framework creates a table in the database automatically.
    public class DBTableModel
    {
        [Key]
        public int ID { get; set; }


        [Required]
        public string ValueToDisplay { get; set; }
    }
}
