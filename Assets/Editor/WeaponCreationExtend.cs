using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WeaponCreationExtend : EditorWindow {
    [MenuItem("Window/Weapon Creator")]

    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(WeaponCreationExtend));
    }

    private void OnGUI()
    {
        
    }
}
