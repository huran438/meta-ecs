using System.Collections.Generic;
using Meta.Core.Runtime;
using UnityEngine;

namespace Meta.ECS.Runtime
{
    public class WorldsDatabase : MDatabase
    {
        [SerializeField]
        private WorldContainer[] _worldContainers = new WorldContainer[0];

        protected override void GenerateGuidPathPairs(ref Dictionary<string, string> value)
        {
            foreach (var worldContainers in _worldContainers)
            {
                if (string.IsNullOrEmpty(worldContainers.Guid)) continue;
                value[worldContainers.Guid] = worldContainers.Name;
            }
        }
    }
}