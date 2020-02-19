using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_no_weapon : MonoBehaviour
{
    public Animator anim;

    //Idle Buttons
    public void Idle01OnClick()
    {
        anim.SetTrigger("idleTrigger");
        anim.SetFloat("idleSelect", 0.1f);
        anim.SetFloat("walkSelect", 0f);
    }

    public void Idle02OnClick()
    {
        anim.SetTrigger("idleTrigger");
        anim.SetFloat("idleSelect", 0.6f);
        anim.SetFloat("walkSelect", 0f);
    }

    //Greatings Buttons
    public void HelloFriendlyOnClick()
    {
        anim.SetTrigger("helloTrigger");
        anim.SetFloat("helloSelect", 0.1f);
    }

    public void HelloNeutralOnClick()
    {
        anim.SetTrigger("helloTrigger");
        anim.SetFloat("helloSelect", 0.5f);
    }

    public void HelloNegativeOnClick()
    {
        anim.SetTrigger("helloTrigger");
        anim.SetFloat("helloSelect", 1f);
    }

    //Talking Buttons
    public void TalkFriendlyOnClick()
    {
        anim.SetTrigger("talkTrigger");
        anim.SetFloat("talkSelect", 0.1f);
    }

    public void TalkNeutralOnClick()
    {
        anim.SetTrigger("talkTrigger");
        anim.SetFloat("talkSelect", 0.5f);
    }

    public void TalkNegativeOnClick()
    {
        anim.SetTrigger("talkTrigger");
        anim.SetFloat("talkSelect", 0.7f);
    }

    public void TalkAgressiveOnClick()
    {
        anim.SetTrigger("talkTrigger");
        anim.SetFloat("talkSelect", 1f);
    }

    //Listening Buttons
    public void ListenFriendlyOnClick()
    {
        anim.SetTrigger("listenTrigger");
        anim.SetFloat("listenSelect", 0.1f);
    }

    public void ListenNeutralOnClick()
    {
        anim.SetTrigger("listenTrigger");
        anim.SetFloat("listenSelect", 0.5f);
    }

    public void ListenNegativeOnClick()
    {
        anim.SetTrigger("listenTrigger");
        anim.SetFloat("listenSelect", 1);
    }

    //PickUps and Craft Buttons
    public void PickUpFloorOnClick()
    {
        anim.SetTrigger("pickcraftTrigger");
        anim.SetFloat("pickcraftSelect", 0.1f);
    }

    public void PickUpStandOnClick()
    {
        anim.SetTrigger("pickcraftTrigger");
        anim.SetFloat("pickcraftSelect", 0.5f);
    }

    public void CraftOnClick()
    {
        anim.SetTrigger("pickcraftTrigger");
        anim.SetFloat("pickcraftSelect", 1);
    }

    //Hits Buttons
    public void Hit01OnClick()
    {
        anim.SetTrigger("hitTrigger");
        anim.SetFloat("hitSelect", 0.1f);
    }

    public void Hit02OnClick()
    {
        anim.SetTrigger("hitTrigger");
        anim.SetFloat("hitSelect", 0.5f);
    }

    public void Hit03OnClick()
    {
        anim.SetTrigger("hitTrigger");
        anim.SetFloat("hitSelect", 1);
    }

    //Death Buttons
    public void Death01OnClick()
    {
        anim.SetTrigger("deathTrigger");
        anim.SetFloat("deathSelect", 0.1f);
    }

    public void Death02OnClick()
    {
        anim.SetTrigger("deathTrigger");
        anim.SetFloat("deathSelect", 0.5f);
    }

    public void Death03OnClick()
    {
        anim.SetTrigger("deathTrigger");
        anim.SetFloat("deathSelect", 1);
    }
}

