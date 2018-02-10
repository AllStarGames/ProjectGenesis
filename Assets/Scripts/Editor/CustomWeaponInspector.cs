using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Weapon))]
public class CustomWeaponInspector : Editor
{
    private Weapon mWeapon;

    public override void OnInspectorGUI()
    {
        SerializedObject serializedObject = new SerializedObject(target);
    }

    void OnEnable()
    {
        mWeapon = (Weapon)target;
    }
}