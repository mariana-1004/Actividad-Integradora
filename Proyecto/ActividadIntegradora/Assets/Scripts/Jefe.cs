using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Jefe : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public TextMeshProUGUI contadorTexto; 

    public float bulletSpeed = 10f;
    public float fireRate = 1f; // Tiempo entre cada ráfaga de disparos


    void Start()
    {
        InvokeRepeating("FireInAllDirections", 0f, fireRate);
    }

    void FireInAllDirections()
    {
        // Direcciones de disparo
        Vector3[] directions = new Vector3[]
        {
            bulletSpawnPoint.forward,    // Adelante
            -bulletSpawnPoint.forward,   // Atrás
            bulletSpawnPoint.right,      // Derecha
            -bulletSpawnPoint.right      // Izquierda
        };

        foreach (Vector3 direction in directions)
        {
            FireBullet(direction);
        }
    }

    void FireBullet(Vector3 direction)
    {
        // Instancia la bala y aplica la rotación correspondiente
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = direction * bulletSpeed;
        }

        // Asegura que las balas estén en capas diferentes para evitar colisiones
        bullet.layer = LayerMask.NameToLayer("Bullet");

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.contadorTexto = contadorTexto;
        }
    }
}