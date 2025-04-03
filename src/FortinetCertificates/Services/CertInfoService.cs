namespace FortinetCertificates.Services;

public class CertInfoService
{
    private readonly ILogger<CertInfoService> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly LogService _logService;
    private HttpClient _httpClient;

    public CertInfoService(ILogger<CertInfoService> logger, HttpClient httpClient, IHttpClientFactory httpClientFactory, LogService logService)
    {
        _logger = logger;
        _httpClient = httpClient;
        _httpClientFactory = httpClientFactory;
        _logService = logService;
    }

    public async Task<FortinetCertificate> GetCert(Firewall firewall)
    {
        _httpClient = _httpClientFactory.CreateClient("IgnoreSSL");
        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {firewall.Token}");

        try
        {
            var uri = $"{firewall.Scheme}://{firewall.Ip}:{firewall.Port}/api/v2/monitor/system/available-certificates?scope=vdom&vdom={firewall.Vdom}&with_ca=1&with_crl=1&with_remote=1";
            var certificateResults = await _httpClient.GetFromJsonAsync<CertificateResults>(uri);
            var fortinetCertificate = certificateResults.Results.FirstOrDefault(c => c.Name == firewall.CertificateName);
            return fortinetCertificate;
        }
        catch (Exception ex)
        {
            await _logService.PushLog(ex.Message, firewall.CertificateName);
            _logger.LogError(ex, "Error getting certificate information");
            return null;
        }
    }
}
