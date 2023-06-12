using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2Animation : MonoBehaviour
{
    public Animator animator;
    private int playAnimation2Hash;
    public AnimationController animationController;

    private void Start()
    {
        playAnimation2Hash = Animator.StringToHash("PlayAnimation2");
    }

    public void PlayAnimation2()
    {
        animationController.StopAnimations();
        animator.SetBool(playAnimation2Hash, true);
        animator.SetBool("PlayAnimation1", false);
        animator.SetBool("PlayAnimation3", false);
    }
}

