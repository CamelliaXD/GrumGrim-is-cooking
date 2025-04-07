using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;


namespace Editor
{
    public class SceneRestart
    {
        [MenuItem("RestartScene/Restart Scene #R")]
        private static void RestartScene()
        {
            var currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
}

