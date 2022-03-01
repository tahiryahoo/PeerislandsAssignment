using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Http;
using XmlProcessorLibrary.Models;

namespace XmlProcessorLibrary.Utilites
{
    public static class XmlUtility
    {
        /// <summary>
        /// Write List of Employees in Employees.xml file
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns>Write file status</returns>
        public static bool WriteXML<T>(List<T> employeeModel)
        {
            try
            {
                XmlSerializer writer =
                    new XmlSerializer(typeof(List<T>));

                var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + $"//{typeof(T).Name}.xml";
                FileStream file = File.Create(path);

                writer.Serialize(file, employeeModel);
                file.Close();

                return true;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Method used for read Employees.xml for given location and return employee list
        /// </summary>
        /// <returns>Employees list</returns>
        public static List<T> ReadXML<T>()
        {
            try
            {
                XmlSerializer reader = new XmlSerializer(typeof(List<T>));
                var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + $"//{typeof(T).Name}.xml";
                if (!File.Exists(path))
                {
                    return new List<T>();
                }
                StreamReader file = new StreamReader(path);
                var employeeModels = (List<T>)reader.Deserialize(file);
                file.Close();

                return employeeModels;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
