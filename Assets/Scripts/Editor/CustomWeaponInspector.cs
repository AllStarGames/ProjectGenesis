using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Weapon))]
public class CustomWeaponInspector : Editor
{
    private Weapon mWeapon;

    public override void OnInspectorGUI()
    {
        SerializedObject serializedObject = new SerializedObject(target);
        
        SerializedProperty mainDamageProp = serializedObject.FindProperty("mMainDamage");
        GUIContent mainDamageLabel = new GUIContent();
        SerializedProperty secondaryDamageProp = serializedObject.FindProperty("mSecondaryDamage");
        GUIContent secondaryDamageLabel = new GUIContent();


        GUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel("Slot");
            mWeapon.SetEquipmentType((Equipment.Type)EditorGUILayout.EnumPopup(mWeapon.GetEquipmentType()));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel("Indestructible");
            mWeapon.SetIndestructibleFlag(EditorGUILayout.Toggle(mWeapon.GetIndestructibleFlag()));
        GUILayout.EndHorizontal();
        if(!mWeapon.GetIndestructibleFlag())
        {
            GUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel("Durability");
                mWeapon.SetDurability(EditorGUILayout.FloatField(mWeapon.GetDurability()));
            GUILayout.EndHorizontal();            
        }
        GUILayout.BeginHorizontal();
             EditorGUILayout.PrefixLabel("Level Requirement");
             mWeapon.SetLevelRequirement(EditorGUILayout.IntField(mWeapon.GetLevelRequirement()));
        GUILayout.EndHorizontal();

        GUILayout.Space(10.0f);

        GUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel("Hybrid");
            mWeapon.SetIsHybridFlag(EditorGUILayout.Toggle(mWeapon.IsHybrid()));
        GUILayout.EndHorizontal();
        if(mWeapon.IsHybrid())
        {
             GUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel("Primary Classification");
                mWeapon.SetMainClassification((Weapon.Classification)EditorGUILayout.EnumPopup(mWeapon.GetMainClassification()));
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel("Secondary Classification");
                mWeapon.SetSecondaryClassification((Weapon.Classification)EditorGUILayout.EnumPopup(mWeapon.GetSecondaryClassification()));
            GUILayout.EndHorizontal();

             GUILayout.Space(5.0f);

            GUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel("Primary Type");
                mWeapon.SetMainWeaponType((Weapon.Type)EditorGUILayout.EnumPopup(mWeapon.GetMainWeaponType()));
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel("Secondary Type");
                mWeapon.SetSecondaryWeaponType((Weapon.Type)EditorGUILayout.EnumPopup(mWeapon.GetSecondaryWeaponType()));
            GUILayout.EndHorizontal();

            GUILayout.Space(5.0f);

            GUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel("Primary Accuracy");
                mWeapon.SetMainAccuracy(EditorGUILayout.FloatField(mWeapon.GetMainAccuracy()));
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel("Secondary Accuracy");
                mWeapon.SetSecondaryAccuracy(EditorGUILayout.FloatField(mWeapon.GetSecondaryAccuracy()));
            GUILayout.EndHorizontal();

            GUILayout.Space(5.0f);

            GUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel("Primary Critical Chance");
                mWeapon.SetMainCriticalChance(EditorGUILayout.Slider(mWeapon.GetMainCriticalChance(), 0.1f, 100.0f));
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel("Secondary Critical Chance");
                mWeapon.SetSecondaryCriticalChance(EditorGUILayout.Slider(mWeapon.GetSecondaryCriticalChance(), 0.1f, 100.0f));
            GUILayout.EndHorizontal();

            GUILayout.Space(5.0f);

            GUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel("Primary Critical Multiplier");
                mWeapon.SetMainCriticalMultiplier(EditorGUILayout.FloatField(mWeapon.GetMainCriticalMultiplier()));
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel("Secondary Critical Multiplier");
                mWeapon.SetSecondaryCriticalMultiplier(EditorGUILayout.FloatField(mWeapon.GetSecondaryCriticalMultiplier()));
            GUILayout.EndHorizontal();

            GUILayout.Space(5.0f);

            GUILayout.BeginHorizontal();
                mainDamageLabel.text = "Primary Damage";
                 EditorGUILayout.PropertyField(mainDamageProp, mainDamageLabel, true);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
                secondaryDamageLabel.text = "Secondary Damage";
                 EditorGUILayout.PropertyField(secondaryDamageProp, secondaryDamageLabel, true);
            GUILayout.EndHorizontal();

            GUILayout.Space(5.0f);

            GUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel("Primary Range");
                mWeapon.SetMainRange(EditorGUILayout.Slider(mWeapon.GetMainRange(), 1.0f, 10.0f));
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel("Secondary Range");
                mWeapon.SetSecondaryRange(EditorGUILayout.Slider(mWeapon.GetSecondaryRange(), 1.0f, 10.0f));
            GUILayout.EndHorizontal();

            GUILayout.Space(5.0f);

            GUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel("Primary Speed");
                mWeapon.SetMainSpeed(EditorGUILayout.FloatField(mWeapon.GetMainSpeed()));
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel("Secondary Speed");
                mWeapon.SetSecondarySpeed(EditorGUILayout.FloatField(mWeapon.GetSecondarySpeed()));
            GUILayout.EndHorizontal();

            GUILayout.Space(5.0f);
        }
        else
        {
            GUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel("Classification");
                mWeapon.SetMainClassification((Weapon.Classification)EditorGUILayout.EnumPopup(mWeapon.GetMainClassification()));
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel("Type");
                mWeapon.SetMainWeaponType((Weapon.Type)EditorGUILayout.EnumPopup(mWeapon.GetMainWeaponType()));
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel("Accuracy");
                mWeapon.SetMainAccuracy(EditorGUILayout.FloatField(mWeapon.GetMainAccuracy()));
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel("Critical Chance");
                mWeapon.SetMainCriticalChance(EditorGUILayout.Slider(mWeapon.GetMainCriticalChance(), 0.1f, 100.0f));
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel("Critical Multiplier");
                mWeapon.SetMainCriticalMultiplier(EditorGUILayout.FloatField(mWeapon.GetMainCriticalMultiplier()));
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
                mainDamageLabel.text = "Damage";
                 EditorGUILayout.PropertyField(mainDamageProp, mainDamageLabel, true);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel("Range");
                mWeapon.SetMainRange(EditorGUILayout.Slider(mWeapon.GetMainRange(), 1.0f, 10.0f));
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel("Speed");
                mWeapon.SetMainSpeed(EditorGUILayout.FloatField(mWeapon.GetMainSpeed()));
            GUILayout.EndHorizontal();
        }
        GUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel("Number of Augment Slots");
            mWeapon.SetNumAugmentSlots(EditorGUILayout.IntField(mWeapon.GetNumAugmentSlots()));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel("Numer of Enchments");
            mWeapon.SetNumEnchantmentSlots(EditorGUILayout.IntField(mWeapon.GetNumEnchantmentSlots()));
        GUILayout.EndHorizontal();
    }

    void OnEnable()
    {
        mWeapon = (Weapon)target;
    }
}