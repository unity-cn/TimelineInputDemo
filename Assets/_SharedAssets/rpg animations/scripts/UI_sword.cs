using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_sword : MonoBehaviour
{

    public Animator anim;

    //Idle Buttons
    public void SwordIdleOnClick()
    {
        anim.SetTrigger("swordIdleTrigger");
        anim.SetFloat("swordWalkSelect", 0f);
    }


    //Strike Buttons
    public void SwordStrike01OnClick()
    {
        anim.SetTrigger("swordStrikeTrigger");
        anim.SetInteger("swordStrikeSelect", 1);
    }

    public void SwordStrike02OnClick()
    {
        anim.SetTrigger("swordStrikeTrigger");
        anim.SetInteger("swordStrikeSelect", 2);
    }

    public void SwordStrike03OnClick()
    {
        anim.SetTrigger("swordStrikeTrigger");
        anim.SetInteger("swordStrikeSelect", 3);
    }

    public void SwordSpinningSlashOnClick()
    {
        anim.SetTrigger("swordStrikeTrigger");
        anim.SetInteger("swordStrikeSelect", 4);
    }

    public void SwordStrikeDownOnClick()
    {
        anim.SetTrigger("swordStrikeTrigger");
        anim.SetInteger("swordStrikeSelect", 5);
    }

    public void SwordStrikeForwardOnClick()
    {
        anim.SetTrigger("swordStrikeTrigger");
        anim.SetInteger("swordStrikeSelect", 6);
    }
    
    public void SwordGroundStrikeOnClick()
    {
        anim.SetTrigger("swordStrikeTrigger");
        anim.SetInteger("swordStrikeSelect", 7);
    }

    //Hit Buttons
    public void SwordHit01OnClick()
    {
        anim.SetTrigger("swordHitTrigger");
        anim.SetInteger("swordHitSelect", 1);
    }

    public void SwordHit02OnClick()
    {
        anim.SetTrigger("swordHitTrigger");
        anim.SetInteger("swordHitSelect", 2);
    }

    //Death Buttons
    public void SwordDeathOnClick()
    {
        anim.SetTrigger("swordDeathTrigger");
    }
}
