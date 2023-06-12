using UnityEngine;

public class KineticProjectileController : MonoBehaviour
{
    public float projectileLifetime = 5f;
    public float amplitude = 1f; // Amplitud de las ondas
    public float frequency = 1f; // Frecuencia de las ondas
    public float forwardSpeed = 10f; // Velocidad hacia adelante

    private Rigidbody rb;
    private float initialPositionY;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, projectileLifetime);

        // Guardar la posición inicial en el eje Y
        initialPositionY = transform.position.y;

        // Aplicar una fuerza inicial hacia adelante
        rb.velocity = transform.forward * forwardSpeed;
    }

    private void FixedUpdate()
    {
        // Calcular la posición en el eje Y utilizando una función sinusoidal
        float newY = initialPositionY + amplitude * Mathf.Sin(Time.time * frequency);

        // Obtener la posición actual del proyectil
        Vector3 currentPosition = transform.position;

        // Calcular la nueva posición en el eje Y
        Vector3 newPosition = new Vector3(currentPosition.x, newY, currentPosition.z);

        // Calcular el desplazamiento hacia adelante
        Vector3 forwardMovement = transform.forward * forwardSpeed * Time.fixedDeltaTime;

        // Calcular la nueva posición completa
        Vector3 updatedPosition = newPosition + forwardMovement;

        // Actualizar la posición del proyectil
        rb.MovePosition(updatedPosition);
    }
}