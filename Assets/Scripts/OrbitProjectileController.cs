using UnityEngine;

public class OrbitProjectileController : MonoBehaviour
{
    public float projectileLifetime = 5f;
    public float attractionForce = 10f;
    public float attractionRadius = 5f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, projectileLifetime);
    }

    private void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, attractionRadius);
        foreach (Collider collider in colliders)
        {
            // Verificar si el objeto colisionado tiene un Rigidbody
            Rigidbody otherRigidbody = collider.GetComponent<Rigidbody>();
            if (otherRigidbody != null && otherRigidbody != rb)
            {
                // Calcular la dirección hacia el proyectil
                Vector3 directionToProjectile = transform.position - otherRigidbody.position;

                // Calcular la fuerza de atracción
                float distanceToProjectile = directionToProjectile.magnitude;
                float attractionStrength = attractionForce / distanceToProjectile;

                // Aplicar la fuerza al objeto para que orbite alrededor del proyectil
                otherRigidbody.AddForce(directionToProjectile.normalized * attractionStrength, ForceMode.Acceleration);
            }
        }
    }
}
