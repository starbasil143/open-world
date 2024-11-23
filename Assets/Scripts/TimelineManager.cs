using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    private GameObject _player;
    private GameObject _dialogueManager;
    private PlayableDirector _director;
    public List<TextAsset> dialogueAssets;
    

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _dialogueManager = GameObject.FindGameObjectWithTag("DialogueManager");
        _director = GetComponent<PlayableDirector>();
    }


    public void DTrigger1()
    {
        DialogueManager.instance.EnterDialogue(dialogueAssets[0], true);
        PauseTimeline();
    }
    public void DTrigger2()
    {
        DialogueManager.instance.EnterDialogue(dialogueAssets[1], true);
        PauseTimeline();
    }
    public void DTrigger3()
    {
        DialogueManager.instance.EnterDialogue(dialogueAssets[2], true);
        PauseTimeline();
    }
    public void DTrigger4()
    {
        DialogueManager.instance.EnterDialogue(dialogueAssets[3], true);
        PauseTimeline();
    }
    public void DTrigger5()
    {
        DialogueManager.instance.EnterDialogue(dialogueAssets[4], true);
        PauseTimeline();
    }
    public void DTrigger6()
    {
        DialogueManager.instance.EnterDialogue(dialogueAssets[5], true);
        PauseTimeline();
    }

    public void PauseTimeline()
    {
        _director.playableGraph.GetRootPlayable(0).SetSpeed(0);
    }

    public void ResumeTimeline()
    {
        _director.playableGraph.GetRootPlayable(0).SetSpeed(1);
    }

    public void PausePlayer()
    {
        _player.GetComponentInChildren<PlayerMovement>().Pause();
    }

    public void ResumePlayer()
    {
        _player.GetComponentInChildren<PlayerMovement>().Unpause();
    }

    public void DeactivateDirector()
    {
        gameObject.SetActive(false);
    }
}
