using System;
using System.Collections.Generic;
using GW2APIComponent.BaseComponents;
namespace GW2APIComponent
{
    public class GW2Object
    {
        internal Dictionary<UInt32, BaseComponent> componentMap;
        
        /// <summary>
        /// Default Ctor.
        /// </summary>
        public GW2Object()
        {
            componentMap = new Dictionary<uint, BaseComponent>();
        }
        /// <summary>
        /// Adds a component to the Object.
        /// </summary>
        /// <typeparam name="T">The Component type to add.</typeparam>
        /// <param name="args">The argument list for that component. Use null for default Ctor.</param>
        /// <returns>The added component.</returns>
        public T AddComponent<T>(object [] args) where T : IBaseComponent<T>, new()
        {
            UInt32 a = IBaseComponent<T>.typeID;
            if(!componentMap.ContainsKey(a))
            {
                BaseComponent componentToAttach = Activator.CreateInstance(typeof(T),args) as T;
                componentToAttach.attachOn(this);
                return componentToAttach as T;
            }
            return null;
        }
        /// <summary>
        /// Adds a component to the Object.
        /// </summary>
        /// <param name="component">The component to add.</param>
        /// <returns>The BaseComponent Reference for the added component.</returns>
        public BaseComponent AddComponent(BaseComponent component)
        {
            if (!componentMap.ContainsKey(component.getType()))
            {
                component.attachOn(this);
                return component;
            }
            return null;
        }
        /// <summary>
        /// Gets a component from the Object.
        /// </summary>
        /// <typeparam name="T">The component to get.</typeparam>
        /// <returns>The component, null if not found.</returns>
        public T GetComponent<T>() where T : IBaseComponent<T>, new()
        {
            if(componentMap.ContainsKey(IBaseComponent<T>.typeID))
            {
                return componentMap[IBaseComponent<T>.typeID] as T;
            }
            return null;
        }
    }
}
