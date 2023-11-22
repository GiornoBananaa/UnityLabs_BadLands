using UnityEngine;

namespace Utils
{
    public static class LayersUtility
    {
        public static bool Contains(LayerMask layerMask, int layer)
        {
            return layerMask == (layerMask | (1 << layer));
        }
        
        public static bool Contains(LayerMask layerMask, Collision2D collision)
        {
            return layerMask == (layerMask | (1 << collision.gameObject.layer));
        }
        
        public static bool Contains(LayerMask layerMask, Collider2D collider)
        {
            return layerMask == (layerMask | (1 << collider.gameObject.layer));
        }
    }
}
