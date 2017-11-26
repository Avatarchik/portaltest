using UnityEngine;
using UnityEngine.Networking;

public class InteractInput : NetworkBehaviour {
    [SerializeField]private float maxInteractDistance = 5f;
    [SerializeField] Transform interactPosition;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            CmdFireInteract(interactPosition.position, interactPosition.forward);
        }
    }

    [Command]
    void CmdFireInteract(Vector3 origin, Vector3 direction)
    {
        RaycastHit hit;
        Ray ray = new Ray(origin, direction);
        Debug.DrawRay(ray.origin, ray.direction * 3f, Color.red, 60f);

        bool result = Physics.Raycast(ray, out hit, maxInteractDistance);

        if (result)
        {
            var handle = hit.transform.GetComponent<InteractHandle>();
            if (handle != null)
            {
                Debug.Log("Touchie the thing");
            }
        }

        //RpcProcessShotEffects(result, hit.point);
    }
}
