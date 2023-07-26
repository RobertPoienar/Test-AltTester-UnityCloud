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
    }
}
