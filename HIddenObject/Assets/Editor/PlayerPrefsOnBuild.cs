using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class PlayerPrefsOnBuild : EditorWindow
{
    [MenuItem("Tools/Delete Player Prefs")]
    public static void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Player Prefs were removed");
    }
}
