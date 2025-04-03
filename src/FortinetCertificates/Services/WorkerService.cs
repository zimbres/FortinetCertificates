namespace FortinetCertificates.Services;

public class WorkerService
{
    private readonly ILogger<AgentService> _logger;
    private readonly Configurations _configurations;
    private readonly CertInfoService _certInfoService;
    private readonly AgentService _agentService;

    public WorkerService(ILogger<AgentService> logger, IConfiguration configuration, CertInfoService certInfoService, AgentService agentService)
    {
        _logger = logger;
        _configurations = configuration.GetSection("Configurations").Get<Configurations>();
        _certInfoService = certInfoService;
        _agentService = agentService;
    }

    public async Task ProcessDomains()
    {
        var domains = await _agentService.GetDomains();

        if (domains is not null)
        {
            foreach (var domain in domains)
            {
                var firewall = _configurations.Firewalls.FirstOrDefault(fw => fw.CertificateName == domain.DomainName);
                var port = _configurations.Firewalls.FirstOrDefault(fw => fw.CertificateName == domain.DomainName)?.Port;

                if(firewall is null)
                {
                    continue;
                }

                var fortinetCertificate = await _certInfoService.GetCert(firewall);

                if (fortinetCertificate is null)
                {
                    continue;
                }

                var payload = new Domain
                {
                    DomainName = domain.DomainName,
                    Port = port ?? 0,
                    CertCN = fortinetCertificate.Subject.CN,
                    Issuer = fortinetCertificate.Issuer.CN,
                    ExpiryDate = DateTime.Parse(fortinetCertificate.ValidToRaw),
                    LastChecked = DateTime.Now,
                    UserId = domain.UserId,
                    Agent = domain.Agent,
                    Silenced = domain.Silenced,
                    Id = domain.Id,
                };
                await _agentService.UpdateDomain(payload);
            }
        }
    }
}
