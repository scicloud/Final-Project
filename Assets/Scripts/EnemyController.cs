using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Present") {
            Destroy(this.gameObject);
        }
    }
}
