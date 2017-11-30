using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerOffline : MonoBehaviour
{
   
 
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

 
    void Update()
    {
        anim.SetFloat("Speed", Input.GetAxis("Vertical"));
        anim.SetFloat("Strafe", Input.GetAxis("Horizontal"));
    }


    
}