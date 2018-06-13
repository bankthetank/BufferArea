using System.Reflection;
using System.Runtime.InteropServices;
using Tricentis.TCAddIns.BufferArea;
using Tricentis.TCCore.Persistency.AddInManager;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("BufferAreaAddIn")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Tricentis")]
[assembly: AssemblyProduct("Tricentis Tosca")]
[assembly: AssemblyCopyright("Copyright ©  2018")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(true)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("bf3583c7-8945-42d0-95c8-7f396e243208")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("11.2.0.9999")]
[assembly: AssemblyFileVersion("11.2.0.9999")]
[assembly: TCAddIn.TCAddInType(typeof(BufferAreaAddIn))]
