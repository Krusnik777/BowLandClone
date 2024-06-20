using UnityEditor;
using UnityEditor.SceneManagement;
using CodeBase.Services;
using CodeBase.Gameplay;
using CodeBase.Gameplay.Hero;
using UnityEngine;
using UnityEngine.SceneManagement;
using CodeBase.Gameplay.Enemy;
using CodeBase.Configs;
using CodeBase.Gameplay.Pickup;

namespace CodeBase.Editor
{
    public class LevelConfigEditorSaver
    {
        [InitializeOnLoadMethod]
        public static void InitEditor()
        {
            EditorSceneManager.sceneSaved += OnSceneSaved;
        }

        private static void OnSceneSaved(Scene scene)
        {
            IConfigsProvider configsProvider = new ConfigsProvider();
            configsProvider.Load();

            LevelConfig levelConfig = configsProvider.GetLevel(scene.name);

            if (levelConfig == null) return;

            SerializedObject serializedObject = new SerializedObject(levelConfig);

            serializedObject.FindProperty("HeroSpawnPosition").vector3Value = GameObject.FindObjectOfType<HeroSpawnPoint>().transform.position;
            serializedObject.FindProperty("FinishPoint").vector3Value = GameObject.FindObjectOfType<FinishPoint>().transform.position;

            var enemySpawnerDatas = serializedObject.FindProperty("EnemySpawnerDatas");

            if (enemySpawnerDatas != null)
            {
                enemySpawnerDatas.ClearArray();

                EnemySpawner[] enemySpawners = GameObject.FindObjectsOfType<EnemySpawner>();

                for (int i = 0; i < enemySpawners.Length; i++)
                {
                    enemySpawnerDatas.InsertArrayElementAtIndex(i);
                    var spawner = enemySpawnerDatas.GetArrayElementAtIndex(i);
                    spawner.FindPropertyRelative("Id").intValue = (int) enemySpawners[i].EnemyId;
                    spawner.FindPropertyRelative("Position").vector3Value = enemySpawners[i].transform.position;
                }
            }

            var coinPositions = serializedObject.FindProperty("CoinPositions");

            if (coinPositions != null)
            {
                coinPositions.ClearArray();

                CoinSpawner[] coinSpawners = GameObject.FindObjectsOfType<CoinSpawner>();

                for (int i = 0; i < coinSpawners.Length; i++)
                {
                    coinPositions.InsertArrayElementAtIndex(i);
                    coinPositions.GetArrayElementAtIndex(i).vector3Value = coinSpawners[i].transform.position;
                }
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
