﻿using System;
namespace Payments.Domain.Exceptions
{
    public class EntityNotFoundException : ExceptionBase
    {
        public override string Code => "entity_not_found";

        public EntityNotFoundException(string message) : base(message)
        {

        }
    }
}