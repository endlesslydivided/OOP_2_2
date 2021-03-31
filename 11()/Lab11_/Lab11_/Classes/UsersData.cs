using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11_.Classes
{
    [Table("USERS_DATA")]
    public class UsersData
    {
        [Key]
        [Column("id_data")]
        public int IdData
        {
            get; set;
        }
        [Column("full_name")]
        public string FullName
        {
            get; set;
        }
        [Column("birthday")]
        public string Birthday
        {
            get; set;
        }
        [Column("age")]
        public int Age
        {
            get; set;
        }
    }
}
