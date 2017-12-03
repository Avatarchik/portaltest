using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using UnityEngine.AI;

public class PuzzleBot : NetworkBehaviour
{
    
    private int currentItem = 0;
    //PlayerShooting playerShooting;
    private NetworkAnimator anim;
    private NavMeshAgent nav;
    private CapsuleCollider capsuleCollider;
    private float ellapsedTime = 0f;
    public bool showDebug = true;
    public List<PuzzleElement> puzzleItems;

    void Awake()
    {
        //playerShooting = GetComponent<PlayerShooting>();
        anim = GetComponent<NetworkAnimator>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        nav = GetComponent<NavMeshAgent>();
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
            var current = puzzleItems[currentItem];
            switch (current.GetElementType()) {
                case PuzzleElementType.PressurePlate:
                    EvaluatePressurePlate(current);
                    break;
                case PuzzleElementType.GoalDoor:
                    EvaluateGoalDoor(current);
                    break;
                default:
                    break;
            }            
        }    
    }

    [Server]
    void EvaluatePressurePlate(PuzzleElement puzzleElement)
    {
        var pressurePlate = puzzleElement.GetRootGameObject().GetComponent<PressurePlate>();
        if (pressurePlate.ToggledState)
        {
            currentItem++;
            return;
        }
        /*if (Vector3.Distance(pressurePlate.transform.position, transform.position) > 0.3f)
        {
            transform.LookAt(pressurePlate.transform.position);
            transform.position = Vector3.Lerp(transform.position, pressurePlate.transform.position, 0.01f);
        }*/
        
        nav.SetDestination(pressurePlate.transform.position);        
    }

    [Server]
    void EvaluateGoalDoor(PuzzleElement puzzleElement) {
        nav.SetDestination(puzzleElement.transform.position);        
    }
    [Server]
    void EvaluateLaserTrap(PuzzleElement puzzleElement) {
        if (!puzzleElement.isActiveAndEnabled) {
            currentItem++;
            return;
        }
        else{
            currentItem--;
        }
    }

}