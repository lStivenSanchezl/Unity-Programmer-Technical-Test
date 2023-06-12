using System.Collections;
using UnityEngine;

public class ParabolicProjectileController : MonoBehaviour
{
    public float projectileLifetime = 5f;
    public float launchForce = 10f; // Fuerza de lanzamiento hacia arriba

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, projectileLifetime);

        // Aplicar una fuerza inicial hacia arriba
        rb.AddForce(Vector3.up * launchForce, ForceMode.Impulse);
    }
}