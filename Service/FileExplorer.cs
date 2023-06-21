using LionsDen.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace LionsDen.Service
{
    class FileExplorer
    {
        private static string _userHomeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        private static string _mainFolderPath = @$"{_userHomeDirectory}\\Documents\\";
        private static string _inMainFolderPath = Path.Combine(_mainFolderPath, "LionsDenGYM");

        public static bool RegistrateMemberSuccessfully<TMember>(TMember updatedMember) where TMember : Member
        {
            string memberTypeName = updatedMember.GetType().Name;
            string inThisMemberFolderPath = Path.Combine(_inMainFolderPath, memberTypeName, updatedMember.TaxId);

            if (IsMemberRegistered(updatedMember))
            {
                MessageBox.Show($"This member is already registered!");
                return false;
            }
            else
            {
                Directory.CreateDirectory(inThisMemberFolderPath);
                string fileName = $"{updatedMember.TaxId}info.json";
                string fullPath = Path.Combine(inThisMemberFolderPath, fileName);
                string data = JsonConvert.SerializeObject(updatedMember);
                File.WriteAllText(fullPath, data);
                MessageBox.Show($"{memberTypeName} successfully registered!");
                return true;
            }
        }


        public static bool IsMemberRegistered<TMember>(TMember checkedMember) where TMember : Member
        {
            string memberTypeName = checkedMember.GetType().Name;
            string inThisMemberFolderPath = Path.Combine(_inMainFolderPath, memberTypeName, checkedMember.TaxId);

            if (Directory.Exists(inThisMemberFolderPath))
            {
                return true;
            }

            foreach (Type memberType in GetInheritedMemberTypes())
            {
                if (memberType != checkedMember.GetType())
                {
                    string otherMemberFolderPath = Path.Combine(_inMainFolderPath, memberType.Name, checkedMember.TaxId);
                    if (Directory.Exists(otherMemberFolderPath))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static IEnumerable<Type> GetInheritedMemberTypes()
        {
            Type memberType = typeof(Member);
            Assembly assembly = Assembly.GetAssembly(memberType);
            return assembly.GetTypes().Where(type => type != memberType && memberType.IsAssignableFrom(type));
        }

        public static List<TMember> LoadMembersData<TMember>(TMember ListType) where TMember : Member
        {
            List<TMember> members = new List<TMember>();
            string directoryPath = Path.Combine(_inMainFolderPath, ListType.GetType().Name);

            if (Directory.Exists(directoryPath))
            {
                string[] folderNames = Directory.GetFileSystemEntries(directoryPath);

                foreach (string folderName in folderNames)
                {
                    string fileName = Directory.GetFiles(folderName, "*info.json").FirstOrDefault();
                    if (!string.IsNullOrEmpty(fileName))
                    {
                        string fileContent = File.ReadAllText(fileName);
                        TMember member = JsonConvert.DeserializeObject<TMember>(fileContent);
                        members.Add(member);
                    }
                }
            }
            return members;
        }

        public static void DeleteMemberData<TMember>(TMember member) where TMember : Member
        {
            string directoryPath = Path.Combine(_inMainFolderPath, member.GetType().Name, member.TaxId);
            Directory.Delete(directoryPath, true);
            MessageBox.Show($"{member.GetType().Name} successfully deleted!");
        }

        public static void UpdateMemberData<TMember>(TMember member, char sourceLetter) where TMember : Member
        {
            string directoryPath = Path.Combine(_inMainFolderPath, member.GetType().Name, member.TaxId);
            string fileName = Path.Combine(directoryPath, $"{member.TaxId}info.json");
            string jsonData = JsonConvert.SerializeObject(member, Formatting.Indented);
            File.WriteAllText(fileName, jsonData);
            if (sourceLetter == 'u')
            {
            MessageBox.Show($"{member.GetType().Name} data successfully updated!");
            }
            else if (sourceLetter == 'i')
            {
                MessageBox.Show($"{member.GetType().Name} successfully logged in!");
            }
            else if (sourceLetter == 'o')
            {
                MessageBox.Show($"{member.GetType().Name} successfully logged out!");
            }
        }
    }
}
