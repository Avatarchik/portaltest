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
            RpcRemoteToggle(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //ToggleObject.SetActive(true);
        RpcRemoteToggle(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //ToggleObject.SetActive(false);
        RpcRemoteToggle(false);
    }

    private void OnCollisionExit(Collision collision)
    {
        //ToggleObject.SetActive(true);
        RpcRemoteToggle(true);
    }

    [ClientRpc]
    private void RpcRemoteToggle(bool toggle) {
        ToggleObject.SetActive(toggle);
    }

}
