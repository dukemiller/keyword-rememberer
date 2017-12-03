# keyword-rememberer

A simple desktop application to display and alternate between user entered keywords, made for helping me study and remember terms.

![Demo](https://i.imgur.com/VdsZOa0.gif)

**\* [Find the download link for the latest version here.](https://github.com/dukemiller/keyword-rememberer/releases/latest)**  

---

### Build 
**Requirements:** [nuget.exe](https://dist.nuget.org/win-x86-commandline/latest/nuget.exe) on PATH, Visual Studio 2017 and/or C# 7.0 Roslyn Compiler  
**Optional:** Devenv (Visual Studio 2017) on PATH  

```
git clone https://github.com/dukemiller/keyword-rememberer.git
cd keyword-rememberer
nuget install keyword-rememberer\packages.config -OutputDirectory packages
```  

**Building with Devenv (CLI):** ``devenv keyword-rememberer.sln /Build``  
**Building with Visual Studio:**  Open (Ctrl+Shift+O) "keyword-rememberer.sln", Build Solution (Ctrl+Shift+B)

A "keyword-rememberer.exe" artifact will be created in the parent keyword-rememberer folder.
