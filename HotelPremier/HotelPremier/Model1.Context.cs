﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelPremier
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HotelPremierEntities : DbContext
    {
        public HotelPremierEntities()
            : base("name=HotelPremierEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Engagment> Engagments { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<HotelUser> HotelUsers { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<QualificationLevel> QualificationLevels { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }
        public virtual DbSet<vwManager> vwManagers { get; set; }
        public virtual DbSet<vwRequest> vwRequests { get; set; }
        public virtual DbSet<vwWorker> vwWorkers { get; set; }
    }
}
