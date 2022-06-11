using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        }
    }

    public void TalkRange(bool inRange)
    {
        // This will fire when we enter or leave talk range.
        if(inRange) canTalk = true;
        else canTalk = false;
    }
}
