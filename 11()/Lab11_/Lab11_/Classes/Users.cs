using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11_.Classes
{
    [Table("USERS")]
    public class Users
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id
        {
            get;set;
        }
        [Column("is_admin")]
        public bool IsAdmin
        {
            get; set;
        }
        [Column("user_login")]
        public string UserLogin
        {
            get; set;
        }
        [Column("user_password")]
        public string UserPassword
        {
            get; set;
        }
    }
}
