//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApiTEColones
{
    using System;
    using System.Collections.Generic;
    
    public partial class Promocion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Promocion()
        {
            this.CambioMaterialEstudiantes = new HashSet<CambioMaterialEstudiante>();
        }
    
        public int IdPromocion { get; set; }
        public string NombrePromocion { get; set; }
        public string DescripcionPromocion { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public bool EstadoPromocion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CambioMaterialEstudiante> CambioMaterialEstudiantes { get; set; }
    }
}
