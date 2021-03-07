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
        Forty = 40
    }

    class Dependency
    {
        public string Id { set; get; }
        public string Version { set; get; }
        public DotNetTargets Target { set; get; }

        public string CommonName() => $"{this.Id.ToLowerInvariant()}.{this.Version.ToLowerInvariant()}";
        public string NuPkgFileName() => $"{this.CommonName()}.nupkg";
        public string RemoteNuPkgURI() => $"https://api.nuget.org/v3-flatcontainer/{this.Id.ToLowerInvariant()}/{this.Version.ToLowerInvariant()}/{this.NuPkgFileName()}";
        public string LocalNuPkgURI() => $"{Build.LocalSharedNuPkgDir}/{this.NuPkgFileName()}";
        public string LocalNuPkgDir() =>  $"{Build.LocalSharedNuPkgDir}/{this.CommonName()}";
        public string LocalNuPkgDLLDir()
        {
            var target = (int)this.Target;
            return $"{this.LocalNuPkgDir()}/lib/net{target}/";
        }

        public override String ToString()
        {
            return $"{this.Id}@{this.Version}";
        }
    }

    static class Build
    {
        public static readonly string LocalSharedNuPkgDir = "nuget-packages";
        public static readonly string LocalBinDir = "bin";
        static readonly HttpClient client = new HttpClient();

        static readonly string SystemDLLsLocation = "C:\\Windows\\Microsoft.NET\\Framework64\\v4.0.30319";
        static readonly string DefaultExecutable = "AddressBook.exe";

        static void Main()
        {
            var Dependencies = new List<Dependency>();
            Dependencies.Add(new Dependency { Id = "Community.CsharpSqlite.SQLiteClient", Version = "3.7.7.3", Target = DotNetTargets.FortyFive });
            Dependencies.Add(new Dependency { Id = "Alba.CsConsoleFormat", Version = "1.0.0", Target = DotNetTargets.Forty });

            // See: https://stackoverflow.com/questions/22251689/make-https-call-using-httpclient
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                
            Console.WriteLine($"Creating Directory {Build.LocalSharedNuPkgDir} to Store Dependencies {string.Join(", ", Dependencies)}");
            Directory.CreateDirectory(Build.LocalSharedNuPkgDir);

            foreach (Dependency dependency in Dependencies)
            {
                var task = Build.DownloadPackage(dependency);
                task.Wait();
                Console.WriteLine($"Creating Directory {dependency.LocalNuPkgDir()} to Unpackage Dependency {dependency}");
                Directory.CreateDirectory(dependency.LocalNuPkgDir());
                Build.Unpkg(dependency);
            }

            Console.WriteLine($"Creating Directory {Build.LocalBinDir} to Store DLLs and Project Binaries");
            Directory.CreateDirectory(Build.LocalBinDir);
            Build.CompileProject(Dependencies);
            Build.PrepareDLLsForProject(Dependencies);
        }

        static async Task DownloadPackage(Dependency dependency)
        {
            Console.WriteLine($"Downloading Dependency {dependency}");
            try
            {
                Console.WriteLine($"Contacting nuget registry at {dependency.RemoteNuPkgURI()}...");
                Stream responseBody = await client.GetStreamAsync(dependency.RemoteNuPkgURI());

                using (FileStream DestinationStream = File.Create(dependency.LocalNuPkgURI()))
                {
                    await responseBody.CopyToAsync(DestinationStream);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Dowloading Package {dependency} Failed: {e}");
            }
        }

        static void Unpkg(Dependency dependency)
        {
            Console.WriteLine($"Unpackaging Dependency {dependency} into {dependency.CommonName()}");
            try
            {
                Build.ExecuteProcess("tar", $"-xf {dependency.LocalNuPkgURI()} --directory={dependency.LocalNuPkgDir()}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unpackaging Package {dependency} Failed: {e}");
            }
        }
        
        static void CompileProject(List<Dependency> Dependencies)
        {
            Console.WriteLine($"Compiling Project with Dependencies {string.Join(", ", Dependencies)}");
            try
            {
                var dllDirectoryList = new List<string>();
                foreach (Dependency dependency in Dependencies)
                {
                    string[] fileEntries = Directory.GetFiles(dependency.LocalNuPkgDLLDir());
                    foreach (string fileName in fileEntries)
                    {
                        dllDirectoryList.Add(fileName);
                    }
                }
                
                Build.ExecuteProcess("csc", $"-r:{String.Join(",", dllDirectoryList.ToArray())} -out:bin/{Build.DefaultExecutable} -lib:{Build.SystemDLLsLocation} src/*.cs");
            }
            catch (Exception error)
            {
                Console.WriteLine($"Compiling Project with Dependencies {string.Join(", ", Dependencies)} Failed: {error}");
            }
        }

        static void PrepareDLLsForProject(List<Dependency> Dependencies)
        {
            Console.WriteLine($"Preparing DLLs for Project Execution for Dependencies {string.Join(", ", Dependencies)}");
            foreach (Dependency dependency in Dependencies)
            {
                string[] fileEntries = Directory.GetFiles(dependency.LocalNuPkgDLLDir());
                foreach (string fileName in fileEntries)
                {
                    File.Copy(fileName, $"{Build.LocalBinDir}/{Path.GetFileName(fileName)}", true);
                }
            }
        }

        static void ExecuteProcess(string executable, string arguments) {
            using (Process myProcess = new Process())
            {
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = executable;
                myProcess.StartInfo.Arguments = arguments;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.RedirectStandardOutput = true;
                myProcess.StartInfo.RedirectStandardError = true;

                myProcess.Start();
                var output = myProcess.StandardOutput.ReadToEnd();
                var error = myProcess.StandardError.ReadToEnd();
                Console.WriteLine(output);
                myProcess.WaitForExit();

                if (myProcess.ExitCode != 0) {
                    throw new Exception(error);
                }
            }
        }
    }
}