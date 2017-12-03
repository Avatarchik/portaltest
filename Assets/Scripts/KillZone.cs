using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class KillZone : PuzzleElement {
    public GameObject linkedElement;
    public override PuzzleElementType GetElementType()
    {
        return PuzzleElementType.LaserTrap;
    }

    public override GameObject GetLinkedElement()
    {
        return linkedElement;
    }

    public override GameObject GetRootGameObject()
    {
        return gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.gameObject.GetComponent<Player>();
        if (playerHealth != null) {
            playerHealth.Die();
        }
    }

}
