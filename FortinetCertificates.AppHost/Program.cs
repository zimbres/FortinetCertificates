var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.FortinetCertificates>("fortinetcertificates");

builder.Build().Run();
