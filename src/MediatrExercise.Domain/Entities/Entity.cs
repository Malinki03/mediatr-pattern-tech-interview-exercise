namespace MediatrExercise.Domain.Entities;

public abstract class Entity(long id)
{
    public required long Id = id;
}