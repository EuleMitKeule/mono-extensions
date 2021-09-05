using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MonoExtensions.Runtime
{
    public static class GameObjectExtensions
    {
        static Dictionary<GameObject, Component> CachedComponents { get; } =
            new Dictionary<GameObject, Component>();

        public static T GetCachedComponent<T>(this GameObject gameObject) where T : Component
        {
            if (!CachedComponents.ContainsKey(gameObject))
            {
                CachedComponents.Add(gameObject, null);
            }

            if (CachedComponents.TryGetValue(gameObject, out var cachedComponent))
            {
                return cachedComponent as T;
            }

            var uncachedComponent = gameObject.GetComponent<T>();
            if (uncachedComponent) CachedComponents[gameObject] = uncachedComponent;
            return uncachedComponent;
        }

        public static Transform Parent(this GameObject gameObject) =>
            gameObject.transform.parent;

        public static List<Transform> Children(this GameObject gameObject)
        {
            var children = new List<Transform>();

            for (var i = 0; i < gameObject.transform.childCount; i++)
            {
                var child = gameObject.transform.GetChild(i);
                children.Add(child);
            }

            return children;
        }

        public static List<Transform> Siblings(this GameObject gameObject) =>
            gameObject.Parent().Children().Where(e => e.gameObject != gameObject.gameObject).ToList();

        public static Transform FindChild(this GameObject gameObject, string name) =>
            gameObject.transform.Find(name);
    }
}