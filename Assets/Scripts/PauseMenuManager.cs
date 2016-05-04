using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour {

	public static PauseMenuManager PM;

    public static bool gamePaused = false;

    private GameObject canvas;

    void Awake() {

        if(PM == null) {
            PM = this;
        }

        canvas = transform.GetChild(0).gameObject;
        canvas.gameObject.SetActive(false);

    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape) && gamePaused == false) {
            PauseGame();
        } else if(Input.GetKeyDown(KeyCode.Escape) && gamePaused == true) {
            ResumeGame();
        }
    }

    public void PauseGame() {
        Time.timeScale = 0f;
        print("GAME PAUSED");
        gamePaused = true;
        canvas.gameObject.SetActive(true);
    }

    public void ResumeGame() {
        Time.timeScale = 1f;
        print("GAME RESUMED");
        gamePaused = false;
        canvas.gameObject.SetActive(false);
    }

    public void LevelSelect() {

    }

    public void SaveGame() {

    }

    public void Options() {

    }

    public void ExitGame() {
        gamePaused = false;
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}
