using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperDigital.Api.Messages.Resource
{
    public class MovimentResource
    {
        public DateTime Data { get; set; }
        public string Operacao { get; set; }
        public string Tipo { get; set; }
        public string Valor { get; set; }
        public string Descricao { get; set; }
        public string Conta_Origem { get; set; }
        public string Conta_Destino { get; set; }
    }
}
