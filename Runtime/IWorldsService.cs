using Leopotam.Ecs;

namespace Meta.ECS.Runtime
{
    public interface IWorldsService
    {
        EcsWorld World { get; }
        void HotReload();
    }
}