using UnityEngine;
using System.Collections;

public class ShopManager : MonoBehaviour {

    public static ShopManager SM;

    private Canvas canvas;

    void Awake() {

        if(SM == null) {
            SM = this;
        }

    }

    void Start() {

        canvas = GetComponent<Canvas>();

    }

    public void EnterShop() {

        canvas.gameObject.SetActive(true);

    }
}
