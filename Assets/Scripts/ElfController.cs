using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ElfController : MonoBehaviour {

    //private SphereCollider collider;

    private GameObject speechBubble;

    private bool sawBoyOnce = false;
    private bool reactivateSpeechBubble = false;
    private bool inBoyRange = false;

    private string textToIterate;
    private Text textComponent;

    void Start() {
        speechBubble = transform.GetChild(0).gameObject;
        textComponent = speechBubble.GetComponent<Text>();
        textToIterate = textComponent.text;
        textComponent.text = "";
        speechBubble.SetActive(false);
    }

    void Update() {
        if(inBoyRange && reactivateSpeechBubble == true && Input.GetKey(KeyCode.LeftControl)) {
            speechBubble.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player" && sawBoyOnce == false) {
            speechBubble.SetActive(true);

            StartCoroutine(TypeText());
            sawBoyOnce = true;
            inBoyRange = true;
        } else if(other.tag == "Player" && sawBoyOnce == true) {
            reactivateSpeechBubble = true;
            inBoyRange = true;
        }
    }

    void OnTriggerExit(Collider other) {
        speechBubble.SetActive(false);
        inBoyRange = false;
    }

    IEnumerator TypeText() {
        foreach(char letter in textToIterate.ToCharArray()) {
            textComponent.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }

}
