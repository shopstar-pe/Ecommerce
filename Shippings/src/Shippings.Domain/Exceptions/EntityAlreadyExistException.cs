﻿using System;
namespace Shippings.Domain.Exceptions
{
    public class EntityAlreadyExistException : ExceptionBase
    {
        public override string Code => "entity_already_exists";

        public EntityAlreadyExistException(string message) : base(message)
        {

        }
    }
}
