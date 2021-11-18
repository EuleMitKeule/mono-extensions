using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MonoExtensions.Runtime
{
    public interface ICachingComponent
    {
        void OnComponentRegistered<TCom>(TCom component) where TCom : Component;
    }

    public static class ComponentExtensions
    {
        static Dictionary<Component, Dictionary<Type, Component[]>> ComponentToCachedCachedComponents { get; } =
            new Dictionary<Component, Dictionary<Type, Component[]>>();

        public static TCom GetCachedComponent<TCom>(this Component component, int index = 0) where TCom : Component
        {
            if (!ComponentToCachedCachedComponents.ContainsKey(component))
            {
                ComponentToCachedCachedComponents.Add(component, new Dictionary<Type, Component[]>());
            }

            var cachedComponents = ComponentToCachedCachedComponents[component];
            var componentType = typeof(TCom);

            if (!cachedComponents.ContainsKey(componentType))
            {
                var uncachedComponents = component.GetComponents<TCom>();

                if (index < 0 || index >= uncachedComponents.Length) return null;

                var uncachedComponent = uncachedComponents[index];
                cachedComponents.Add(componentType, uncachedComponents.ToArray<Component>());

                if (uncachedComponent is ICachingComponent cachingComponent)
                {
                    cachingComponent.OnComponentRegistered(uncachedComponent);
                }
                return uncachedComponent;
            }

            var cachedComponent = cachedComponents[componentType];
            return cachedComponent as TCom;
        }

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