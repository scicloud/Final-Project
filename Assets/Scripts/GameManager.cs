using UnityEngine;
using System.Collections;
using System;
using Com.LuisPedroFonseca.ProCamera2D;

public enum GameState {
    PLAY,
    PAUSED,
    MAINMENU
};

public class GameManager : MonoBehaviour {

    public static GameManager gm;

    public Transform playerPrefab;
    public Transform tempPlayerPrefab;

    public Transform spawnPoint;

    public Transform coinPrefab;

    public int currentCoins = 0;

    void Awake() {
        if(gm == null) {
            gm = this;
        }
    }

    public void DestroyPlayer(Player player) {
        Destroy(player.gameObject);
        RespawnPlayer();
        ResetThings();
    }

    private void RespawnPlayer() {
        tempPlayerPrefab = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation) as Transform;
        ProCamera2D.Instance.AddCameraTarget(tempPlayerPrefab);
        //ProCamera2D.Instance.Reset();                                                                         //neither of these work :(
        //ProCamera2D.Instance.MoveCameraInstantlyToPosition(tempPlayerPrefab.transform.position);
    }

    public void CollectCoin(GameObject coin) {
        AudioManager.AM.PlayCoinSound();
        Destroy(coin);
        currentCoins++;
        UIManager.UI.UpdateUICoinCount(currentCoins);
    }

    private void ResetThings() {
        UIManager.UI.ResetUICoinCount();
        UIManager.UI.ResetHealthBar();
        UIManager.UI.ResetUIAmmunition();
        Instantiate(coinPrefab);
    }

}
