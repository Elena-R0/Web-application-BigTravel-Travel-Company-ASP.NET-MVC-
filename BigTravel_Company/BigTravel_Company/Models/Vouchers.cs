//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BigTravel_Company.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Vouchers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vouchers()
        {
            this.Orders = new HashSet<Orders>();
        }
    
        public int id_vouchers { get; set; }
        public string name_vouchers { get; set; }
        public Nullable<int> id_route { get; set; }
        public Nullable<int> id_hotel { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]

        public Nullable<System.DateTime> Departure_date { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public Nullable<System.DateTime> Date_arrival { get; set; }
        public string Information_vouchers { get; set; }
        public string Excursions { get; set; }
        public string image { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<int> number_trips { get; set; }
    
        public virtual hotel hotel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual Route Route { get; set; }
    }
}
