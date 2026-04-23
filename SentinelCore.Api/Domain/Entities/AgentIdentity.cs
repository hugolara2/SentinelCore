namespace SentinelCore.Api.Domain.Entities;

public class AgentIdentity {
	public Guid Id { get; private set; }
	public string SecretKey { get; private set; }
	public DateTimeOffset LastSeen { get; private set; }
	
	private AgentIdentity() { }
	
	public AgentIdentity(string secretKey, DateTimeOffset lastSeen) {
		Id = Guid.NewGuid();
		SecretKey = secretKey ?? throw new ArgumentNullException(nameof(secretKey));
		LastSeen = lastSeen;
	}
	
	public DateTimeOffset UpdateLastSeen() {
		LastSeen = DateTimeOffset.UtcNow;
		return LastSeen;
	} 
}