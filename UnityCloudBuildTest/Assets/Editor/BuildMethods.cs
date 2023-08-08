using System.Collections;
using System.Collections.Generic;
using AltTester.AltTesterUnitySDK;
using AltTester.AltTesterUnitySDK.Editor;
using UnityEditor;
using UnityEngine;

public class BuildMethods
{
    public static void PreMethod()
    {
        var buildTargetGroup = BuildTargetGroup.Standalone;
        AltBuilder.AddAltTesterInScriptingDefineSymbolsGroup(buildTargetGroup);
        if (buildTargetGroup == UnityEditor.BuildTargetGroup.Standalone)
        {
            AltBuilder.CreateJsonFileForInputMappingOfAxis();
        }
        var instrumentationSettings = new AltInstrumentationSettings();
        AltBuilder.InsertAltInScene("Assets/Scenes/SampleScene.unity", instrumentationSettings);
        var buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new string[1] { "Assets/Scenes/SampleScene.unity" };
        buildPlayerOptions.options = UnityEditor.BuildOptions.Development | UnityEditor.BuildOptions.IncludeTestAssemblies;
        buildPlayerOptions.target = BuildTarget.StandaloneWindows64;
        buildPlayerOptions.targetGroup = BuildTargetGroup.Standalone;
        UnityEditor.BuildPipeline.BuildPlayer(buildPlayerOptions);
    }
}
