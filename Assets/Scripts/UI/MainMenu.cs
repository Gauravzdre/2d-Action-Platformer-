using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    [SerializeField] Button playButton;
    [SerializeField] Button quitButton;

    private void Start() {
        playButton.onClick.AddListener(() => {
            SceneManager.LoadScene("SampleScene");
        });
        quitButton.onClick.AddListener(() => {
            Application.Quit();
        });
    }
}
