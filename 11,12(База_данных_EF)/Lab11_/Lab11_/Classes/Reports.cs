using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11_.Classes
{
    [Table("REPORTS")]
    public class Reports
    {
        [Key]
        [Column("id_report")]
        public int IdReport
        {
            get; set;
        }
        [Column("report_date")]
        public string ReportDate
        {
            get; set;
        }
        [Column("eat_period")]
        public string EatPeriod
        {
            get; set;
        }
        [Column("day_calories")]
        public float DayCalories
        {
            get; set;
        }
        [Column("day_proteins")]
        public float DayProteins
        {
            get; set;
        }
        [Column("day_fats")]
        public float DayFats
        {
            get; set;
        }
        [Column("day_carbohydrates")]
        public float DayCarbohydrates
        {
            get; set;
        }
    }
}
