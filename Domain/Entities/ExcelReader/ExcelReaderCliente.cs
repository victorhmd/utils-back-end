using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.ExcelReader
{
    public class ExcelReaderCliente
    {
        public ExcelReaderCliente() { }
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Telefone { get; set; }
        public char TipoPessoa  { get; set; }
        public  long CodCliente { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Email { get; set; }
    }
}
