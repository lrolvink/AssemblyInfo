using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace LRolvink.AssemblyInfo
{
    public class AssemblyAnalyzer
    {
        public TreeNode<string, object> Exam(string filename)
        {
            FileInfo file = new FileInfo(filename);

            System.Reflection.Assembly assemblyReflectionOnlyLoad = System.Reflection.Assembly.ReflectionOnlyLoadFrom(file.FullName);
            System.Reflection.Assembly assemblyLoad = System.Reflection.Assembly.LoadFrom(file.FullName);
            System.Reflection.Assembly assemblyUnsafeLoad = System.Reflection.Assembly.UnsafeLoadFrom(file.FullName);

            //

            TreeNode<string, object> root = new TreeNode<string, object>("Assembly", assemblyReflectionOnlyLoad.Location);

            root.AddChild("Code Base", assemblyReflectionOnlyLoad.CodeBase);
            root.AddChild("Full Name", assemblyReflectionOnlyLoad.FullName);
            root.AddChild("Image Runtime Version (CLR)", assemblyReflectionOnlyLoad.ImageRuntimeVersion);
            root.AddChild("Entry Point", assemblyReflectionOnlyLoad.EntryPoint);
            root.AddChild("Global Assembly Cache", assemblyReflectionOnlyLoad.GlobalAssemblyCache);
            root.AddChild("Is Dynamic", assemblyReflectionOnlyLoad.IsDynamic);
            root.AddChild("Is Fully Trusted", assemblyReflectionOnlyLoad.IsFullyTrusted);
            root.AddChild("Security RuleSet", assemblyReflectionOnlyLoad.SecurityRuleSet);

            var assemblyReflectionOnlyLoadCustomAttrData = assemblyReflectionOnlyLoad.GetCustomAttributesData();
            var assemblyLoadCustomAttrData = assemblyLoad.GetCustomAttributesData();
            var assemblyUnsafeLoadCustomAttrData = assemblyUnsafeLoad.GetCustomAttributesData();

            //var assemblyReflectionOnlyLoadCustomAttr = assemblyReflectionOnlyLoad.GetCustomAttributes(false); // throws exception.
            var assemblyLoadCustomAttr = assemblyLoad.GetCustomAttributes(false);
            var assemblyUnsafeLoadCustomAttr = assemblyUnsafeLoad.GetCustomAttributes(false);

            //

            TreeNode<string, object> customAttributesNode = root.AddChild("Custom Attributes", "Has " + assemblyReflectionOnlyLoadCustomAttrData.Count());

            TreeNode<string, object> caAlgorithmId = customAttributesNode.AddChild("Algorithm Id", null);
            TreeNode<string, object> caCompany = customAttributesNode.AddChild("Company", null);
            TreeNode<string, object> caConfiguration = customAttributesNode.AddChild("Configuration", null);
            TreeNode<string, object> caCopyrigtht = customAttributesNode.AddChild("Copyrigtht", null);
            TreeNode<string, object> caCulture = customAttributesNode.AddChild("Culture", null);
            TreeNode<string, object> caDefaultAlias = customAttributesNode.AddChild("Default Alias", null);
            TreeNode<string, object> caDelaySign = customAttributesNode.AddChild("Delay Sign", null);
            TreeNode<string, object> caDescription = customAttributesNode.AddChild("Description", null);
            TreeNode<string, object> caFileVersion = customAttributesNode.AddChild("File Version", null);
            TreeNode<string, object> caAssemblyFlags = customAttributesNode.AddChild("Assembly Flags", null);
            TreeNode<string, object> caInformationalVersion = customAttributesNode.AddChild("Informational Version", null);
            TreeNode<string, object> caKeyFile = customAttributesNode.AddChild("Key File", null);
            TreeNode<string, object> caKeyName = customAttributesNode.AddChild("Key Name", null);
            TreeNode<string, object> caMetadata = customAttributesNode.AddChild("Metadata", null);
            TreeNode<string, object> caProduct = customAttributesNode.AddChild("Product", null);
            TreeNode<string, object> caPublicKey = customAttributesNode.AddChild("PublicKey", null);
            TreeNode<string, object> caTitle = customAttributesNode.AddChild("Title", null);
            TreeNode<string, object> caTrademark = customAttributesNode.AddChild("Trademark", null);
            TreeNode<string, object> caVersion = customAttributesNode.AddChild("Version", null);
            TreeNode<string, object> caDebuggingFlags = customAttributesNode.AddChild("Debugging Flags", null);
            TreeNode<string, object> caIsJITTrackingEnabled = customAttributesNode.AddChild("Is JIT Tracking Enabled", null);
            TreeNode<string, object> caIsJITOptimizerDisabled = customAttributesNode.AddChild("Is JIT Optimizer Disabled", null);

            List<dynamic> attrList = new List<dynamic>();
            //attrList.AddRange(assemblyReflectionOnlyLoadCustomAttrData);
            attrList.AddRange(assemblyLoadCustomAttr);

            foreach (object att in attrList)
            {
                var type = att.GetType();

                // Known attributes.

                if (att is System.Reflection.AssemblyAlgorithmIdAttribute)
                {
                    caAlgorithmId.Value = ((System.Reflection.AssemblyAlgorithmIdAttribute)att).AlgorithmId;
                }
                if (att is System.Reflection.AssemblyCompanyAttribute)
                {
                    caCompany.Value = ((System.Reflection.AssemblyCompanyAttribute)att).Company;
                }
                if (att is System.Reflection.AssemblyConfigurationAttribute)
                {
                    caConfiguration.Value = ((System.Reflection.AssemblyConfigurationAttribute)att).Configuration;
                }
                if (att is System.Reflection.AssemblyCopyrightAttribute)
                {
                    caCopyrigtht.Value = ((System.Reflection.AssemblyCopyrightAttribute)att).Copyright;
                }
                if (att is System.Reflection.AssemblyCultureAttribute)
                {
                    caCulture.Value = ((System.Reflection.AssemblyCultureAttribute)att).Culture;
                }
                if (att is System.Reflection.AssemblyDefaultAliasAttribute)
                {
                    caDefaultAlias.Value = ((System.Reflection.AssemblyDefaultAliasAttribute)att).DefaultAlias;
                }
                if (att is System.Reflection.AssemblyDelaySignAttribute)
                {
                    caDelaySign.Value = ((System.Reflection.AssemblyDelaySignAttribute)att).DelaySign;
                }
                if (att is System.Reflection.AssemblyDescriptionAttribute)
                {
                    caDescription.Value = ((System.Reflection.AssemblyDescriptionAttribute)att).Description;
                }
                if (att is System.Reflection.AssemblyFileVersionAttribute)
                {
                    caFileVersion.Value = ((System.Reflection.AssemblyFileVersionAttribute)att).Version;
                }
                if (att is System.Reflection.AssemblyFlagsAttribute)
                {
                    caAssemblyFlags.Value = ((System.Reflection.AssemblyFlagsAttribute)att).AssemblyFlags;
                }
                if (att is System.Reflection.AssemblyInformationalVersionAttribute)
                {
                    caInformationalVersion.Value = ((System.Reflection.AssemblyInformationalVersionAttribute)att).InformationalVersion;
                }
                if (att is System.Reflection.AssemblyKeyFileAttribute)
                {
                    caKeyFile.Value = ((System.Reflection.AssemblyKeyFileAttribute)att).KeyFile;
                }
                if (att is System.Reflection.AssemblyKeyNameAttribute)
                {
                    caKeyName.Value = ((System.Reflection.AssemblyKeyNameAttribute)att).KeyName;
                }
                if (att is System.Reflection.AssemblyMetadataAttribute)
                {
                    caMetadata.Value = ((System.Reflection.AssemblyMetadataAttribute)att).Key + "" + ((System.Reflection.AssemblyMetadataAttribute)att).Value;
                }
                if (att is System.Reflection.AssemblyProductAttribute)
                {
                    caProduct.Value = ((System.Reflection.AssemblyProductAttribute)att).Product;
                }
                if (att is System.Reflection.AssemblySignatureKeyAttribute)
                {
                    caPublicKey.Value = ((System.Reflection.AssemblySignatureKeyAttribute)att).PublicKey;
                }
                if (att is System.Reflection.AssemblyTitleAttribute)
                {
                    caTitle.Value = ((System.Reflection.AssemblyTitleAttribute)att).Title;
                }
                if (att is System.Reflection.AssemblyTrademarkAttribute)
                {
                    caTrademark.Value = ((System.Reflection.AssemblyTrademarkAttribute)att).Trademark;
                }
                if (att is System.Reflection.AssemblyVersionAttribute)
                {
                    caVersion.Value = ((System.Reflection.AssemblyVersionAttribute)att).Version;
                }
                if (att is System.Diagnostics.DebuggableAttribute)
                {
                    caDebuggingFlags.Value = ((System.Diagnostics.DebuggableAttribute)att).DebuggingFlags.ToString();
                    caIsJITTrackingEnabled.Value = ((System.Diagnostics.DebuggableAttribute)att).IsJITTrackingEnabled;
                    caIsJITOptimizerDisabled.Value = ((System.Diagnostics.DebuggableAttribute)att).IsJITOptimizerDisabled;
                }

                //

#if EXPERIMENTAL

                if (att is System.Reflection.CustomAttributeData)
                {
                    var x = (System.Reflection.CustomAttributeData)att;
                    //var y = (System.Reflection.AssemblyCompanyAttribute)att
                    var namedArguments = x.NamedArguments;

                    if (x.ConstructorArguments.Any())
                    {
                        var value = x.ConstructorArguments[0].Value;
                    }

                    if (x.AttributeType == typeof(System.Runtime.CompilerServices.ExtensionAttribute))
                    {

                    }
                    if (x.AttributeType == typeof(System.Runtime.CompilerServices.CompilationRelaxationsAttribute))
                    {
                        if (x.ConstructorArguments.Count >= 1)
                        {
                            var argument = x.ConstructorArguments[0];

                            var CompilationRelaxationsValue = argument.Value.ToString();
                        }
                    }
                }

#endif
            }

            //  Determine in which build configuration is used.
            TreeNode<string, object> caUsedBuildConfig = root.AddChild("Build configuration", "It seems that it is a release build.");

            bool? isJITTrackingEnabled = (bool?)caIsJITTrackingEnabled.Value;

            if (isJITTrackingEnabled.Value)
            {
                caUsedBuildConfig.Value = "It seems that it is a debug build.";
            }

            return root;
        }
    }
}
