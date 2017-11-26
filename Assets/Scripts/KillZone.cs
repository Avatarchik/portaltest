using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class KillZone : NetworkBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.gameObject.GetComponent<Player>();
        if (playerHealth != null) {
            playerHealth.Die();
        }
    }

}
