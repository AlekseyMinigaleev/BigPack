namespace BigPack.Db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AgentPriorityHistory")]
    public partial class AgentPriorityHistoryModel
    {
        public int ID { get; set; }

        public int AgentID { get; set; }

        public DateTime ChangeDate { get; set; }

        public int PriorityValue { get; set; }

        public virtual AgentModel Agent { get; set; }
    }
}
