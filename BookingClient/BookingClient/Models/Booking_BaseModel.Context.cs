﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Booking_BaseEntities : DbContext
    {
        public Booking_BaseEntities()
            : base("name=Booking_BaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<accounts> accounts { get; set; }
        public virtual DbSet<cities> cities { get; set; }
        public virtual DbSet<countries> countries { get; set; }
        public virtual DbSet<departures> departures { get; set; }
        public virtual DbSet<discounts> discounts { get; set; }
        public virtual DbSet<first_names> first_names { get; set; }
        public virtual DbSet<grades> grades { get; set; }
        public virtual DbSet<images> images { get; set; }
        public virtual DbSet<included> included { get; set; }
        public virtual DbSet<inclusions> inclusions { get; set; }
        public virtual DbSet<itinerary> itinerary { get; set; }
        public virtual DbSet<last_names> last_names { get; set; }
        public virtual DbSet<liked_tours> liked_tours { get; set; }
        public virtual DbSet<order_rooms> order_rooms { get; set; }
        public virtual DbSet<orders> orders { get; set; }
        public virtual DbSet<passed_tours> passed_tours { get; set; }
        public virtual DbSet<persons> persons { get; set; }
        public virtual DbSet<roles> roles { get; set; }
        public virtual DbSet<rooms> rooms { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tours> tours { get; set; }
        public virtual DbSet<viewed_tours> viewed_tours { get; set; }
    }
}
