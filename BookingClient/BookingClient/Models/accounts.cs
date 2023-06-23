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
    
    public partial class accounts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public accounts()
        {
            this.passed_tours = new HashSet<passed_tours>();
            this.grades = new HashSet<grades>();
            this.viewed_tours = new HashSet<viewed_tours>();
            this.liked_tours = new HashSet<liked_tours>();
            this.tours = new HashSet<tours>();
        }
    
        public int account_id { get; set; }
        public string account_login { get; set; }
        public string account_password { get; set; }
        public Nullable<int> first_name_id { get; set; }
        public Nullable<int> last_name_id { get; set; }
        public Nullable<int> role_id { get; set; }
        public byte[] image { get; set; }
        public Nullable<long> phone { get; set; }
        public string email { get; set; }
        public Nullable<System.DateTime> dayofbirth { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<passed_tours> passed_tours { get; set; }
        public virtual first_names first_names { get; set; }
        public virtual last_names last_names { get; set; }
        public virtual roles roles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<grades> grades { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<viewed_tours> viewed_tours { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<liked_tours> liked_tours { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tours> tours { get; set; }
    }
}
