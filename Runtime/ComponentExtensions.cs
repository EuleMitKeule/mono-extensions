using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnityExtensions.Runtime
{
    public static class ComponentExtensions
    {
        public static void AddComponent<T>(this Component component) where T : Component =>
            component.gameObject.AddComponent<T>();

        public static void AddComponent(this Component component, Type componentType) =>
            component.gameObject.AddComponent(componentType);

        public static Transform Parent(this Component component) =>
            component.transform.parent;

        public static List<Transform> Children(this Component component)
        {
            var children = new List<Transform>();

            for (var i = 0; i < component.transform.childCount; i++)
            {
                var child = component.transform.GetChild(i);
                children.Add(child);
            }

            return children;
        }

        public static List<Transform> Siblings(this Component component) =>
            component.Parent().Children().Where(e => e.gameObject != component.gameObject).ToList();

        public static Transform FindChild(this Component component, string name) =>
            component.transform.Find(name);
    }
}