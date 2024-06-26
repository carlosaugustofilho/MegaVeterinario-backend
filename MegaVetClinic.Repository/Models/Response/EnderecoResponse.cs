﻿namespace MegaVetClinic.Repository.Models.Response
{
    public class EnderecoResponse
    {
        public int Id { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int PaisId { get; set; }
    }
}
