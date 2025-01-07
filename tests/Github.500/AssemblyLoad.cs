using System.Reflection;
using System;

namespace Microsoft.Kiota.Github._500
{
    public class AssemblyLoad
    {
        //Note you need to manually build the bundle package in release configuration.
        private FileInfo[] GetFiles()
        {
            string folder = "..\\..\\..\\..\\..\\src\\bundle\\bin\\Release\\net8.0";
            DirectoryInfo location = new DirectoryInfo(folder);
            return location.GetFiles("*.dll", SearchOption.AllDirectories);
        }

        [Fact]
        public void LoadFile()
        {
            foreach(FileInfo fileInfo in GetFiles())
            {
                try
                {
                    var file = fileInfo.FullName;
                    var assembly = Assembly.LoadFile(file);
                    var types = assembly.GetTypes();
                    Console.WriteLine("{0} has been loaded with {1} types", fileInfo.Name, types.Count());
                }
                catch(Exception exc)
                {
                    Assert.Fail(exc.Message);
                }
            }
            Assert.True(true);
        }

        [Fact]
        public void Load()
        {
            foreach(FileInfo fileInfo in GetFiles())
            {
                try
                {
                    var file = File.ReadAllBytes(fileInfo.FullName);
                    var assembly = Assembly.Load(file);
                    var types = assembly.GetTypes();
                    Console.WriteLine("{0} has been loaded with {1} types", fileInfo.Name, types.Count());
                }
                catch(Exception exc)
                {
                    Assert.Fail(exc.Message);
                }
            }
            Assert.True(true);
        }
    }
}