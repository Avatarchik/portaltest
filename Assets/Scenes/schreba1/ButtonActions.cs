using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ButtonActions : MonoBehaviour {

    public NetworkManager myNetworkmanager;


    public void JoinGame()
    {
        myNetworkmanager.StartClient();
    }

    public void HostGame()
    {
        myNetworkmanager.StartHost();
    }
}
