using LionsDen.Models;
using LionsDen.Service;
using System.Collections.Generic;

namespace LionsDen.Stores
{
    internal static class MemberStore
    {

        public static List<Client> ClientList = FileExplorer.LoadMembersData(new Client());
        public static List<Employee> EmployeeList = FileExplorer.LoadMembersData(new Employee());
        public static List<Coach> CoachList = FileExplorer.LoadMembersData(new Coach());

        /*public static void LoadDataToList<TMember>(TMember loadedMember) where TMember : Member
        {
            string memberType = loadedMember.GetType().Name;
            if (memberType == "Client")
            {
                Client loadedClient = new Client();
                Type objectType = loadedMember.GetType();
                PropertyInfo[] properties = objectType.GetProperties();
                foreach(PropertyInfo property in properties)
                {
                    string propertyName = property.Name;

                    object propertyValue = property.GetValue(loadedMember);

                    PropertyInfo matchingProperty = loadedClient.GetType().GetProperty(propertyName);

                    if (matchingProperty != null)
                    {
                        matchingProperty.SetValue(loadedClient, propertyValue);
                    }
                }
                ClientList.Add(loadedClient);
            }

            if (memberType == "Employee")
            {
                Employee loadedEmployee = new Employee();
                Type objectType = loadedMember.GetType();
                PropertyInfo[] properties = objectType.GetProperties();
                foreach(PropertyInfo property in properties)
                {
                    string propertyName = property.Name;

                    object propertyValue1 = property.GetValue(loadedMember);

                    PropertyInfo matchingProperty = loadedEmployee.GetType().GetProperty(propertyName);

                    if (matchingProperty != null)
                    {
                        matchingProperty.SetValue(loadedEmployee, propertyValue1);
                    }
                }
                EmployeeList.Add(loadedEmployee);
            }
            if (memberType == "Coach")
            {
                Coach loadedCoach = new Coach();
                Type objectType = loadedMember.GetType();
                PropertyInfo[] properties = objectType.GetProperties();
                foreach(PropertyInfo property in properties)
                {
                    string propertyName = property.Name;

                    object propertyValue1 = property.GetValue(loadedMember);

                    PropertyInfo matchingProperty = loadedCoach.GetType().GetProperty(propertyName);

                    if (matchingProperty != null)
                    {
                        matchingProperty.SetValue(loadedCoach, propertyValue1);
                    }
                }
                CoachList.Add(loadedCoach);
            }
        }*/
    }
}
