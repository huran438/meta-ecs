using Leopotam.Ecs;
using UnityEngine;

namespace Meta.ECS.Runtime
{
    [RequireComponent(typeof(MEntity))]
    public abstract class MAuthoring : MonoBehaviour
    {
        public virtual bool KeepAuthoring { get; }

        public abstract void Setup(ref EcsEntity entity);
    }
}