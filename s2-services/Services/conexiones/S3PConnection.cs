namespace s2_services.Services.conexiones
{
    public class S3PConnection
    {
        public string ConnectionString { get; set; } = null!;
        public string DataBaseName { get; set; } = null!;
        public string S3PCollectionName { get; set; } = null!;
    }
}
