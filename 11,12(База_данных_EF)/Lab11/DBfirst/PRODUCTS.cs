//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBfirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class PRODUCTS
    {
        public int id_added { get; set; }
        public string product_name { get; set; }
        public decimal calories_gram { get; set; }
        public decimal proteins_gram { get; set; }
        public decimal fats_gram { get; set; }
        public decimal carbohydrates_gram { get; set; }
    
        public virtual USERS USERS { get; set; }
    }
}
