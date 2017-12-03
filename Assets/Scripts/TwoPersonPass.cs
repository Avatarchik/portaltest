using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TwoPersonPass : PuzzleElement {

    public GameObject Door;
    public int minPlayers = 1;
    private int playerCount = 0;

    public override PuzzleElementType GetElementType()
    {
        return PuzzleElementType.GoalDoor;
    }

    public override GameObject GetLinkedElement()
    {
        return null;
    }

    public override GameObject GetRootGameObject()
    {
        return gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        var doorAnim = Door.GetComponent<Animator>();

        var player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            playerCount++;
            if (playerCount == minPlayers) {
                doorAnim.SetBool("character_nearby", true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var doorAnim = Door.GetComponent<Animator>();
        var player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            playerCount--;
            if (playerCount < minPlayers) {
                doorAnim.SetBool("character_nearby", false);
            }
        }
    }

}
