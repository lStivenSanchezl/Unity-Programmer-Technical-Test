using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    private int playAnimation1Hash;
    private int playAnimation2Hash;
    private int playAnimation3Hash;
    private string selectedAnimation;

    private void Start()
    {
        playAnimation1Hash = Animator.StringToHash("PlayAnimation1");
        playAnimation2Hash = Animator.StringToHash("PlayAnimation2");
        playAnimation3Hash = Animator.StringToHash("PlayAnimation3");
    }

    public void StopAnimations()
    {
        animator.SetBool(playAnimation1Hash, false);
        animator.SetBool(playAnimation2Hash, false);
        animator.SetBool(playAnimation3Hash, false);
    }

    public void SetSelectedAnimation(string animationName)
    {
        selectedAnimation = animationName;
    }

    public string GetSelectedAnimation()
    {
        return selectedAnimation;
    }
}