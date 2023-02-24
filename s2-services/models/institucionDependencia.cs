namespace s2_services.models
{
    public class institucionDependencia
    {
        private string nombre;
        private string siglas;
        private string clave;

        public institucionDependencia()
        {
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Siglas { get => siglas; set => siglas = value; }
        public string Clave { get => clave; set => clave = value; }
    }
}
