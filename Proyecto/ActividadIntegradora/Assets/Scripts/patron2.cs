using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class patron2 : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform bulletSpawnPoint; // El punto desde donde se disparan las balas
    public TextMeshProUGUI contadorTexto; 

    public float bulletSpeed = 5f; // La velocidad a la que se moveran las balas
    public float fireRate = 0.1f; // La frecuencia con la que se disparan las balas
    public float rotationSpeed = 5f; // La velocidad a la que gira el disparador

    private float currentAngle = 0f; // El angulo actual de disparo

    void Start()
    {
      
        InvokeRepeating("DispararEspiral", 0f, fireRate);
    }

    void DispararEspiral()
    {
        // Crear la bala en la posicion del spawn point
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // Añadirle una rotacion extra para que forme el espiral
        bullet.transform.Rotate(0f, currentAngle, 0f);

        // Añadirle velocidad a la bala en la direccion hacia adelante
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.contadorTexto = contadorTexto;
        }

        // Incrementar el angulo para que el proximo disparo este un poco mas girado
        currentAngle += rotationSpeed;

    }
}
