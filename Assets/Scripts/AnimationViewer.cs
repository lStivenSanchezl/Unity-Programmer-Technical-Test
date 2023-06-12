using UnityEngine;
using UnityEngine.UI;

public class AnimationViewer : MonoBehaviour
{
    public Camera secondaryCamera;
    public RawImage rawImage;
    public Animator secondaryModelAnimator;

    private void Start()
    {
        RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        secondaryCamera.targetTexture = renderTexture;
        rawImage.texture = renderTexture;

        PlaySelectedAnimation();
    }

    private void PlaySelectedAnimation()
    {
        AnimationController animationController = FindObjectOfType<AnimationController>();
        string selectedAnimation = animationController.GetSelectedAnimation();
        secondaryModelAnimator.Play(selectedAnimation);
    }
}
