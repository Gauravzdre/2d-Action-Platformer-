using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Manager : MonoBehaviour {

    private void Start() {
        Health.onDeath += delegate () {
            SceneManager.LoadScene("MainMenu");
            SceneManager.UnloadSceneAsync(1);
        };
    }
}
