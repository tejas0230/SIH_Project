using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOneUIMAnager : MonoBehaviour
{

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartTutorial", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartTutorial()
    {
        animator.SetBool("TutorialActive", true);
        GameManager.instance.CanPlayerMove = false;
        Invoke("StopTutorial", 3);
    }

    void StopTutorial()
    {
        animator.SetBool("TutorialActive", false);
        GameManager.instance.CanPlayerMove = true;
    }
}
