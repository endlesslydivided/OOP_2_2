using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11_.Classes
{
    [Table("PRODUCTS")]
    public class Products
    {
        [Column("id_added")]
        public int IdAdded 
        {
            get;set;
        }
        [Key]
        [Column("product_name")]
        public string ProductName
        {
            get; set;
        }
        [Column("calories_gram")]
        public decimal CaloriesGram
        {
            get; set;
        }
        [Column("proteins_gram")]
        public decimal ProteinsGram
        {
            get; set;
        }
        [Column("fats_gram")]
        public decimal FatsGram
        {
            get; set;
        }
        [Column("carbohydrates_gram")]
        public decimal CarbohydratesGram
        {
            get; set;
        }
    }
}
