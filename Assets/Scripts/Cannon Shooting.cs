using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonShooting : MonoBehaviour
{
    public Slider rotationYSlider;  // Slider para rotar el cañón en Y (horizontal)
    public Slider rotationXSlider;  // Slider para rotar el cañón en X (vertical)
    public Slider powerSlider;      // Slider para controlar la potencia del disparo

    [SerializeField] Rigidbody projectilePrefab;
    [SerializeField] Transform firePoint;

    private float attackSpeed = 1f;
    private float nextAttackTime;

    private void Update()
    {
        Rotation();
        if (Input.GetButtonDown("Jump") && Time.time >= nextAttackTime)
        {
            Fire();
            nextAttackTime = Time.time + 1f / attackSpeed;
        }
    }
    public void Rotation()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, rotationYSlider.value, transform.rotation.eulerAngles.z);
        transform.rotation = Quaternion.Euler(-rotationXSlider.value, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
    public void Fire()
    {
        // Instanciar el proyectil y aplicar fuerza
        Rigidbody projectileInstance = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        projectileInstance.AddForce(firePoint.forward * powerSlider.value, ForceMode.Impulse);
    }
}
