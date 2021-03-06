set SYSTEM_LIB="C:\Windows\Microsoft.NET\Framework64\v4.0.30319"
csc -out:Build.exe -lib:%SYSTEM_LIB% -reference:System.Net.Http.dll Build.cs
Build.exe