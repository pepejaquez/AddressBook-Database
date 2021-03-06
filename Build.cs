using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;

namespace Build
{

    enum DotNetTargets
    {
        FortyFive = 45,
    }

    class Dependency
    {
        public string Id { set; get; }
        public string Version { set; get; }

        public string NuPkgURI() => $"https://api.nuget.org/v3-flatcontainer/{this.Id.ToLowerInvariant()}/{this.Version.ToLowerInvariant()}/{this.Id.ToLowerInvariant()}.{this.Version.ToLowerInvariant()}.nupkg";
        public string LocalNuPkgURI() => $"nuget-packages/{this.Id.ToLowerInvariant()}.{this.Version.ToLowerInvariant()}.nupkg";
        public string LocalNuPkgDir() => $"nuget-packages/{this.Id.ToLowerInvariant()}.{this.Version.ToLowerInvariant()}";

        public string LocalNuPkgDLLDir(DotNetTargets target)
        {
            var netTarget = (int)target;
            return $"nuget-packages/{this.Id.ToLowerInvariant()}.{this.Version.ToLowerInvariant()}/lib/net{netTarget}/";
        }

        public override String ToString()
        {
              return $"{this.Id}@{this.Version}";
        }
    }

    static class Build
    {
        public static readonly DotNetTargets DefaultTarget = DotNetTargets.FortyFive;
        static readonly HttpClient client = new HttpClient();

        static readonly string SystemDLLLocationTemplate = "C:\\Windows\\Microsoft.NET\\Framework64\\v4.0.30319";
        static readonly string DefaultExecutable = "AddressBook.exe";

        static void Main()
        {
            // See: https://stackoverflow.com/questions/22251689/make-https-call-using-httpclient
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            Directory.CreateDirectory("nuget-packages");

            var Dependencies = new List<Dependency>();
            Dependencies.Add(new Dependency { Id = "Community.CsharpSqlite.SQLiteClient", Version = "3.7.7.3" });

            foreach (Dependency dependency in Dependencies)
            {
                Console.WriteLine($"Downloading Dependency {dependency}");
                var task = Build.DownloadPackage(dependency);
                task.Wait();
                Directory.CreateDirectory(dependency.LocalNuPkgDir());
                Build.Unpkg(dependency);
            }

            Directory.CreateDirectory("bin");
            Build.CompileProject(Dependencies);
            Build.PrepareDLLsForProject(Dependencies);
        }

        static async Task DownloadPackage(Dependency dependency)
        {
            try
            {
                Console.WriteLine($"Contacting nuget registry at {dependency.NuPkgURI()}...");
                Stream responseBody = await client.GetStreamAsync(dependency.NuPkgURI());
                Console.WriteLine(responseBody);

                using (FileStream DestinationStream = File.Create(dependency.LocalNuPkgURI()))
                {
                    await responseBody.CopyToAsync(DestinationStream);
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Message: {e}");
            }
        }

        static void Unpkg(Dependency dependency)
        {
            try
            {
                using (Process myProcess = new Process())
                {
                    myProcess.StartInfo.UseShellExecute = false;
                    myProcess.StartInfo.FileName = $"tar";
                    myProcess.StartInfo.Arguments = $"-xf {dependency.LocalNuPkgURI()} --directory={dependency.LocalNuPkgDir()}";
                    myProcess.StartInfo.CreateNoWindow = true;
                    myProcess.Start();
                    myProcess.WaitForExit();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void CompileProject(List<Dependency> Dependencies)
        {
            try
            {
                using (Process myProcess = new Process())
                {
                    myProcess.StartInfo.UseShellExecute = false;
                    myProcess.StartInfo.FileName = $"csc";
                    var dllDirectoryList = new List<string>();
                    foreach (Dependency dependency in Dependencies)
                    {
                        string[] fileEntries = Directory.GetFiles(dependency.LocalNuPkgDLLDir(Build.DefaultTarget));
                        foreach (string fileName in fileEntries)
                        {
                            dllDirectoryList.Add(fileName);
                        }
                    }
                    myProcess.StartInfo.Arguments = $"-r:{String.Join(",", dllDirectoryList.ToArray())} -out:bin/{Build.DefaultExecutable} -lib:{Build.SystemDLLLocationTemplate} src/*.cs";
                    myProcess.StartInfo.CreateNoWindow = true;
                    myProcess.StartInfo.RedirectStandardOutput = true;
                    myProcess.Start();
                    Console.WriteLine(myProcess.StandardOutput.ReadToEnd());
                    myProcess.WaitForExit();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void PrepareDLLsForProject(List<Dependency> Dependencies)
        {
            foreach (Dependency dependency in Dependencies)
            {
                string[] fileEntries = Directory.GetFiles(dependency.LocalNuPkgDLLDir(Build.DefaultTarget));
                foreach (string fileName in fileEntries)
                {
                    File.Copy(fileName, $"bin/{Path.GetFileName(fileName)}", true);
                }
            }
        }
    }



}