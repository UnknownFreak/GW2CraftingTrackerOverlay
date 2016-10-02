using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace OverlayApp.Serialize
{
    static class Serializer
    {
        /// <summary>
        /// Serializes an object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializableObject"> Object to serialize.</param>
        /// <param name="fileName">File to save serialized object to.</param>
        public static void SerializeObject<T>(T serializableObject, string fileName)
        {
            if (serializableObject == null) return;
            try
            {
                XmlDocument xml = new XmlDocument();
                XmlSerializer seri = new XmlSerializer(serializableObject.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    seri.Serialize(stream, serializableObject);
                    stream.Position = 0;
                    xml.Load(stream);
                    xml.Save(fileName);
                    stream.Close();
                }
            }
            catch(Exception ex)
            {
                Logger.Logger.Log(ex.Message, Logger.Logger.MessageType.Error);
            }
        }
        /// <summary>
        /// Deserializes an xml file into an object list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName">File to load object from</param>
        /// <returns></returns>
        public static void DeSerializeObject<T>(out T objectOut,string fileName) where T :new()
        {
            objectOut = new T();
            if (string.IsNullOrEmpty(fileName))
                return;
            if (!File.Exists(fileName))
                return;

            XmlDocument xml = new XmlDocument();
            xml.Load(fileName);
            string xmlString = xml.OuterXml;
            try
            {
                using (StringReader read = new StringReader(xmlString))
                {
                    XmlSerializer seri = new XmlSerializer(typeof(T));
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        objectOut = (T)seri.Deserialize(reader);
                        reader.Close();
                    }
                    read.Close();
                }
            } 
            catch (Exception ex)
            {
                Logger.Logger.Log(ex.Message, Logger.Logger.MessageType.Error);
            }
        }
    }
}
