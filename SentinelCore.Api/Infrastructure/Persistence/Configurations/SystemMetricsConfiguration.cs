using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SentinelCore.Api.Domain.Entities;

namespace SentinelCore.Api.Infrastructure.Persistence.Configurations;

public class SystemMetricsConfiguration : IEntityTypeConfiguration<SystemMetrics> {
	public void Configure(EntityTypeBuilder<SystemMetrics> builder) {
		builder.ToTable("system_metrics"); 
     
		builder.HasKey(e => e.Id);

		builder.HasIndex(e => new { e.AgentId, e.Timestamp });

		builder.Property(e => e.AgentId)
			.IsRequired();

		builder.Property(e => e.HostName)
			.IsRequired()
			.HasMaxLength(255); 

		builder.Property(e => e.OperatingSystem)
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(e => e.CpuUsage)
			.IsRequired();

		builder.Property(e => e.MemoryUsage)
			.IsRequired();

		builder.Property(e => e.Timestamp)
			.IsRequired();
	}
}