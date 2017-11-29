using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TwoPersonPass : NetworkBehaviour {

    public GameObject Door;
    public int minPlayers = 1;
    private int playerCount = 0;

    private void OnStart()
    {
       var doorAnim = Door.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            playerCount++;
            if (playerCount == minPlayers) {

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            playerCount--;
        }
    }

}
