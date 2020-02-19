using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackColor(0.855f, 0.03f, 0.087f)]
[TrackClipType(typeof(DialogueClip))]
public class DialogueTrack : TrackAsset
{
    //public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    //{
    //    return ScriptPlayable<DialogueBehaviour>.Create(graph, inputCount);
    //}
}
