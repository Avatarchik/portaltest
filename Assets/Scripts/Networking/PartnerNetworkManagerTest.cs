using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PartnerNetworkManagerTest : NetworkManager {

    public void Start()
    {
        Debug.Log("fff");
    }

    public override void OnStartHost() {
        Debug.Log("Host started");
    }
}
