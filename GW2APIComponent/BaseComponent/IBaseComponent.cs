using System;

namespace GW2APIComponent.BaseComponents
{
    /// <summary>
    /// Class that inherits from BaseComponent.
    /// Use this class when creating new components.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class IBaseComponent<T> : BaseComponent where T : new()
    {
        /// <summary>
        /// The component name.
        /// </summary>
        static public string ComponentName;
        /// <summary>
        /// The componentTypeID
        /// </summary>
        static public UInt32 typeID;
        /// <summary>
        /// Instanciates the IBaseComponent
        /// </summary>
        /// <param name="componentName">The string name of the component.</param>
        /// <param name="ID">The TypeID of the component use <paramref name="BaseComponent.eComponentTypeIDs"/> enum class to define new IDs if they do not exist</param>
        protected IBaseComponent(string componentName, UInt32 ID)
        {
            ComponentName = componentName;
            typeID = ID;
        }
        /// <summary>
        /// Gets the typeID for that component
        /// </summary>
        /// <returns>The compoent ID.</returns>
        public override UInt32 getType()
        {
            return typeID;
        }
        /// <summary>
        /// Gets the TypeName for that component
        /// </summary>
        /// <returns>The component Name.</returns>
        public override string getTypeName()
        {
            return ComponentName;
        }
    }
}
