using UnityEngine;

public class WeaponInteraction : MonoBehaviour
{
    public GameObject parabolicWeaponPrefab;
    public GameObject orbitWeaponPrefab;
    public GameObject kineticWeaponPrefab;
    public Transform weaponParent; // Referencia al objeto PositionHand como el padre del arma
    public LayerMask groundLayer; // Capa del suelo

    private GameObject currentWeaponInstance;
    private WeaponController currentWeaponController;
    private bool canPickupWeapon = true; // Variable para controlar si se puede recoger un arma

    public float throwForce = 10f; // Fuerza de lanzamiento del arma

    private bool isFiring = false; // Variable para controlar si se está disparando actualmente

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el jugador entra en contacto con un arma en el suelo y si puede recoger un arma
        if (other.CompareTag("Weapon") && canPickupWeapon)
        {
            // Obtener el tipo de arma desde el objeto en el suelo
            WeaponType weaponType = other.GetComponent<WeaponController>().weaponType;

            // Instanciar el prefab del arma correspondiente
            GameObject weaponPrefab = GetWeaponPrefab(weaponType);
            currentWeaponInstance = Instantiate(weaponPrefab);

            // Establecer el padre del arma como el objeto PositionHand
            currentWeaponInstance.transform.parent = weaponParent;

            // Establecer la posición y rotación local del arma para que coincida con el objeto PositionHand
            currentWeaponInstance.transform.localPosition = Vector3.zero;
            currentWeaponInstance.transform.localRotation = Quaternion.identity;

            currentWeaponController = currentWeaponInstance.GetComponent<WeaponController>();

            // Configurar los valores personalizables del arma
            WeaponData weaponData = ScriptableObject.CreateInstance<WeaponData>();
            weaponData.weaponType = weaponType;

            currentWeaponController.SetWeaponData(weaponData);

            // Desactivar el objeto del arma en el suelo
            other.gameObject.SetActive(false);

            // Desactivar la capacidad de recoger más armas hasta que se suelte el arma actual
            canPickupWeapon = false;
        }
    }

    private void Update()
    {
        // Lógica para soltar el arma
        if (currentWeaponInstance != null && Input.GetKeyDown(KeyCode.G))
        {
            // Desactivar el arma en la mano del jugador
            currentWeaponInstance.transform.parent = null;

            // Obtener el script del arma
            WeaponController weaponController = currentWeaponInstance.GetComponent<WeaponController>();

            // Invocar el método para lanzar el arma con la fuerza deseada
            weaponController.ThrowWeapon(throwForce);

            // Permitir que el jugador pueda recoger un arma nuevamente
            canPickupWeapon = true;

            // Limpiar la referencia al arma actual
            currentWeaponInstance = null;
            currentWeaponController = null;
        }

        // Lógica para disparar
        if (currentWeaponController != null && currentWeaponInstance.transform.parent != null && Input.GetMouseButton(0) && !isFiring && !canPickupWeapon)
        {
            // Iniciar el disparo
            isFiring = true;

            // Llamar al método de disparo del arma actual
            currentWeaponController.Fire();
        }

        // Lógica para detener el disparo
        if (currentWeaponController != null && Input.GetMouseButtonUp(0))
        {
            // Detener el disparo
            isFiring = false;
        }
    }

    private GameObject GetWeaponPrefab(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.Parabolic:
                return parabolicWeaponPrefab;
            case WeaponType.Orbit:
                return orbitWeaponPrefab;
            case WeaponType.Kinetic:
                return kineticWeaponPrefab;
            default:
                return null;
        }
    }
}