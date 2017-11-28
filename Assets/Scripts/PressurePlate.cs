using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PressurePlate : NetworkBehaviour {
    public GameObject ToggleObject;
	
    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<Player>();
        if (player != null) {
            //ToggleObject.SetActive(false);
            RemoteToggle(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //ToggleObject.SetActive(true);
        RemoteToggle(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //ToggleObject.SetActive(false);
        RemoteToggle(false);
    }

    private void OnCollisionExit(Collision collision)
    {
        //ToggleObject.SetActive(true);
        RemoteToggle(true);
    }

    private void RemoteToggle(bool toggle) {
        if (isServer)
        {
            RpcRemoteToggle(toggle);
        }
        else {
            CmdRemoteToggle(toggle);
        }
    }

    [Command]
    private void CmdRemoteToggle(bool toggle) {
        ToggleObject.SetActive(toggle);
        //RpcRemoteToggle(toggle);
    }

    [ClientRpc]
    private void RpcRemoteToggle(bool toggle) {
        ToggleObject.SetActive(toggle);
    }

}
