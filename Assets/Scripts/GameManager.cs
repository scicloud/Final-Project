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

    void Awake() {
        if(gm == null) {
            gm = this;
        }
    }

    public void DestroyPlayer(Player player) {
        Destroy(player.gameObject);
        RespawnPlayer();
    }

    private void RespawnPlayer() {
        tempPlayerPrefab = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation) as Transform;
        ProCamera2D.Instance.AddCameraTarget(tempPlayerPrefab);
    }

}
