namespace s2_services.Services.conexiones
{
    public class S3SConnection
    {
        public string ConnectionString { get; set; } = null!;
        public string DataBaseName { get; set; } = null!;
        public string S3SCollectionName { get; set; } = null!;
    }
}
