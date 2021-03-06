
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace GradProjectV5.Models
{

using System;
    using System.Collections.Generic;
    
public partial class BeneficierMedicineRequest
{

    public int ID { get; set; }

    public Nullable<int> BeneficierId { get; set; }

    public Nullable<int> DonatorId { get; set; }

    public Nullable<int> MedicineId { get; set; }

    public Nullable<System.DateTime> RequestDate { get; set; }

    public Nullable<System.DateTime> RespondDate { get; set; }

    public Nullable<bool> IsDeleted { get; set; }

    public Nullable<int> LatestStatusId { get; set; }

    public string RequestedAmount { get; set; }

    public string RespondedAmount { get; set; }



    public virtual Medicine Medicine { get; set; }

    public virtual BeneficierMedicineRequest BeneficierMedicineRequest1 { get; set; }

    public virtual BeneficierMedicineRequest BeneficierMedicineRequest2 { get; set; }

    public virtual Member Member { get; set; }

    public virtual Member Member1 { get; set; }

    public virtual Status Status { get; set; }

}

}
