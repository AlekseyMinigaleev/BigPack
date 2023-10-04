namespace BigPack.Db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Material")]
    public partial class MaterialModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MaterialModel()
        {
            MaterialCountHistories = new HashSet<MaterialCountHistory>();
            ProductMaterials = new HashSet<ProductMaterialModel>();
            Suppliers = new HashSet<SupplierModel>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public int CountInPack { get; set; }

        [Required]
        [StringLength(50)]
        public string Unit { get; set; }

        public int CountInStock { get; set; }

        public int MinCount { get; set; }

        public string Description { get; set; }

        public decimal Cost { get; set; }

        public string Image { get; set; }

        public int MaterialTypeID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialCountHistory> MaterialCountHistories { get; set; }

        public virtual MaterialTypeModel MaterialType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductMaterialModel> ProductMaterials { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SupplierModel> Suppliers { get; set; }
    }
}
