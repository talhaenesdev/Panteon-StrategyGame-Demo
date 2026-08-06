using PanteonStrategyGame.Buildings.Data;
using UnityEditor;
using UnityEngine;

namespace PanteonStrategyGame.Editor
{
    [CustomEditor(typeof(BuildingData))]
    public class BuildingDataEditor : UnityEditor.Editor
    {
        private SerializedProperty _displayName;
        private SerializedProperty _icon;

        private SerializedProperty _poolKey;
        private SerializedProperty _ghostPoolKey;

        private SerializedProperty _maxHealth;

        private SerializedProperty _size;
        private SerializedProperty _buildingBuffer;

        private SerializedProperty _canProduceUnits;
        private SerializedProperty _producibleUnits;
        private SerializedProperty _spawnRadius;
        private SerializedProperty _spawnAngleStep;

        private void OnEnable()
        {
            _displayName = serializedObject.FindProperty("<DisplayName>k__BackingField");
            _icon = serializedObject.FindProperty("<Icon>k__BackingField");

            _poolKey = serializedObject.FindProperty("<PoolKey>k__BackingField");
            _ghostPoolKey = serializedObject.FindProperty("<GhostPoolKey>k__BackingField");

            _maxHealth = serializedObject.FindProperty("<MaxHealth>k__BackingField");

            _size = serializedObject.FindProperty("<Size>k__BackingField");
            _buildingBuffer = serializedObject.FindProperty("<BuildingBuffer>k__BackingField");

            _canProduceUnits = serializedObject.FindProperty("<CanProduceUnits>k__BackingField");

            _producibleUnits = serializedObject.FindProperty("producibleUnits");

            _spawnRadius = serializedObject.FindProperty("<SpawnRadius>k__BackingField");
            _spawnAngleStep = serializedObject.FindProperty("<SpawnAngleStep>k__BackingField");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            DrawGeneral();
            DrawPooling();
            DrawStats();
            DrawPlacement();
            DrawProduction();

            serializedObject.ApplyModifiedProperties();
        }

        private void DrawGeneral()
        {
            EditorGUILayout.LabelField(
                "General",
                EditorStyles.boldLabel);

            EditorGUILayout.PropertyField(_displayName);
            EditorGUILayout.PropertyField(_icon);

            EditorGUILayout.Space();
        }

        private void DrawPooling()
        {
            EditorGUILayout.LabelField(
                "Pooling",
                EditorStyles.boldLabel);

            EditorGUILayout.PropertyField(_poolKey);
            EditorGUILayout.PropertyField(_ghostPoolKey);

            EditorGUILayout.Space();
        }

        private void DrawStats()
        {
            EditorGUILayout.LabelField(
                "Stats",
                EditorStyles.boldLabel);

            EditorGUILayout.PropertyField(_maxHealth);

            EditorGUILayout.Space();
        }

        private void DrawPlacement()
        {
            EditorGUILayout.LabelField(
                "Placement",
                EditorStyles.boldLabel);

            EditorGUILayout.PropertyField(_size);
            EditorGUILayout.PropertyField(_buildingBuffer);

            EditorGUILayout.Space();
        }

        private void DrawProduction()
        {
            EditorGUILayout.LabelField(
                "Production",
                EditorStyles.boldLabel);

            EditorGUILayout.PropertyField(_canProduceUnits);

            if (_canProduceUnits.boolValue)
            {
                EditorGUI.indentLevel++;

                EditorGUILayout.PropertyField(
                    _producibleUnits,
                    true);

                EditorGUILayout.Slider(
                    _spawnRadius,
                    0.5f,
                    5f);

                EditorGUILayout.Slider(
                    _spawnAngleStep,
                    10f,
                    180f);

                EditorGUI.indentLevel--;
            }
        }
    }
}