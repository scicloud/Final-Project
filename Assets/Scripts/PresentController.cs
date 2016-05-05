using UnityEngine;
using System.Collections;

public class PresentController : MonoBehaviour {

    private float presentSpeed = 5f;
    private float startPos;
    private int presentAmmo;

    private Rigidbody presentRigidbody;

    private Player player;

    // Use this for initialization
    void Start () {
        presentRigidbody = GetComponent<Rigidbody>();
        startPos = this.gameObject.transform.position.x;
        player = FindObjectOfType<Player>();
        if(player.transform.localScale.x < 0) {
            presentSpeed = -presentSpeed;
        }
    }
	
	// Update is called once per frame
	void Update () {
        presentRigidbody.velocity = new Vector3(presentSpeed, presentRigidbody.velocity.y, presentRigidbody.velocity.z);

        if(this.gameObject.transform.position.x > startPos + 10 || this.gameObject.transform.position.x < startPos - 10) {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision other) {
        Destroy(this.gameObject);
    }


}
