namespace VicGenesis2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelForRank : DbContext
    {
        public ModelForRank()
            : base("name=ModelForRank")
        {
        }

        public virtual DbSet<VicTown> VicTowns { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
