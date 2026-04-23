using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SentinelCore.Api.Domain.Entities;

namespace SentinelCore.Api.Infrastructure.Persistence.Configurations;

public class AgentIdentityConfiguration : IEntityTypeConfiguration<AgentIdentity> {
	public void Configure(EntityTypeBuilder<AgentIdentity> builder) {
		builder.ToTable("agent_identity");

		builder.HasKey(e => e.Id);
		
		builder.Property(e => e.SecretKey)
			.HasMaxLength(256)
			.IsRequired();
		builder.Property(e => e.LastSeen)
			.IsRequired();

		builder.HasIndex(e => e.LastSeen);
	}
}