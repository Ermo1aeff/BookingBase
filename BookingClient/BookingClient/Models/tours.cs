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
    
    public partial class tours
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tours()
        {
            this.departures = new HashSet<departures>();
            this.discounts = new HashSet<discounts>();
            this.grades = new HashSet<grades>();
            this.images = new HashSet<images>();
            this.included = new HashSet<included>();
            this.itinerary = new HashSet<itinerary>();
            this.rooms = new HashSet<rooms>();
            this.tour_lists = new HashSet<tour_lists>();
            this.wish_lists = new HashSet<wish_lists>();
        }
    
        public int tour_id { get; set; }
        public string tour_name { get; set; }
        public string tour_description { get; set; }
        public Nullable<int> city_begin_id { get; set; }
        public Nullable<int> city_end_id { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<int> day_count { get; set; }
        public Nullable<int> max_group_size { get; set; }
        public Nullable<int> min_age { get; set; }
        public Nullable<int> max_age { get; set; }
        public Nullable<int> drade { get; set; }
    
        public virtual cities cities { get; set; }
        public virtual cities cities1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<departures> departures { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<discounts> discounts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<grades> grades { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<images> images { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<included> included { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<itinerary> itinerary { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rooms> rooms { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tour_lists> tour_lists { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wish_lists> wish_lists { get; set; }
    }
}
