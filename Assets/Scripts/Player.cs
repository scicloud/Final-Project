using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private int health = 10;

    public Transform present;
    public Transform presentPos;

    private bool enteredShop = false;

    private int ammoCapacity = 3;
    private int currentAmmo = 0;


    void Start() {
        currentAmmo = ammoCapacity;
    }
	
	// Update is called once per frame
	void Update () {

        FallToDeath();

        if(Input.GetKeyDown(KeyCode.Z) && currentAmmo > 0) {
            ThrowPresent();
            UIManager.UI.DecrementUIAmmunition(0);
            currentAmmo--;
        }

        if(enteredShop == true && Input.GetKeyDown(KeyCode.S)) {
            Debug.Log("You entered the shop!");
            ShopManager.SM.EnterShop();
        }

	}

    private void FallToDeath() {
        if(transform.position.y <= -10) {
            GameManager.gm.DestroyPlayer(this);
        }
    }

    private void ThrowPresent() {
        Debug.Log("Threw present");

        GameObject temp = (Instantiate(present, presentPos.position, Quaternion.identity) as Transform).gameObject;
        //temp.transform.parent = this.transform;

        //Throw present straight using raycast?
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Shop") {
            enteredShop = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Shop") {
            enteredShop = false;
        }
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Icicle" && health > 0) {
            DamagePlayer(1);
            print("You hit an icicle, ouchies!");
            UIManager.UI.DecrementHealthBar();
            if(health <= 0) {
                GameManager.gm.DestroyPlayer(this);
                UIManager.UI.ResetHealthBar();
            }
        }
    }

    private void DamagePlayer(int dmg) {
        health = health - dmg;
    }
}
