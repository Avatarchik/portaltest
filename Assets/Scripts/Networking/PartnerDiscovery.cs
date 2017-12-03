using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PartnerDiscovery : NetworkDiscovery {

    public Text debugTextElement;
    public float rate = 1.0f;
    private float ellapsedTime = 0;

	// Use this for initialization
	void Start () {
        Initialize();
        StartAsClient();
	}
	
	// Update is called once per frame
	void Update () {

	}

    public override void OnReceivedBroadcast(string fromAddress, string data)
    {   
        Debug.Log(string.Format("broadcast received from {0} : {1} ",fromAddress,data));
        base.OnReceivedBroadcast(fromAddress, data);
    }
}

   
