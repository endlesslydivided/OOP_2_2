using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11_.Classes
{
    [Table("USERS_PARAMS")]
    public class UsersParams
    {
        [Key]
        [Column("id_params")]
        public int IdParams
        {
            get; set;
        }
        [Column("params_date")]
        public string ParamsDate
        {
            get; set;
        }
        [Column("user_weight")]
        public float UserWeight
        {
            get; set;
        }
        [Column("user_height")]
        public int UserHeight
        {
            get; set;
        }
    }
}
