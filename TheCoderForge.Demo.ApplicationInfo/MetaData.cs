// /*
// * PROJECT:    TheCoderForge.Demo.ApplicationInfo
// * NAME:        ApplicationInfo.cs
// */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;

namespace TheCoderForge.Demo.ApplicationInfo
{
    /// <summary>
    ///     Class which gathers application meta data from the various locations in the app
    /// </summary>
    public class MetaData
    {
        #region Private Member Variables

        private readonly Assembly executingAssembly = Assembly.GetExecutingAssembly();

        #endregion
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MetaData" /> class.
        /// </summary>
        public MetaData()
        {
            FullName = executingAssembly.FullName;
            ImageRuntimeVersion = executingAssembly.ImageRuntimeVersion;
            Location = executingAssembly.Location;
            AssemblyName assemblyName = executingAssembly.GetName();
            AssemblyNameFullName = assemblyName.FullName;
            AssemblyNameName = assemblyName.Name;
            AssemblyNameVersion = assemblyName.Version.ToString();

            //// how to retrieve a specific custom attribute:
            //object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
            //AssemblyTitleAttribute assemblyTitleAttribute = (AssemblyTitleAttribute) attributes[0];
            //string assemblyTitle = assemblyTitleAttribute.Title;

            // or just get them all....
            IEnumerable<Attribute> attributesAll = Assembly.GetExecutingAssembly().GetCustomAttributes();
            foreach (Attribute attribute in attributesAll)
            {
                string typeName = attribute.ToString();

                switch (typeName)
                {
                    case"System.Diagnostics.DebuggableAttribute":
                    case"System.Reflection.AssemblyConfigurationAttribute":
                    case"System.Reflection.AssemblyInformationalVersionAttribute":
                    case"System.Runtime.CompilerServices.CompilationRelaxationsAttribute":
                    case"System.Runtime.CompilerServices.RuntimeCompatibilityAttribute":
                    case"System.Runtime.Versioning.SupportedOSPlatformAttribute":
                    case"System.Runtime.Versioning.TargetFrameworkAttribute":
                    case"System.Runtime.Versioning.TargetPlatformAttribute":
                        //  the attribute is not very useful for this data
                        // ignore it
                        break;

                    case"System.Reflection.AssemblyCompanyAttribute":
                        AssemblyCompanyAttribute = ((AssemblyCompanyAttribute) attribute).Company;
                        break;

                    case"System.Reflection.AssemblyDescriptionAttribute":
                        AssemblyDescriptionAttribute = ((AssemblyDescriptionAttribute) attribute).Description;
                        break;

                    case"System.Reflection.AssemblyFileVersionAttribute":
                        AssemblyFileVersionAttribute = ((AssemblyFileVersionAttribute) attribute).Version;
                        break;

                    case"System.Reflection.AssemblyProductAttribute":
                        AssemblyProductAttribute = ((AssemblyProductAttribute) attribute).Product;
                        break;

                    case"System.Reflection.AssemblyTitleAttribute":
                        AssemblyTitleAttribute = ((AssemblyTitleAttribute) attribute).Title;
                        break;

                    default:
                        Debugger.Break();

                        break;
                }
            }
        }

        #endregion

        /// <summary>
        ///     Gets the ExecutingAssembly.FullName value
        /// </summary>
        /// <value>
        ///     The full name.
        /// </value>
        [Browsable(true)] // this property should be visible
        [ReadOnly(true)] // but just read only
        [Description("The FullName property of the Executing assembly")] // sample hint1
        [Category("ExecutingAssembly")]
        public string FullName { get; }

        [Browsable(true)] // this property should be visible
        [ReadOnly(true)] // but just read only
        [Description("The ImageRuntimeVersion property of the Executing assembly")] // sample hint1
        [Category("ExecutingAssembly")]
        public string ImageRuntimeVersion { get; }

        [Browsable(true)] // this property should be visible
        [ReadOnly(true)] // but just read only
        [Description("The Location property of the Executing assembly")] // sample hint1
        [Category("ExecutingAssembly")]
        public string Location { get; }

        [Browsable(true)] // this property should be visible
        [ReadOnly(true)] // but just read only
        [Description("The GetName().FullName property of the Executing assembly")] // sample hint1
        [Category("ExecutingAssembly")]
        [DisplayName("GetName().FullName")]
        public string AssemblyNameFullName { get; }

        // Matches the 'Product Name' field on file properies dialog.
        // above field is taken from .csproj 'Product' field.

        /// <summary>
        ///     Gets the name of the assembly name.
        /// </summary>
        /// <value>
        ///     The name of the assembly name.
        /// </value>
        [Browsable(true)] // this property should be visible
        [ReadOnly(true)] // but just read only
        [Description("The GetName().Name property of the Executing assembly.")]
        [Category("ExecutingAssembly")]
        [DisplayName("GetName().Name")]
        public string AssemblyNameName { get; }

        [Browsable(true)] // this property should be visible
        [ReadOnly(true)] // but just read only
        [Description("The GetName().Version property of the Executing assembly")]
        [Category("ExecutingAssembly")]
        [DisplayName("GetName().Version")]
        public string AssemblyNameVersion { get; }

        [Browsable(true)] // this property should be visible
        [ReadOnly(true)] // but just read only
        [Description("Custom Attribute from the assembly.\nNot shown as on file properties dialog.\nCan be edited in the .csproj file -> <Company> element, or project properties -> package -> Company field")]
        [Category("ExecutingAssembly")]
        [DisplayName("AssemblyCompanyAttribute")]
        public string AssemblyCompanyAttribute { get; }

        [Browsable(true)] // this property should be visible
        [ReadOnly(true)] // but just read only
        [Description("Custom Attribute from the assembly.\nNot shown on file properties dialog.\nCan be edited in the .csproj file -> <Description> element, or project properties -> package -> Company field")]
        [Category("ExecutingAssembly")]
        [DisplayName("AssemblyDescriptionAttribute")]
        public string AssemblyDescriptionAttribute { get; }

        [Browsable(true)] // this property should be visible
        [ReadOnly(true)] // but just read only
        [Description("Custom Attribute from the assembly.\nShown as 'Version' on file properties dialog.\nCan be edited in the .csproj file -> <Version> element, or project properties -> package -> Version")]
        [Category("ExecutingAssembly")]
        [DisplayName("AssemblyFileVersionAttribute")]
        public string AssemblyFileVersionAttribute { get; }

        [Browsable(true)] // this property should be visible
        [ReadOnly(true)] // but just read only
        [Description("Custom Attribute from the assembly.\nShown as 'Product Name' on file properties dialog.\nCan be edited in the .csproj file -> <Product> element, or project properties -> package -> Product field")]
        [Category("ExecutingAssembly")]
        [DisplayName("AssemblyProductAttribute")]
        public string AssemblyProductAttribute { get; }

        [Browsable(true)] // this property should be visible
        [ReadOnly(true)] // but just read only
        [Description("Custom Attribute from the assembly.\nNot shown on file properties dialog.\nCan be edited in project properties -> Application -> 'Assembly Name', but will effect other fields.")]
        [Category("ExecutingAssembly")]
        [DisplayName("AssemblyTitleAttribute")]
        public string AssemblyTitleAttribute { get; }
    }
}