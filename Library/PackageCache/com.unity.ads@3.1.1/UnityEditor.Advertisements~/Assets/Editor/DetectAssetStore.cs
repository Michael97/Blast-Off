using UnityEditor.Build;

namespace UnityEditor.Advertisements
{
    [InitializeOnLoad]
    internal class DetectAssetStore
    {
        static DetectAssetStore()
        {
            BuildDefines.getScriptCompilationDefinesDelegates += (target, defines) => {
                //Detect if the Asset Store Ads package is including in this project, and if it is, prevent the Packman Ads Package from building via asmdef
                var assetStoreAndroidDllPath = AssetImporter.GetAtPath(AssetDatabase.GUIDToAssetPath("cad99f482ce25421196533fe02e6a13e" /* UnityEngine.Advertising.Android.dll */)) as PluginImporter;
                var assetStoreIosDllPath = AssetImporter.GetAtPath(AssetDatabase.GUIDToAssetPath("d6f3e2ade30154a80a137e0079f66a08" /* UnityEngine.Advertising.iOS.dll */)) as PluginImporter;
                var assetStoreEditorDllPath = AssetImporter.GetAtPath(AssetDatabase.GUIDToAssetPath("56921141d53fd4a5888445107b1b1286" /* UnityEngine.Advertising.Editor.dll */)) as PluginImporter;
            
                if (assetStoreAndroidDllPath || assetStoreIosDllPath || assetStoreEditorDllPath) {
                    defines.Add("ADS_ASSET_STORE_PACKAGE_DETECTED");
                } else if (defines.Contains("ADS_ASSET_STORE_PACKAGE_DETECTED")) {
                    defines.Remove("ADS_ASSET_STORE_PACKAGE_DETECTED");
                }
                
                //Detect if the user has enabled ads via the Services Window
                if (AdvertisementSettings.enabledForPlatform) {
                    defines.Add("UNITY_ADS");
                }
            };
        }
    }
}
