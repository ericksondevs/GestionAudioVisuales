
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace DataModel
{

using System;
    using System.Collections.Generic;
    
public partial class Usuarios
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Usuarios()
    {

        this.Rentas = new HashSet<Rentas>();

    }


    public int Id { get; set; }

    public string Nombre { get; set; }

    public string Cedula { get; set; }

    public int No_Carnet { get; set; }

    public int IdTipoUsuario { get; set; }

    public int IdTipoPersona { get; set; }

    public int Estado { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Rentas> Rentas { get; set; }

}

}
