using Meta.Core.Editor;
using Meta.Core.Runtime;
using Meta.ECS.Runtime;
using UnityEditor;

namespace Meta.ECS.Editor
{
    [CustomPropertyDrawer(typeof(MetaRef))]
    public class WorldRefDrawer : MetaRefDrawer<WorldRef, WorldsDatabase>
    {
        
    }
}