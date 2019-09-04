using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SuperDigital.Api.Messages.Resource
{
    [DataContract]
    public class AccountHolderResource
    {
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = false)]
        public int Id { get; set; }

        [DataMember(Name = "nome", IsRequired = true, EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "documento", IsRequired = true, EmitDefaultValue = false)]
        public string Document { get; set; }

        [DataMember(Name = "numeroConta", IsRequired = true, EmitDefaultValue = false)]
        public string AccountNumber { get; set; }

        [DataMember(Name = "digitoConta", IsRequired = true, EmitDefaultValue = false)]
        public string AccountDigit { get; set; }

        [DataMember(Name = "agencia", IsRequired = true, EmitDefaultValue = false)]
        public string Agency { get; set; }

        [DataMember(Name = "saldo", IsRequired = true, EmitDefaultValue = false)]
        public double AccountBalance { get; set; }
    }
}
