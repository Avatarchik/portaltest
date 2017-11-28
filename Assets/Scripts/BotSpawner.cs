using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BotSpawner : NetworkBehaviour
{
    [SerializeField] GameObject botPrefab;
    public List<GameObject> puzzleItems;

    [ServerCallback]
    void Start()
    {
        GameObject obj = Instantiate(botPrefab, transform.position, transform.rotation);
        obj.GetComponent<NetworkIdentity>().localPlayerAuthority = false;
        var puzzleBot = obj.AddComponent<PuzzleBot>();
        puzzleBot.puzzleItems = puzzleItems;
        NetworkServer.Spawn(obj);
    }
}