using UnityEngine;
using System.Collections;

public class BoyController : MonoBehaviour {

    //private SphereCollider collider;

    private GameObject speechBubble;

    private bool sawBoyOnce = false;
    private bool reactivateSpeechBubble = false;

    void Start() {
        speechBubble = transform.GetChild(0).gameObject;
        speechBubble.SetActive(false);
    }

    void Update() {
        if(reactivateSpeechBubble == true && Input.GetKey(KeyCode.LeftControl)) {
            speechBubble.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player" && sawBoyOnce == false) {
            speechBubble.SetActive(true);
            sawBoyOnce = true;
        } else if(other.tag == "Player" && sawBoyOnce == true) {
            reactivateSpeechBubble = true;
        }
    }

    void OnTriggerExit(Collider other) {
        speechBubble.SetActive(false);
    }

}
