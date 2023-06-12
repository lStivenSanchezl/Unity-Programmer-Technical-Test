using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Custom/Weapon Data", order = 1)]
public class WeaponData : ScriptableObject
{
    public WeaponType weaponType; // Agrega la propiedad weaponType

    public float fireRate;
    public int damage;
    public float launchForce;

    public float orbitalAttractionRange; // Agrega la propiedad orbitalAttractionRange
    public float orbitalAttractionForce; // Agrega la propiedad orbitalAttractionForce

    // Agrega más propiedades según tus necesidades
}
