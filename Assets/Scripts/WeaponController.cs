using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public WeaponData weaponData; // Datos de la arma
    public WeaponType weaponType = WeaponType.None;

    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform projectileSpawnPoint; // Punto de spawn del proyectil
    public float launchForce; // Fuerza de lanzamiento del proyectil

    private bool canFire = true; // Variable para controlar si se puede disparar
    private bool isInHand = false; // Variable para controlar si el arma está en la mano del jugador


    public void SetWeaponData(WeaponData data)
    {
        weaponData = data;
        weaponType = data.weaponType;

        // Verificar si el arma está en la mano
        if (transform.parent != null)
        {
            isInHand = true;
        }
        else
        {
            isInHand = false;
        }
    }

    private void Update()
    {
        // Lógica para disparar al hacer clic con el mouse
        if (Input.GetMouseButtonDown(0) && canFire) // 0 representa el botón izquierdo del mouse
        {
            Fire();
        }
    }

    public void PickUpWeapon()
    {
        isInHand = true;
    }

    public void Fire()
    {
        // Verificar si se ha asignado un weaponData
        if (weaponData == null)
        {
            Debug.LogWarning("No se ha asignado un weaponData al arma.");
            return;
        }

        // Verificar si el arma está en la mano antes de permitir el disparo
        if (!isInHand)
        {
            Debug.Log("El arma no está en la mano. No se puede disparar.");
            return;
        }

        // Lógica de disparo de acuerdo al tipo de arma
        switch (weaponType)
        {
            case WeaponType.Parabolic:
                FireParabolic();
                break;
            case WeaponType.Orbit:
                FireOrbit();
                break;
            case WeaponType.Kinetic:
                FireKinetic();
                break;
        }
    }

    private void FireParabolic()
    {
        // Lógica de disparo parabólico
        Debug.Log("Disparo parabólico");

        // Instanciar el proyectil en el punto de spawn
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);

        // Obtener el Rigidbody del proyectil
        Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();

        // Aplicar una fuerza al proyectil para dispararlo
        projectileRigidbody.AddForce(projectileSpawnPoint.forward * launchForce, ForceMode.Impulse);

        // Desactivar la posibilidad de disparar durante un tiempo para evitar disparos rápidos
        canFire = false;
        StartCoroutine(EnableFireAfterDelay(0.5f)); // Permitir disparar nuevamente después de 0.5 segundos
    }



    private void FireOrbit()
    {
        // Lógica de disparo orbital
        Debug.Log("Disparo órbital");

        // Instanciar el proyectil en el punto de spawn
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);

        // Obtener el Rigidbody del proyectil
        Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();

        // Aplicar una fuerza al proyectil para dispararlo
        projectileRigidbody.AddForce(projectileSpawnPoint.forward * launchForce, ForceMode.Impulse);

        // Desactivar la posibilidad de disparar durante un tiempo para evitar disparos rápidos
        canFire = false;
        StartCoroutine(EnableFireAfterDelay(0.5f)); // Permitir disparar nuevamente después de 0.5 segundos
    }

    private void FireKinetic()
    {
        // Lógica de disparo cinético
        Debug.Log("Disparo cinético");

        // Instanciar el proyectil en el punto de spawn
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);

        // Obtener el Rigidbody del proyectil
        Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();

        // Aplicar una fuerza al proyectil para dispararlo
        projectileRigidbody.AddForce(projectileSpawnPoint.forward * launchForce, ForceMode.Impulse);

        // Desactivar la posibilidad de disparar durante un tiempo para evitar disparos rápidos
        canFire = false;
        StartCoroutine(EnableFireAfterDelay(0.5f)); // Permitir disparar nuevamente después de 0.5 segundos
    }

    private IEnumerator EnableFireAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canFire = true;
    }

    public void ThrowWeapon(float throwForce)
    {
        // Obtener el Rigidbody del arma
        Rigidbody weaponRigidbody = GetComponent<Rigidbody>();
        if (weaponRigidbody != null)
        {
            // Activar la gravedad del Rigidbody para que el arma caiga
            weaponRigidbody.useGravity = true;

            // Desactivar el kinematic para que la física afecte al arma
            weaponRigidbody.isKinematic = false;

            // Aplicar la fuerza al Rigidbody del arma
            weaponRigidbody.AddForce(transform.forward * throwForce, ForceMode.Impulse);

            isInHand = false;
        }
    }
}