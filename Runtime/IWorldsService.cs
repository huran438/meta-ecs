using Leopotam.Ecs;

namespace Meta.ECS.Runtime
{
    public interface IWorldsService
    {
        EcsWorld DefaultWorld { get; }
    }
}