//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class MaterialesIDAII
    {
        public int id { get; set; }
        public string proveedor { get; set; }
        public string mes { get; set; }
        public double subtotal { get; set; }
        public double iva { get; set; }
        public double monto { get; set; }
        public string factura { get; set; }
        public System.DateTime fecha_fac { get; set; }
        public int dias_credito { get; set; }
        public System.DateTime fecha_lim { get; set; }
        public string banco { get; set; }
        public string estatus { get; set; }
    }
}
