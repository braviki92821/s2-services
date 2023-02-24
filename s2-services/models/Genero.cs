namespace s2_services.models
{
    public class Genero
    {

        private string clave;

        private string valor;

        public Genero() { }

        public Genero(string clave, string valor)
        {
            this.Clave = clave;
            this.Valor = valor;
        }

        public string Clave { get => clave; set => clave = value; }
        public string Valor { get => valor; set => valor = value; }
    }
}
