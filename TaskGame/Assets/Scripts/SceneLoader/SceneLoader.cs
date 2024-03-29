using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   public void ScenLoad(string sceneName)
   {
      SceneManager.LoadScene(sceneName);
   }
}
