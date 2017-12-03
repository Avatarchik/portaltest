using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PartnerBroadcast : NetworkDiscovery {

    public Text debugTextElement;
    public float rate = 1.0f;
    private float ellapsedTime = 0;

    // Use this for initialization
    void Start () {
        Initialize();
        StartAsServer();
	}
	
	// Update is called once per frame
	void Update () {
        ellapsedTime += Time.deltaTime;
        if (ellapsedTime > rate)
        {
            BroadcastMessage("test");
            ellapsedTime = 0f;
        }
    }



}
