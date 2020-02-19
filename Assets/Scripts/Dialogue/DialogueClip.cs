using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[System.Serializable]
public class DialogueClip : PlayableAsset, ITimelineClipAsset
{
    public DialogueTypes dialogueType;
    public string dialogContent;
    public float jumpToTime = -1;

    public bool hasToPause = false;

    public DialogueBehaviour template = new DialogueBehaviour();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.None; }
    }

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<DialogueBehaviour>.Create(graph, template);
        var dialogueBehaviour = playable.GetBehaviour();
        dialogueBehaviour.dialogueType = dialogueType;
        dialogueBehaviour.dialogContent = dialogContent;
        dialogueBehaviour.hasToPause = hasToPause;
        dialogueBehaviour.jumpToTime = jumpToTime;
        return playable;
    }
}