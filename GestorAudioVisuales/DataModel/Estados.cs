
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
    
public partial class Estados
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Estados()
    {

        this.Empleados = new HashSet<Empleados>();

        this.Marcas = new HashSet<Marcas>();

        this.Rentas = new HashSet<Rentas>();

        this.Modelos = new HashSet<Modelos>();

    }


    public int Id { get; set; }

    public string Descripcion { get; set; }

    public int TipoEstado { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Empleados> Empleados { get; set; }

    public virtual TipoEstados TipoEstados { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Marcas> Marcas { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Rentas> Rentas { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Modelos> Modelos { get; set; }

}

}
