using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpinxTask.Core.Models;

namespace SpinxTask.Core.Configurations
{
    public class ClientConfigurations : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder
                .Property(i => i.Name)
                .HasMaxLength(50)
                .IsRequired();

            

            builder
                .HasIndex(i => i.Code)
                .IsUnique();

            builder.HasOne(i => i.Class)
                .WithMany(ii=>ii.Clients)
                .HasForeignKey(iii=>iii.ClassId);

            builder.HasOne(i => i.Class)
                .WithMany(ii => ii.Clients)
                .HasForeignKey(iii => iii.ClassId);

            builder.HasOne(i => i.State)
                .WithMany(ii => ii.Clients)
                .HasForeignKey(iii => iii.StateId);
        }
    }
}
