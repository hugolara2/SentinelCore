using System.Reflection;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using SentinelCore.Api.Domain.Entities;

namespace SentinelCore.Api.Infrastructure.Persistence;

public class SentinelCoreDbContext : DbContext {
	public SentinelCoreDbContext(DbContextOptions<SentinelCoreDbContext> options) : base(options) { }
	
	public DbSet<SystemMetrics> SystemMetrics => Set<SystemMetrics>();
	public DbSet<AgentIdentity> AgentIdentities => Set<AgentIdentity>();
	
	protected override void OnModelCreating(ModelBuilder builder) {
		base.OnModelCreating(builder);
		
		builder.HasDefaultSchema("telemetry");
		
		builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}
}