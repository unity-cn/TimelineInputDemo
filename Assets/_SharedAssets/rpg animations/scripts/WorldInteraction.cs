using UnityEngine;
using System.Collections;

public class WorldInteraction : MonoBehaviour {

    Animator anim;
    AnimationClip clip;

    bool running = false;
    bool walkBackward = false;

    bool swordEquip;
    bool weaponHide;
    float swordWalking;

    Vector3? touchPosition = null;

	
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        swordEquip = anim.GetBool("swordEquip");
        swordWalking = anim.GetFloat("swordWalkSelect");

        if (touchPosition != null)
        {
            if (Vector3.Distance(touchPosition.GetValueOrDefault(), gameObject.transform.position) < 0.1f)
            {
                anim.SetFloat("walkSelect", 0f);
                anim.SetFloat("swordWalkSelect", 0f);
                touchPosition = null;
            }
        }

        if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) {
            if (Input.GetMouseButtonDown(0) )
            {
                HandleInteraction();
            }
            if (Input.GetMouseButton(0) && touchPosition != null)
            {
                HandleInteraction();
            }
        }
            
    }

    void HandleInteraction()
    {
        if (GetInteraction())
        {
            if (swordEquip == true)
            {
                anim.SetTrigger("walkTrigger");
                anim.SetFloat("swordWalkSelect", -0.5f);
            }
            if (walkBackward)
            {
                anim.SetTrigger("walkTrigger");
                anim.SetFloat("walkSelect", -0.5f);
            }
            else if (swordEquip == true)
            {
                anim.SetTrigger("walkTrigger");
                anim.SetFloat("swordWalkSelect", 0.4f);
            }
            else
            {
                anim.SetTrigger("walkTrigger");
                anim.SetFloat("walkSelect", running ? 1f : 0.4f);
            }
        }
    }



    bool GetInteraction()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;
        if(Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactedObject = interactionInfo.collider.gameObject;

            if (!walkBackward || swordWalking > 0 )
            {
                gameObject.transform.LookAt(interactionInfo.point);
            }
            else
            {
                gameObject.transform.rotation = Quaternion.LookRotation(gameObject.transform.position - interactionInfo.point);

            }

            touchPosition = interactionInfo.point;
            return true;
        }

        touchPosition = null;
        return false;
    }
    
    // Toggle Buttons

        //Run
    public void OnRunToggled(bool run)
    {
        running = run;
    }


        //WalkBackward
    public void OnWalkbackwardToggled(bool walkback)
    {
        walkBackward = walkback;

    }






}
