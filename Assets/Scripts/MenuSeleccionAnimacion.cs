using UnityEngine;
using UnityEngine.UI;

public class MenuSeleccionAnimacion : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;

    private void Start()
    {
        button1.onClick.AddListener(() => AnimationSelected("House Dancing"));
        button2.onClick.AddListener(() => AnimationSelected("Macarena Dance"));
        button3.onClick.AddListener(() => AnimationSelected("Wave Hip Hop Dance"));
    }

    private void AnimationSelected(string animationName)
    {
        AnimationClip animationClip = GameManager.Instance.animaciones.Find(clip => clip.name == animationName);
        if (animationClip != null)
        {
            GameManager.Instance.SetSelectedAnimation(animationClip);
        }
        else
        {
            Debug.LogError("Animation clip not found: " + animationName);
        }
    }
}