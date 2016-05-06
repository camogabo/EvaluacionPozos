//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EvaluacionPozosPemex.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public partial class Equipo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Equipo()
        {
            this.Operacions = new HashSet<Operacion>();
        }

        public int EquipoId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Nombre es requerido.")]
        public string Nombre { get; set; }
        [DisplayName("Compa��a")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Compa��a es requerido.")]
        public string Compania { get; set; }
        [DisplayName("Renta Mensual")]
        [Range(0, 9999),Required(AllowEmptyStrings = false, ErrorMessage = "El campo Renta es requerido.")]
    
        public double Renta { get; set; }
        [Required]
        public int RegionId { get; set; }

        public virtual Region Region { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Operacion> Operacions { get; set; }
    }
}