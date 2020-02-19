using UnityEngine;
using System.Collections;

public class ScrollSwitcher : MonoBehaviour {

    public GameObject withWeapon;
    public GameObject noWeapon;
    public Animator anim;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnSwitched(bool value) {
        anim.SetBool("swordEquip", value);
        if (value)
        {
            anim.SetTrigger("idleToSwordTrigger");
            withWeapon.SetActive(true);
            noWeapon.SetActive(false);
        }
        else {
            anim.SetTrigger("swordToIdleTrigger");
            withWeapon.SetActive(false);
            noWeapon.SetActive(true);
        }
    }   

}
