using System;
using System.Net;
using System.Runtime.Serialization.Json;

namespace GW2APIComponent.BaseComponents
{
    /// <summary>
    /// Base component that you should never inherit from.
    /// </summary>
    public abstract class BaseComponent
    {
        /// <summary>
        /// Gets the typeID for that component
        /// </summary>
        /// <returns>TypeID</returns>
        public abstract uint getType();
        /// <summary>
        /// Gets the typeName for that component
        /// </summary>
        /// <returns>The name of the component</returns>
        public abstract string getTypeName();
        /// <summary>
        /// Function that updates the component.
        /// Not used.
        /// </summary>
        public virtual void update()
        {

        }
        internal virtual void attachOn(GW2Object attachTo)
        {
            attachedOn = attachTo;
            attachedOn.componentMap.Add(getType(), this);
        }
        /// <summary>
        /// Gets a component.
        /// </summary>
        /// <typeparam name="T">The component to request</typeparam>
        /// <returns>The component if it exists, null otherwise.</returns>
        protected virtual T GetComponent<T>() where T : IBaseComponent<T>, new()
        {
            return attachedOn.GetComponent<T>();
        }
        /// <summary>
        /// Reeusts JSON data from the web.
        /// </summary>
        /// <typeparam name="T">The type of data that is requested</typeparam>
        /// <param name="url">The url to fetch desired data.</param>
        /// <returns>Instanciated object of type <typeparamref name="T"/></returns>
        public static T requestJSON<T>(string url) where T : new()
        {
            byte[] json = null;
            T tmp = new T();
            using (WebClient wc = new WebClient())
            {
                try
                {
                    json = wc.DownloadData(url);
                }
                catch (System.Net.WebException)
                {
                    throw;
                }
                finally
                {
                    if(json != null)
                    { 
                        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                        tmp = (T)serializer.ReadObject(new System.IO.MemoryStream(json));
                    }
                }
            }
            return tmp;
        }
        /// <summary>
        /// The object the component is attached on.
        /// </summary>
        protected GW2Object attachedOn;
        /// <summary>
        /// The URL string used with the requestJSON function.
        /// </summary>
        protected string URL;
    }
}
