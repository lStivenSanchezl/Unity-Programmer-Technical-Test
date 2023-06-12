using UnityEngine;
using UnityEngine.UI;

public class AnimationSelectionButton : MonoBehaviour
{
    public MoveObjectToDestination moveObjectScript;

    public void OnClick()
    {
        moveObjectScript.MoveObjectToNextScene();
    }
}