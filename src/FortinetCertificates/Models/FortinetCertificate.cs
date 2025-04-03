namespace FortinetCertificates.Models;

public class CertificateResults
{
    [JsonPropertyName("http_method")]
    public string HttpMethod { get; set; }

    [JsonPropertyName("results")]
    public FortinetCertificate[] Results { get; set; }
}

public class FortinetCertificate
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("source")]
    public string Source { get; set; }

    [JsonPropertyName("comments")]
    public string Comments { get; set; }

    [JsonPropertyName("range")]
    public string Range { get; set; }

    [JsonPropertyName("exists")]
    public bool Exists { get; set; }

    [JsonPropertyName("is_ssl_server_cert")]
    public bool IsSslServerCert { get; set; }

    [JsonPropertyName("is_ssl_client_cert")]
    public bool IsSslClientCert { get; set; }

    [JsonPropertyName("is_proxy_ssl_cert")]
    public bool IsProxySslCert { get; set; }

    [JsonPropertyName("is_general_allowable_cert")]
    public bool IsGeneralAllowableCert { get; set; }

    [JsonPropertyName("is_default_local")]
    public bool IsDefaultLocal { get; set; }

    [JsonPropertyName("is_built_in")]
    public bool IsBuiltIn { get; set; }

    [JsonPropertyName("is_wifi_cert")]
    public bool IsWifiCert { get; set; }

    [JsonPropertyName("is_deep_inspection_cert")]
    public bool IsDeepInspectionCert { get; set; }

    [JsonPropertyName("has_valid_cert_key")]
    public bool HasValidCertKey { get; set; }

    [JsonPropertyName("key_type")]
    public string KeyType { get; set; }

    [JsonPropertyName("key_size")]
    public int KeySize { get; set; }

    [JsonPropertyName("cert_protocol")]
    public string CertProtocol { get; set; }

    [JsonPropertyName("is_local_ca_cert")]
    public bool IsLocalCaCert { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("valid_from")]
    public long ValidFrom { get; set; }

    [JsonPropertyName("valid_from_raw")]
    public string ValidFromRaw { get; set; }

    [JsonPropertyName("valid_to")]
    public long ValidTo { get; set; }

    [JsonPropertyName("valid_to_raw")]
    public string ValidToRaw { get; set; }

    [JsonPropertyName("signature_algorithm")]
    public string SignatureAlgorithm { get; set; }

    [JsonPropertyName("subject")]
    public CertificateSubjectIssuer Subject { get; set; }

    [JsonPropertyName("subject_raw")]
    public string SubjectRaw { get; set; }

    [JsonPropertyName("issuer")]
    public CertificateSubjectIssuer Issuer { get; set; }

    [JsonPropertyName("issuer_raw")]
    public string IssuerRaw { get; set; }

    [JsonPropertyName("fingerprint")]
    public string Fingerprint { get; set; }

    [JsonPropertyName("version")]
    public int Version { get; set; }

    [JsonPropertyName("is_ca")]
    public bool IsCa { get; set; }

    [JsonPropertyName("serial_number")]
    public string SerialNumber { get; set; }

    [JsonPropertyName("ext")]
    public List<CertificateExtension> Extensions { get; set; }

    [JsonPropertyName("q_name")]
    public string QName { get; set; }

    [JsonPropertyName("q_static")]
    public bool QStatic { get; set; }

    [JsonPropertyName("q_type")]
    public int QType { get; set; }

    [JsonPropertyName("q_ref")]
    public int QRef { get; set; }
}

public class CertificateSubjectIssuer
{
    [JsonPropertyName("C")]
    public string C { get; set; }

    [JsonPropertyName("ST")]
    public string ST { get; set; }

    [JsonPropertyName("L")]
    public string L { get; set; }

    [JsonPropertyName("O")]
    public string O { get; set; }

    [JsonPropertyName("OU")]
    public string OU { get; set; }

    [JsonPropertyName("CN")]
    public string CN { get; set; }

    [JsonPropertyName("emailAddress")]
    public string EmailAddress { get; set; }
}

public class CertificateExtension
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("data")]
    public string Data { get; set; }

    [JsonPropertyName("critical")]
    public bool Critical { get; set; }
}
