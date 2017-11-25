using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class VrAvatarController : NetworkBehaviour
{
    public GameObject VrHeadset;

    void Start()
    {
        var headset = GameObject.FindObjectOfType<SteamVR_Camera>();
        VrHeadset = headset.gameObject;
    }

    void Update()
    {
        if (!isLocalPlayer) return;

        transform.position = VrHeadset.transform.position;
        transform.rotation = VrHeadset.transform.rotation;
    }
}
