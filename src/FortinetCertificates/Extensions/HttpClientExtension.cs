namespace FortinetCertificates.Extensions;

public static class HttpClientExtension
{
    public static async Task ApplyAuthAsync(this HttpClient client, AuthService authService)
    {
        var header = await authService.GetAuthHeaderAsync();
        if (header != null)
        {
            client.DefaultRequestHeaders.Authorization = header;
        }
    }
}
