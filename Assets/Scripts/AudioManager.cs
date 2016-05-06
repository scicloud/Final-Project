using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

    public static AudioManager AM;

    private AudioSource coinSound;

    void Awake() {
        if(AM == null) {
            AM = this;
        }
    }

    void Start() {
        coinSound = GetComponent<AudioSource>();
    }

    public void PlayCoinSound() {
        coinSound.Play();
    }

}
