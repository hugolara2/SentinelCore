namespace SentinelCore.Api.Domain.Entities;

public class SystemMetrics {
	public Guid Id { get; private set; }
	public Guid AgentId { get; private set; }
	public string HostName { get; private set; }
	public string OperatingSystem { get; private set; }
	public double CpuUsage { get; private set; }
	public double MemoryUsage { get; private set; }
	public DateTimeOffset Timestamp { get; private set; }
	
	private SystemMetrics() { }
	
	public SystemMetrics(Guid agentId, string hostName, string operatingSystem, double cpuUsage, double memoryUsage, DateTimeOffset timestamp) {
		if (cpuUsage < 0 || cpuUsage > 100)
			throw new ArgumentOutOfRangeException(nameof(cpuUsage), "CPU usage must be between 0 and 100.");

		if (memoryUsage < 0 || memoryUsage > 100)
			throw new ArgumentOutOfRangeException(nameof(memoryUsage), "Memory usage must be between 0 and 100.");
		
		Id = Guid.NewGuid();
		AgentId = agentId;
		HostName = hostName ?? throw new ArgumentNullException(nameof(hostName));
		OperatingSystem = operatingSystem ?? throw new ArgumentNullException(nameof(operatingSystem));
		CpuUsage = cpuUsage;
		MemoryUsage = memoryUsage;
		Timestamp = timestamp;
	}
}