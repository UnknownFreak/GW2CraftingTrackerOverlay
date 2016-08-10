using System;
using System.Collections.Generic;
using GW2APIComponent.BaseComponents;
namespace GW2APIComponent
{
    public class GW2Object
    {
        internal Dictionary<UInt32, BaseComponent> componentMap;
        
        public GW2Object()
        {
            componentMap = new Dictionary<uint, BaseComponent>();
        }
        
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
        public BaseComponent AddComponent(BaseComponent component)
        {
            if (!componentMap.ContainsKey(component.getType()))
            {
                component.attachOn(this);
                return component;
            }
            return null;
        }
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
