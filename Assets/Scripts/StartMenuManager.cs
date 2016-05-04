using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Fade {
    IN,
    OUT
};

public class StartMenuManager : MonoBehaviour {

    private AudioSource audio;

    void Start() {
        audio = GameObject.FindGameObjectWithTag("Menu Music").GetComponent<AudioSource>();
    }

    public void Play() {
        FadeAudio(4.0f, Fade.OUT);
        SceneManager.LoadScene(1);
    }

    public void LevelSelect() {

    }

    public void Load() {

    }

    public void Quit() {
        Application.Quit();
    }

    private IEnumerator FadeAudio(float timer, Fade fadeType) {
        float start = fadeType == Fade.IN ? 0.0f : 1.0f;
        float end = fadeType == Fade.IN ? 1.0f : 0.0f;
        float i = 0.0f;
        float step = 1.0f / timer;

        while(i <= 1.0) {
            i = i + (step * Time.deltaTime);
            audio.volume = Mathf.Lerp(start, end, i);
            yield return new WaitForSeconds(5);
        }
        //SceneManager.LoadScene(1);
    }

}
