using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager UI;

    private Image healthBar;
    private float healthBarFillAmount = 1f;

    private Text coinsText;

    public List<Image> ammunitionImages;

    void Awake() {
        if(UI == null) {
            UI = this;
        }
    }

    void Start() {
        healthBar = GetComponentInChildren<Canvas>().transform.GetChild(4).GetChild(0).GetComponent<Image>();
        coinsText = transform.GetChild(0).GetChild(0).GetComponent<Text>();
    }

    public void DecrementHealthBar() {
        if(healthBar.fillAmount != 0) {
            this.healthBarFillAmount -= 0.1f;
            healthBar.fillAmount = this.healthBarFillAmount;
        }
    }

    public void ResetHealthBar() {
        healthBar.fillAmount = 1f;
        this.healthBarFillAmount = 1f;
    }

    public void DecrementUIAmmunition(int ammoNum) {
        if(ammunitionImages.Count > 0) {
            //Destroy(ammunitionImages[ammoNum].gameObject);
            //ammunitionImages.RemoveAt(ammoNum);
            ammunitionImages[ammoNum].gameObject.SetActive(false);
        } else {
            print("You're out of ammo!");
        }
    }

    public void UpdateUICoinCount(int coins) {
        coinsText.text = "Coins: " + coins;
    }

    public void ResetUICoinCount() {
        coinsText.text = "Coins: 0";
    }

    public void ResetUIAmmunition() {

        foreach(Image img in ammunitionImages) {
            img.gameObject.SetActive(true);
        }

        //ammunitionImages = new List<Image>();
        //print("hello world");
        //foreach(Transform child in transform.GetChild(0)) {
        //    if(child.gameObject.tag == "Ammunition") {
        //        ammunitionImages.Add(child.GetComponent<Image>());
        //        print("Added: " + child.GetComponent<Image>().name);
        //    }
        //}
    }

}
