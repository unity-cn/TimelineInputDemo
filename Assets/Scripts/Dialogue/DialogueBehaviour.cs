using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class DialogueBehaviour : PlayableBehaviour
{
    public DialogueTypes dialogueType;
    public string dialogContent = string.Empty;
    public bool hasToPause = false;
    public float jumpToTime = -1;

    private bool clipPlayed = false;
    private bool pauseScheduled = false;

    private PlayableDirector director;

    public override void OnPlayableCreate(Playable playable)
    {
        director = (playable.GetGraph().GetResolver() as PlayableDirector);
    }

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        if (!clipPlayed && info.weight > 0f)
        {
            if (Application.isPlaying)
            {
                GameLogicManager.Instance.SetDialog(dialogContent, dialogueType);

                if (hasToPause)
                {
                    pauseScheduled = true;
                }
            }
            clipPlayed = true;
        }
    }

    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        if (pauseScheduled)
        {
            pauseScheduled = false;
            GameLogicManager.Instance.PauseTimeline(director, CallbackFuntion);
        }
    }

    public void CallbackFuntion()
    {
        if (jumpToTime >= 0.0001f)
            director.time = jumpToTime;
    }
}