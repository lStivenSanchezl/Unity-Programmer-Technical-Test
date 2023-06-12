using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button1Animation : MonoBehaviour
{
    public Animator animator;
    private int playAnimation1Hash;
    public AnimationController animationController;

    private void Start()
    {
        playAnimation1Hash = Animator.StringToHash("PlayAnimation1");
    }

    public void PlayAnimation1()
    {
        animationController.StopAnimations();
        animator.SetBool(playAnimation1Hash, true);
        animator.SetBool("PlayAnimation2", false);
        animator.SetBool("PlayAnimation3", false);
    }
}

