using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button3Animation : MonoBehaviour
{
    public Animator animator;
    private int playAnimation3Hash;
    public AnimationController animationController;

    private void Start()
    {
        playAnimation3Hash = Animator.StringToHash("PlayAnimation3");
    }

    public void PlayAnimation3()
    {
        animationController.StopAnimations();
        animator.SetBool(playAnimation3Hash, true);
        animator.SetBool("PlayAnimation1", false);
        animator.SetBool("PlayAnimation2", false);
    }
}

