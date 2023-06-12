using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance; // Instancia �nica del GameManager
    public List<AnimationClip> animaciones; // Lista de animaciones disponibles
    private AnimationClip selectedAnimation; // Animaci�n seleccionada

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
            instance = this; // Establece la instancia �nica del GameManager
            DontDestroyOnLoad(gameObject); // No destruye este objeto al cambiar de escena
        }
        else
        {
            Destroy(gameObject); // Destruye este objeto si ya hay una instancia previa del GameManager
        }
    }

    public void SetSelectedAnimation(AnimationClip animation)
    {
        selectedAnimation = animation; // Establece la animaci�n seleccionada
    }

    public AnimationClip GetSelectedAnimation()
    {
        return selectedAnimation; // Devuelve la animaci�n seleccionada
    }
}

