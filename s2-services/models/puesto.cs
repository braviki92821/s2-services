namespace s2_services.models
{
    public class puesto
    {
        private string nombre;
        private string nivel;

        public puesto()
        {
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Nivel { get => nivel; set => nivel = value; }
    }
}
