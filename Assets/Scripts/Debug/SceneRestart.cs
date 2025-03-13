using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace Editor
{
    public class SceneRestart : MonoBehaviour
    {
        [MenuItem("RestartScene/Restart Scene #R")]
        private static void RestartScene()
        {
            var currentScene = EditorSceneManager.GetActiveScene();
            EditorSceneManager.LoadScene(currentScene.name);
        }
    }
}

