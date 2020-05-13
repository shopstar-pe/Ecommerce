using System;
namespace Payments.Domain.Exceptions
{
    public class EntityBusinessException : ExceptionBase
    {
        public override string Code => "entity_bad_request";

        public EntityBusinessException(string message) : base(message)
        {

        }
    }
}
