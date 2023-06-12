using UnityEngine;

public class AnimationReceiver : MonoBehaviour
{
    public Animator targetAnimator; // Referencia al Animator en la escena de destino

    public void ReceiveAnimationClip(string animationClipName)
    {
        // Obtener la animaci�n correspondiente al nombre recibido
        AnimationClip animationClip = GameManager.Instance.animaciones.Find(clip => clip.name == animationClipName);
        if (animationClip != null)
        {
            // Reproducir la animaci�n en el Animator de la escena de destino
            targetAnimator.Play(animationClip.name);
        }
        else
        {
            Debug.LogError("Animation clip not found: " + animationClipName);
        }
    }
}