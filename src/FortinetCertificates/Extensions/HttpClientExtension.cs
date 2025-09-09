namespace FortinetCertificates.Extensions;

public static class HttpClientExtension
{
    public static void ApplyBasicAuth(this HttpClient client, string username, string password)
    {
        var byteArray = Encoding.ASCII.GetBytes($"{username}:{password}");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
    }
}
