﻿namespace BasePoint.Core.Domain.Enumerators
{
    public enum EntityState
    {
        New,
        Persisted,
        Unchanged,
        Updated,
        Deleted,
        PersistedDeleted
    }
}