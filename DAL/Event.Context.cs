﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EventDBEntities : DbContext
    {
        public EventDBEntities()
            : base("name=EventDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BookingDetail> BookingDetails { get; set; }
        public virtual DbSet<BookingEquipment> BookingEquipments { get; set; }
        public virtual DbSet<BookingFlower> BookingFlowers { get; set; }
        public virtual DbSet<BookingFood> BookingFoods { get; set; }
        public virtual DbSet<BookingLight> BookingLights { get; set; }
        public virtual DbSet<BookingVenue> BookingVenues { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Flower> Flowers { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<Light> Lights { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Venue> Venues { get; set; }
    }
}