
To compile and run the project you must have the following:

1) Install the .net framework (https://dotnet.microsoft.com/download). Grab the recommended download.
   You MUST download the cross-platform version if you are not using windows.

2) You will need to download the Community.CsharpSqlite.SQLiteClient NuGet package (https://www.nuget.org/packages/Community.CsharpSqlite.SQLiteClient)
   ***How to extract the dll's?***

3) Create a repository and pull the source files from GitHub.
(clone the repository)


To Compile Project:

1) You can either add the path for the c# compiler to the system environment variables or reference the path directly.
   In windows you should be able to find the csc.exe in C:\Windows\Microsoft.NET\Framework64\v4.0.30319(<---the latest version of course).
   If not, no matter what os you use just search for csc.exe

2) Open the command prompt/terminal and navigate to the folder the project is in.

   If you did not add the path to the environment then the reference to the csc.exe will look similar to this:
   C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc or whatever the path is to the compiler.

   If you did add the path to the environment then you will reference the compiler directly like this:
   csc.exe

3)  The first thing to do is reference the SQLite dll's like this:
    /reference:Community.CsharpSqlite.dll,Community.CsharpSqlite.SQLiteClient.dll (no spaces bewteen references)

    If the dll's are not in the same folder as the project then you have to tell the compile where to look for them like this:
    e.g. /lib:c:\Users\pepe\Desktop\TestProject\ThirdPartyLibs

    If the dll's are in the same folder then(withstanding the above)the rest of the arguments are as follows:

    a) /target:winexe - telling the compiler we are building a Windows executable
    b) /out:(insert the name you want your compiled project to have), DO NOT include the parentheses.
    c) Program.cs - IMPORTANT  This is the main entry point for the program, this file has to be listed first.
       The rest of the .cs files are listed in no particular order. Just make sure you list them with a space between them.

       The finished command will look similar to this:

       without the environment variable and dll's outside the project folder:
       C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc /reference:Community.CsharpSqlite.dll,Community.CsharpSqlite.SQLiteClient.dll /lib:c:\Users\pepe\Desktop\TestProject\ThirdPartyLibs /target:exe /out:MyFirstCompile.exe Program.cs Form1.cs Form1.Designer.cs AddressEntry.cs
       
       with the environment variable and dll's in the project folder:
       csc /reference:Community.CsharpSqlite.SQLiteClient.dll,Community.CsharpSqlite.dll /target:exe /out:MyFirstCompile.exe Program.cs Form1.cs Form1.Designer.cs AddressEntry.cs       

4)  Hit enter to compile the program. There should now be a new .exe file in the project folder with the name you chose in step 3b.

One last quirky thing. Although when compiling the program you can reference the dll's in any folder outside of the project,
the dll's actually have to be copied into the folder containing the .exe file you created in order for it to run.
 



