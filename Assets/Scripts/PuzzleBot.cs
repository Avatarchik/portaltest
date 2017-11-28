using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

public class PuzzleBot : NetworkBehaviour
{
    public bool showDebug = true;
    public List<GameObject> puzzleItems;
    private int currentItem = 0;
    //PlayerShooting playerShooting;
    NetworkAnimator anim;
    float ellapsedTime = 0f;


    void Awake()
    {
        //playerShooting = GetComponent<PlayerShooting>();
        anim = GetComponent<NetworkAnimator>();

        //GetComponent<Player>().playerName = "Bot";
    }

    [ServerCallback]
    void Update()
    {
        anim.animator.SetFloat("Speed", 0f);
        anim.animator.SetFloat("Strafe", 0f);

        if (Input.GetKey(KeyCode.Keypad8))
            anim.animator.SetFloat("Speed", 1f);

        if (Input.GetKey(KeyCode.Keypad2))
            anim.animator.SetFloat("Speed", -1f);

        if (Input.GetKey(KeyCode.Keypad4))
            anim.animator.SetFloat("Strafe", -1f);

        if (Input.GetKey(KeyCode.Keypad6))
            anim.animator.SetFloat("Strafe", 1f);

        if (Input.GetKeyDown(KeyCode.Keypad7))
            anim.SetTrigger("Died");

        if (Input.GetKeyDown(KeyCode.Keypad9))
            anim.SetTrigger("Restart");


        BotEvaluate();
    }

    [Server]
    void BotEvaluate()
    {
        ellapsedTime += Time.deltaTime;
        ellapsedTime = 0f;
        if (puzzleItems[currentItem] != null) {
            if (Vector3.Distance(puzzleItems[currentItem].transform.position, transform.position) > 0.3f) {
                //var nextPosition = Vector3.MoveTowards(transform.position, puzzleItems[currentItem].transform.position, 0.1f);
                transform.LookAt(puzzleItems[currentItem].transform.position);
                transform.position = Vector3.Lerp(transform.position, puzzleItems[currentItem].transform.position,0.01f);
                //gameObject.GetComponent<CharacterController>().SimpleMove(Vector3.forward * 0.1f);

            }
            
        }
        //if (playerShooting.enabled)
        //{
        //    playerShooting.FireAsBot();
        //}
    }
}