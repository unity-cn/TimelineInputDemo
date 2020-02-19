using System.Collections;
using UnityEngine;

public class HidingMachineBehaviour : StateMachineBehaviour
{
    [SerializeField]
    float t;

    [SerializeField]
    string meshName; 

    // This will be called when the animator first transitions to this state.
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("OnStateEnter");
        var sword = GameObject.Find(meshName);
        var v = sword.GetComponent<HiderInTime>();
        sword.GetComponent<HiderInTime>().hide(t);
    }
    // This will be called when the animator first transitions to this state.
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("OnStateExit");
        var sword = GameObject.Find(meshName);
        sword.GetComponent<HiderInTime>().restore();
    }
}