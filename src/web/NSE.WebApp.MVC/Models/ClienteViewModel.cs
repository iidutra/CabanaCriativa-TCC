using System;

namespace NSE.WebApp.MVC.Models
{
    public class ClienteViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public EnderecoViewModel Endereco { get; set; }
    }

}
