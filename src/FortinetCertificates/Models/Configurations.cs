namespace FortinetCertificates.Models;

public class Configurations
{
    public int Delay { get; set; }
    public string SSLTrackApiAddress { get; set; }
    public string GetDomainsEndpoint { get; set; }
    public string UpdateDomainEndpoint { get; set; }
    public string LogEndpoint { get; set; }
    public string PingEndpoint { get; set; }
    public int AgentId { get; set; }
    public List<Firewall> Firewalls { get; set; }
}

public class Firewall
{
    public string Name { get; set; }
    public string Ip { get; set; }
    public int Port { get; set; }
    public string Scheme { get; set; }
    public string Vdom { get; set; }
    public string CertificateName { get; set; }
    public string Token { get; set; }
}
