using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemSo))]
public class ItemDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        ItemSo data = (ItemSo)target;

        // 아이템 이름
        EditorGUILayout.LabelField("아이템 이름", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("itemName"),
            new GUIContent("Item Name", "이름을 등록하세요"));

        // 아이템 설명
        EditorGUILayout.LabelField("아이템 설명", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("itemDescription"),
            new GUIContent("Item Description", "아이템의 설명"));

        // 아이템 등급
        EditorGUILayout.LabelField("아이템 등급", EditorStyles.boldLabel);
        SerializedProperty itemTierProp = serializedObject.FindProperty("itemTier");
        EditorGUILayout.PropertyField(itemTierProp);

        // TierStat (읽기 전용)
        EditorGUILayout.LabelField("자동 계산 스탯 (TierStat)", data.TierStat.ToString());

        // 먹는 템 여부
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("먹는 템 여부", EditorStyles.boldLabel);
        SerializedProperty canEdibleProp = serializedObject.FindProperty("canEdible");
        EditorGUILayout.PropertyField(canEdibleProp, new GUIContent("Can Edible", "체크 시 섭취 타입 설정 가능"));

        // 값 적용 후 다시 최신 상태로 업데이트
        serializedObject.ApplyModifiedProperties();
        serializedObject.Update();

        // 조건부 EdibleType 표시
        if (canEdibleProp.boolValue)
        {
            SerializedProperty edibleTypeProp = serializedObject.FindProperty("edibleType");
            EditorGUILayout.PropertyField(edibleTypeProp, new GUIContent("Edible Type"));
        }

        serializedObject.ApplyModifiedProperties();
    }
}
