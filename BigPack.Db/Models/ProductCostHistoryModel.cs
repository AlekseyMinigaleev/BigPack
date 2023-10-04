namespace BigPack.Db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductCostHistory")]
    public partial class ProductCostHistoryModel
    {
        public int ID { get; set; }

        public int ProductID { get; set; }

        public DateTime ChangeDate { get; set; }

        public decimal CostValue { get; set; }

        public virtual ProductModel Product { get; set; }
    }
}
