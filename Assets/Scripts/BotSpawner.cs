using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class BotSpawner : NetworkBehaviour
{
    [SerializeField] GameObject botPrefab;
    [SerializeField]public List<PuzzleElement> puzzleItems;

    [ServerCallback]
    void Start()
    {
        GameObject obj = Instantiate(botPrefab, transform.position, transform.rotation);
        obj.GetComponent<NetworkIdentity>().localPlayerAuthority = false;
        var nav = obj.AddComponent<NavMeshAgent>();
        var puzzleBot = obj.AddComponent<PuzzleBot>();
        puzzleBot.puzzleItems = puzzleItems;
        NetworkServer.Spawn(obj);
    }
}