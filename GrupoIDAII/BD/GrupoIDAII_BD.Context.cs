﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GrupoIDAII.BD
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GrupoIDAIIEntities1 : DbContext
    {
        public GrupoIDAIIEntities1()
            : base("name=GrupoIDAIIEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<ClientesIDAII> ClientesIDAII { get; set; }
        public virtual DbSet<CuentasPorCobrarIDAII> CuentasPorCobrarIDAII { get; set; }
        public virtual DbSet<MaterialesIDAII> MaterialesIDAII { get; set; }
        public virtual DbSet<ServiciosIDAII> ServiciosIDAII { get; set; }
        public virtual DbSet<ClientesETM> ClientesETM { get; set; }
        public virtual DbSet<CuentasPorCobrarETM> CuentasPorCobrarETM { get; set; }
        public virtual DbSet<MaterialesETM> MaterialesETM { get; set; }
        public virtual DbSet<ServiciosETM> ServiciosETM { get; set; }
    }
}
