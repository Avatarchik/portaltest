using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class InteractInput : NetworkBehaviour {
    private float maxInteractDistance = 5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1")) {
            
        }

    }

    [Command]
    void CmdFireInteract(Vector3 origin, Vector3 direction)
    {
        RaycastHit hit;
        Ray ray = new Ray(origin, direction);
        Debug.DrawRay(ray.origin, ray.direction * 3f, Color.red, 1f);

        bool result = Physics.Raycast(ray, out hit, maxInteractDistance);

        if (result)
        {
            InteractHandle handle = hit.transform.GetComponent<InteractHandle>();
            if (handle != null)
            {

            }
        }

        //RpcProcessShotEffects(result, hit.point);
    }
}
