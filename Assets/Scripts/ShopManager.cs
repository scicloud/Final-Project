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

        canvas = transform.GetChild(0).GetComponent<Canvas>();
        canvas.gameObject.SetActive(false);

    }

    public void EnterShop() {
        canvas.gameObject.SetActive(true);
    }

    public void ExitShop() {
        canvas.gameObject.SetActive(false);
    }
}
