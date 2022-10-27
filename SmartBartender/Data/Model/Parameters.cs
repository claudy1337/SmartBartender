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
    using System.Collections.Generic;
    
    public partial class Parameters
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Parameters()
        {
            this.DropHistory = new HashSet<DropHistory>();
        }
    
        public int id { get; set; }
        public Nullable<int> idAlcohol { get; set; }
        public Nullable<int> idMoodType { get; set; }
        public Nullable<int> idAgeType { get; set; }
        public Nullable<int> idTimesOfDay { get; set; }
        public Nullable<int> idLevelType { get; set; }
    
        public virtual AgeType AgeType { get; set; }
        public virtual Alcohol Alcohol { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DropHistory> DropHistory { get; set; }
        public virtual LevelType LevelType { get; set; }
        public virtual MoodType MoodType { get; set; }
        public virtual TimesOfDayType TimesOfDayType { get; set; }
    }
}
