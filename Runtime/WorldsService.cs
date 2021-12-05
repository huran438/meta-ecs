using System;
using System.Collections.Generic;
using Leopotam.Ecs;

namespace Meta.ECS.Runtime
{
    public class WorldsService : IWorldsService
    {
        private readonly Dictionary<Guid, EcsWorld> _ecsWorlds = new Dictionary<Guid, EcsWorld>();
        private readonly Dictionary<Guid, bool> _ecsWorldsStates = new Dictionary<Guid, bool>();

        public WorldsService()
        {
            World = new EcsWorld();
            _ecsWorlds[Guid.Empty] = World;
            _ecsWorldsStates[Guid.Empty] = true;
        }

        public EcsWorld World { get; private set; }
        public void HotReload()
        {
            World.Destroy();
            World = new EcsWorld();
        }

        public EcsWorld GetWorld(Guid guid)
        {
            return _ecsWorlds.ContainsKey(guid) ? _ecsWorlds[guid] : _ecsWorlds[Guid.Empty];
        }

        public bool IsWorldStarted(Guid guid)
        {
            return !_ecsWorldsStates.ContainsKey(guid) || _ecsWorldsStates[guid];
        }

        public EcsWorld CreateWorld(out Guid guid, bool started = true)
        {
            var ecsWorld = new EcsWorld();
            guid = new Guid();
            _ecsWorlds[guid] = ecsWorld;
            _ecsWorldsStates[guid] = started;
            return ecsWorld;
        }

        public void StartWorld(Guid guid)
        {
            if (guid == Guid.Empty) return;
            if (!_ecsWorldsStates.ContainsKey(guid)) return;
            _ecsWorldsStates[guid] = true;
        }

        public void PauseWorld(Guid guid)
        {
            if (guid == Guid.Empty) return;
            if (!_ecsWorldsStates.ContainsKey(guid)) return;
            _ecsWorldsStates[guid] = true;
        }

        public void DestroyWorld(Guid guid)
        {
            if (guid == Guid.Empty) return;
            if (!_ecsWorldsStates.ContainsKey(guid)) return;
            _ecsWorlds[guid].Destroy();
            _ecsWorlds.Remove(guid);
            _ecsWorldsStates.Remove(guid);
        }

        public void Destroy()
        {
            foreach (var ecsWorld in _ecsWorlds)
            {
                ecsWorld.Value.Destroy();
            }

            _ecsWorlds.Clear();
            _ecsWorldsStates.Clear();
        }
    }
}