using s2_services.models;

namespace s2_services.repository
{
    public interface ISpic
    {
        Task Agregar(Spic spic);

        Task<List<Spic>> ObtenerDatos();

        Task<Spic> ObtenerDatoPordatos();
    }
}
