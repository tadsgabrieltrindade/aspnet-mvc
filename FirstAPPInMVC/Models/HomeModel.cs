namespace FirstAPPInMVC.Models
{
    public class HomeModel
    {
        public string nome { get; set; }
        public string email { get; set; }

        public HomeModel(string nome, string email)
        {
            this.nome = nome;
            this.email = email;
        }

        public HomeModel() {}
    }
}
