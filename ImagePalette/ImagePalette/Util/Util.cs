using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ImagePalette
{
    /// <summary>
    /// Miscellaneous utility methods.
    /// </summary>
    public static class Util
    {
        public static void SerializeToXmlFile(Object obj, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            TextWriter tw = new StreamWriter(fileName);

            try
            {
                serializer.Serialize(tw, obj);
            }
            finally
            {
                tw.Close();
            }
        }

        /// <summary>
        /// Deserializes an object from an XML file.
        /// The file must have that object only.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Object DeserializeFromXmlFile(string fileName, Type type)
        {
            return DeserializeFromStream(new FileStream(fileName, FileMode.Open), type);
        }

        public static Object DeserializeFromString(string str, Type type)
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(str);
            return DeserializeFromStream(new MemoryStream(byteArray), type);
        }

        public static Object DeserializeFromStream(Stream stream, Type type)
        {
            XmlSerializer serializer = new XmlSerializer(type);
            Object obj;
            try
            {
                obj = serializer.Deserialize(stream);
            }
            finally
            {
                stream.Close();
            }

            return obj;
        }

        /// <summary>
        /// Method to convert a custom Object to XML string
        /// </summary>
        /// <param name="obj">Object that is to be serialized to XML</param>
        /// <returns>XML string</returns>
        public static string SerializeToString(Object obj)
        {
            MemoryStream memoryStream = new MemoryStream();
            XmlSerializer xs = new XmlSerializer(obj.GetType());
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

            xs.Serialize(xmlTextWriter, obj);
            memoryStream = (MemoryStream)xmlTextWriter.BaseStream;

            return System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());
        }

        /// <summary>
        /// Get the MemberInfo with strong typing.
        /// 
        /// Usage:
        /// class SomeClass {
        ///   public string SomeProperty { get; set; }
        /// }
        /// MemberInfo member = GetMemberInfo((SomeClass s) => s.SomeProperty);
        /// Console.WriteLine(member.Name); // prints "SomeProperty" on the console
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static MemberInfo GetMemberInfo<TObject, TProperty>(Expression<Func<TObject, TProperty>> expression)
        {
            var member = expression.Body as MemberExpression;
            if (member != null)
            {
                return member.Member;
            }

            throw new ArgumentException("expression");
        }
    }
}
