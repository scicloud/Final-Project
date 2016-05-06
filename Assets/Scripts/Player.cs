using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private int health = 10;                                                        //health of player

    public Transform present;                                                       //gameobject of present prefab
    public Transform presentPos;                                                    //position where present should be instantiated

    public bool inShopRange = false;                                                //if player is in the shop range or not
    public bool inShop = false;                                                     //if player is in the shop or not

    private int ammoCapacity = 3;                                                   //max presents player can have
    private int currentAmmo = 0;                                                    //current amount of presents player has
    private int indexToDisable = 0;                                                 //index of ammunitionImages list for UI (3 presents in UI)


    void Start() {
        currentAmmo = ammoCapacity;                                                 //set current ammo to max ammo at the start of the player instantiation
    }
	
	void Update () {

        FallToDeath();

        if(Input.GetKeyDown(KeyCode.Z) && currentAmmo > 0) {
            ThrowPresent();
            UIManager.UI.DecrementUIAmmunition(indexToDisable);
            currentAmmo--;
            indexToDisable++;
        }

        if(inShopRange == true && Input.GetKeyDown(KeyCode.S)) {
            inShop = true;
            ShopManager.SM.EnterShop();
        }

	}

    private void FallToDeath() {
        if(transform.position.y <= -10) {
            GameManager.gm.DestroyPlayer(this);
        }
    }

    private void ThrowPresent() {

        GameObject temp = (Instantiate(present, presentPos.position, Quaternion.identity) as Transform).gameObject;

        //Throw present straight using raycast?
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Shop") {
            inShopRange = true;
        } else if(other.gameObject.tag == "Coin") {
            GameManager.gm.CollectCoin(other.gameObject);
        } else if(other.gameObject.tag == "Endgame") {
            GameManager.gm.RestartGameToMainMenu();
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Shop") {
            inShopRange = false;
        }
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Icicle" && health > 0) {
            DamagePlayer(1);
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
