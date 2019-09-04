using System;

namespace SuperDigital.Common.Exceptions
{
    public class CannotChangeStatusOfADeletedEntityException : Exception
    {
        public CannotChangeStatusOfADeletedEntityException()
            : base("Não é possível alterar o status de uma entidade deletada.")
        {
        }
    }
}
