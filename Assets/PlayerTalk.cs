using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class PlayerTalk : MonoBehaviour
{
    public GameObject dialogueHolder;
    DialogueRunner dialogueRunner;

    private void Start() 
    {
        dialogueRunner = dialogueHolder.GetComponent<DialogueRunner>();
    }

    private void OnTalk()
    {
        Debug.Log("You've tried to talk! ");
        Debug.Log(dialogueRunner.Dialogue.CurrentNode);
        Debug.Log(dialogueRunner.startNode);
    }
}
