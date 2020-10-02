﻿using System;

namespace Core.Entities
{
    public abstract class AuditedEntity : Entity, IAuditedEntity
    {
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
