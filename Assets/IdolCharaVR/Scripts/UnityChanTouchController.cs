using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanTouchController : MonoBehaviour {

    public GameObject mainCamera;
    public GameObject targetObject; // 視点UIの対象Object
    public AudioClip voice_01;
    private Animator animator;
    private AudioSource univoice;
    private bool touchFlag = false;

    // Use this for initialization
    void Start ()
    {
        Debug.Log("UnityChanTouch Controller is started");

        animator = GetComponent<Animator>();
        univoice = GetComponent<AudioSource>();
    }
    
    // Update is called once per frame
    void Update ()
    {
        Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.black);     // Sceneでのみ線が見える

            if (hit.collider.gameObject.tag == "UnityChan" && touchFlag == false)
            {
                Debug.Log("hit");
                if (CheckHitGameObject(hit, targetObject) == true)
                {
                    animator.SetBool("Touch", true);
                    univoice.PlayOneShot(voice_01, 2f);
                    touchFlag = true;
                }
            }
        }
        else
        {
            touchFlag = false;
            animator.SetBool("Touch", false);
        }
    }

    public bool CheckHitGameObject(RaycastHit hit, GameObject obj)
    {
        bool result = false;
        if (hit.collider.gameObject == obj)
        {
            result = true;
        }
        return result;
    }
}
