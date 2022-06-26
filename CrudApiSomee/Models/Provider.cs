namespace CrudApiSomee.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Provider
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public string lastname { get; set; }

        [Required]
        [StringLength(10)]
        public string phone { get; set; }

        [Required]
        [StringLength(50)]
        public string location { get; set; }

        [Required]
        [StringLength(50)]
        public string suburb { get; set; }

        public int municipality { get; set; }

        public int entity { get; set; }

        [Required]
        [StringLength(50)]
        public string rfc { get; set; }

        public virtual Entity Entity1 { get; set; }

        public virtual Municipality Municipality1 { get; set; }
    }
}
