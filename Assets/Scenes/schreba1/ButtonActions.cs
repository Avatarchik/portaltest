using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ButtonActions : MonoBehaviour {

    public NetworkManager myNetworkmanager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void JoinGame()
    {
        myNetworkmanager.StartClient();
    }

    public void HostGame()
    {
        myNetworkmanager.StartHost();
    }
}
