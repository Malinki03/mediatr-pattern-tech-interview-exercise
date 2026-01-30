using System.Diagnostics.CodeAnalysis;

namespace MediatrExercise.Domain.Entities;

public abstract class Entity
{
    public required long Id { get; init; }

    protected Entity(long id)
    {
        Id = id;
    }
}