using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class PlayerTalk : MonoBehaviour
{
    public GameObject dialogueHolder;
    DialogueRunner dialogueRunner;
    [SerializeField] private bool canTalk = false;
    [SerializeField] private string targetNode = "Start";

    private void Start() 
    {
        dialogueRunner = dialogueHolder.GetComponent<DialogueRunner>();
        dialogueRunner.onDialogueComplete.AddListener(DoneTalking);
    }

    private void OnTalk()
    {
        Debug.Log("You've tried to talk! ");
        Debug.Log(dialogueRunner.Dialogue.CurrentNode);
        Debug.Log(dialogueRunner.startNode);
        // I'll need to run the dialogue from here.
        // dialogueRunner.Dialogue.SetNode("Start"); // This SHOULD start at.. start
        // Okay, so we can set the node, how do we kick start this sucker?
        if(canTalk)
        {
            dialogueRunner.StartDialogue(targetNode);
            gameObject.GetComponent<ShuttleMovement>().canMove = false;
            dialogueRunner.onDialogueComplete.AddListener(DoneTalking);
        }

    }

    [YarnCommand("die")]
    public static void OnDisable() {
        Debug.Log("You are made dead (by the writers)");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    [YarnCommand("win")]
    public static void Win()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        // SceneManager.loa
    }

    [YarnCommand("beginning")]
    public static void Beginning()
    {

        SceneManager.LoadScene(0);
    }

    [YarnCommand("hatGet")]
    public void hatGet()
    {
        Debug.Log("You should have a hat now! Shame!");
        // Turn on hat child object. 
        // << hatGet Hero >>
        gameObject.GetComponent<ShuttleMovement>().Hat.SetActive(true);
        
    }

    private void DoneTalking()
    {
        gameObject.GetComponent<ShuttleMovement>().canMove = true;
    }

    public void TalkRange(bool inRange, string targetNode = "Start")
    {
        // This will fire when we enter or leave talk range.
        this.targetNode = targetNode;
        if(inRange) canTalk = true;
        else canTalk = false;
    }
}
