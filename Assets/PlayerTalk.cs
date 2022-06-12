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

    [YarnCommand("hatGet")]
    public static void hatGet()
    {
        Debug.Log("You should have a hat now! Shame!");
        // Turn on hat child object. 
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
