using Adic.Extensions.MonoInjection;
using Leopotam.Ecs;
using UnityEngine;

namespace Meta.ECS.Runtime
{
    public static class MExtensions
    {
        public static EcsEntity Instantiate(this MEntity prefab, Vector3 position, Quaternion rotation)
        {
            var obj = Object.Instantiate(prefab, position, rotation);
            InjectionUtil.Inject(obj);
            return obj.Entity;
        }
        
        public static EcsEntity Instantiate(this MEntity prefab)
        {
            var obj = Object.Instantiate(prefab);
            InjectionUtil.Inject(obj);
            return obj.Entity;
        }
        
        public static EcsEntity Instantiate(this MEntity prefab, Transform parent)
        {
            var obj = Object.Instantiate(prefab, parent);
            InjectionUtil.Inject(obj);
            return obj.Entity;
        }
        
        public static EcsEntity Instantiate(this MEntity prefab, Vector3 position, Transform parent)
        {
            var obj = Object.Instantiate(prefab, position, Quaternion.identity, parent);
            InjectionUtil.Inject(obj);
            return obj.Entity;
        }
        
        public static EcsEntity Instantiate(this MEntity prefab, Vector3 position, Quaternion rotation, Transform parent)
        {
            var obj = Object.Instantiate(prefab, position, rotation, parent);
            InjectionUtil.Inject(obj);
            return obj.Entity;
        }
    }
}