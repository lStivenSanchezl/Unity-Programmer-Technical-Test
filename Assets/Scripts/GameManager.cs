using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance; // Instancia única del GameManager
    public List<AnimationClip> animaciones; // Lista de animaciones disponibles
    private AnimationClip selectedAnimation; // Animación seleccionada

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null) // Verifica si no hay una instancia previa del GameManager
        {
            instance = this; // Establece la instancia única del GameManager
            DontDestroyOnLoad(gameObject); // No destruye este objeto al cambiar de escena
        }
        else
        {
            Destroy(gameObject); // Destruye este objeto si ya hay una instancia previa del GameManager
        }
    }

    public void SetSelectedAnimation(AnimationClip animation)
    {
        selectedAnimation = animation; // Establece la animación seleccionada
    }

    public AnimationClip GetSelectedAnimation()
    {
        return selectedAnimation; // Devuelve la animación seleccionada
    }
}

