using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnityExtensions.Runtime
{
    public static class GameObjectExtensions
    {
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