//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookingClient.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class persons
    {
        public int person_id { get; set; }
        public Nullable<int> order_id { get; set; }
        public Nullable<int> first_name_id { get; set; }
        public Nullable<int> last_name_id { get; set; }
        public Nullable<int> city_id { get; set; }
        public Nullable<long> passport { get; set; }
        public Nullable<System.DateTime> birthday { get; set; }
    
        public virtual cities cities { get; set; }
        public virtual first_names first_names { get; set; }
        public virtual last_names last_names { get; set; }
        public virtual orders orders { get; set; }
    }
}