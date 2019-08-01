using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Visitors.Domain;

namespace Visitors.Data.Mapping
{
    public class VisitorMap : DbEntityConfiguration<Visitor>
    {
        public override void Configure(EntityTypeBuilder<Visitor> builder)
        {
            builder.ToTable("Visitors");
            builder.HasKey(t => t.Id);
        }
    }
}
