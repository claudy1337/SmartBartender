//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartBartender.Data.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SmartBartenderEntities : DbContext
    {
        public SmartBartenderEntities()
            : base("name=SmartBartenderEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Alcohol> Alcohol { get; set; }
        public virtual DbSet<Authorization> Authorization { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<DropHistory> DropHistory { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<isActive> isActive { get; set; }
        public virtual DbSet<LevelType> LevelType { get; set; }
        public virtual DbSet<MoodType> MoodType { get; set; }
        public virtual DbSet<Parameters> Parameters { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TimesOfTheDay> TimesOfTheDay { get; set; }
    }
}
