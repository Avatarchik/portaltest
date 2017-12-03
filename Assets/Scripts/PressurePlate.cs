using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PressurePlate : PuzzleElement
{
    public GameObject ToggleObject;
    public bool ToggledState { get; private set; }

    public void Awake()
    {
        ToggledState = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            RemoteToggle(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        RemoteToggle(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        RemoteToggle(false);
    }

    private void OnCollisionExit(Collision collision)
    {
        RemoteToggle(true);
    }

    private void RemoteToggle(bool toggle)
    {
        if (isServer)
        {
            RpcRemoteToggle(toggle);
        }
        else
        {
            ToggleObject.SetActive(toggle);
            ToggledState = toggle;
        }
    }

    [Command]
    private void CmdRemoteToggle(bool toggle)
    {
        ToggleObject.SetActive(toggle);
    }

    [ClientRpc]
    private void RpcRemoteToggle(bool toggle)
    {
        ToggleObject.SetActive(toggle);
        ToggledState = toggle;
    }

    public override PuzzleElementType GetElementType()
    {
        return PuzzleElementType.PressurePlate;
    }

    public override GameObject GetLinkedElement()
    {
        return ToggleObject;
    }

    public override GameObject GetRootGameObject()
    {
        return gameObject;
    }
}
