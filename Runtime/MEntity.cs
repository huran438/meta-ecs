using System;
using Adic;
using Leopotam.Ecs;
using LeopotamGroup.Globals;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Meta.ECS.Runtime
{
    [SelectionBase]
    [DisallowMultipleComponent]
    public class MEntity : MonoBehaviour
    {
        public EcsEntity Entity => _entity;

        private EcsEntity _entity = EcsEntity.Null;

        [HideInInspector]
        [SerializeField]
        private MAuthoring[] _cachedAuthorings = Array.Empty<MAuthoring>();

#if UNITY_EDITOR

        [Button]
        public void CacheAuthorings()
        {
            _cachedAuthorings = GetComponents<MAuthoring>();
        }

#endif

        [Inject]
        protected void Init(IWorldsService worldsService)
        {
            var _transform = transform;

            _entity = worldsService.World.NewEntity();

            _entity.Replace(new GameObjectRef
            {
                GameObject = gameObject
            });

            _entity.Replace(new TransformRef
            {
                Transform = _transform
            });

            if (_cachedAuthorings.Length == 0)
            {
                _cachedAuthorings = GetComponents<MAuthoring>();
            }

            foreach (var authoring in _cachedAuthorings)
            {
                authoring.Setup(ref _entity);
            }
        }

        private void OnDestroy()
        {
            if (!_entity.IsNull() && _entity.IsAlive())
            {
                _entity.Destroy();
            }
        }
    }
}