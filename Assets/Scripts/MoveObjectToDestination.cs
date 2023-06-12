using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveObjectToDestination : MonoBehaviour
{
    public GameObject objectToMove;
    public string destinationSceneName;

    public void MoveObjectToNextScene()
    {
        // Cargar la escena de destino de forma aditiva
        SceneManager.LoadScene(destinationSceneName, LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnDestinationSceneLoaded;
    }

    private void OnDestinationSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Obtener la referencia al objeto contenedor en la escena de destino
        GameObject destinationContainer = GameObject.Find("DestinationContainer");

        if (destinationContainer != null)
        {
            // Mover el objeto "ModeloBS" a la escena de destino y establecer su transformación
            objectToMove.transform.SetParent(destinationContainer.transform);
            objectToMove.transform.localPosition = new Vector3(435.3999938964844f, 42f, 0f);
            objectToMove.transform.localRotation = Quaternion.Euler(0f, 1f, 0f);
            objectToMove.transform.localScale = new Vector3(5f, 5f, 5f);

            // Descargar la escena actual
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        }
        else
        {
            Debug.LogError("Destination container not found in the destination scene: " + destinationSceneName);
        }

        // Desvincular el evento para evitar llamadas duplicadas
        SceneManager.sceneLoaded -= OnDestinationSceneLoaded;
    }
}

