using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public enum DialogueTypes
{
    Buttom,
    Left,
    Right
}

public class GameLogicManager : MonoBehaviour
{
    private System.Action _pauseCallbackFunction;

    public static GameLogicManager Instance
    {
        get
        {
            return _instance;
        }
    }
    static GameLogicManager _instance;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Debug.LogError(" Duplicate GameLogicManager");
        }
    }


    public UnityEngine.UI.Text ButtomDialogText;
    public UnityEngine.UI.Text LeftdialogText;
    public UnityEngine.UI.Text RightdialogText;

    public void SetDialog(string dialogContent, DialogueTypes dialogueType )
    {
        switch(dialogueType)
        {
            case DialogueTypes.Buttom:
                ButtomDialogText.text = dialogContent;
                break;
            case DialogueTypes.Left:
                LeftdialogText.text = dialogContent;
                break;
            case DialogueTypes.Right:
                RightdialogText.text = dialogContent;
                break;
        }
    }

    private PlayableDirector timeline;

    public void PauseTimeline(PlayableDirector pd, System.Action action)
    {
        Debug.Log("PauseTimeline: " + pd.time);
        timeline = pd;
        pd.Pause();
        _pauseCallbackFunction += action;
    }

    public void ResumeTimeline(string dialogueType)
    {
        DialogueTypes dt = (DialogueTypes)System.Enum.Parse(typeof(DialogueTypes), dialogueType);
        switch (dt)
        {
            case DialogueTypes.Buttom:
                break;
            case DialogueTypes.Left:
                break;
            case DialogueTypes.Right:
                _pauseCallbackFunction.Invoke();
                _pauseCallbackFunction = null;
                break;
        }
        timeline.Resume();

    }
}
