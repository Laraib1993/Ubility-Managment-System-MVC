﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace kmcmvc.Areas.Admin.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AdminEntities : DbContext
    {
        public AdminEntities()
            : base("name=AdminEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<consumer_rebate> consumer_rebate { get; set; }
        public virtual DbSet<Dapartment_Consumer> Dapartment_Consumer { get; set; }
        public virtual DbSet<kmc_emp_rebate> kmc_emp_rebate { get; set; }
        public virtual DbSet<modify_consumer> modify_consumer { get; set; }
        public virtual DbSet<modify_impact> modify_impact { get; set; }
        public virtual DbSet<MUCTBill_Records> MUCTBill_Records { get; set; }
        public virtual DbSet<muctemployee> muctemployees { get; set; }
        public virtual DbSet<partPayment> partPayments { get; set; }
        public virtual DbSet<propertytype> propertytypes { get; set; }
        public virtual DbSet<Rebate_cancle_history> Rebate_cancle_history { get; set; }
        public virtual DbSet<searchingsheet> searchingsheets { get; set; }
        public virtual DbSet<searchinsheetsuspended> searchinsheetsuspendeds { get; set; }
        public virtual DbSet<subcategoryproperty> subcategoryproperties { get; set; }
        public virtual DbSet<userinfo> userinfoes { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<zone> zones { get; set; }
        public virtual DbSet<invoice> invoices { get; set; }
        public virtual DbSet<modify_invoice> modify_invoice { get; set; }
        public virtual DbSet<town> towns { get; set; }
        public virtual DbSet<accountstatu> accountstatus { get; set; }
        public virtual DbSet<role> roles { get; set; }
    }
}
