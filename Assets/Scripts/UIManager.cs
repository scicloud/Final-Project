﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager UI;

    private float healthBarFillAmount = 1f;

    private Image healthBar;

    public List<Image> ammunitionImages;

    void Awake() {
        if(UI == null) {
            UI = this;
        }
    }

    void Start() {
        healthBar = GetComponentInChildren<Canvas>().transform.GetChild(4).GetChild(0).GetComponent<Image>();
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
            Destroy(ammunitionImages[ammoNum].gameObject);
            ammunitionImages.RemoveAt(ammoNum);
        } else {
            print("You're out of ammo!");
        }
    }

}
