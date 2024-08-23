using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class patron3 : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform bulletSpawnPoint; // El punto desde donde se disparan las balas
    public TextMeshProUGUI contadorTexto; 

    public float bulletSpeed = 5f; // La velocidad a la que se moveran las balas
    public int bulletCount = 10; // Numero de balas que se dispararan en el circulo
    public float fireRate = 2f; // La frecuencia con la que se dispara el circulo de balas
   

    void Start()
    {
        InvokeRepeating("DispararCirculo", 0f, fireRate);
    }

    void DispararCirculo()
    {
        // Calcula el angulo entre cada bala en el circulo
        float angleStep = 360f / bulletCount;
        float angle = 0f;

        for (int i = 0; i < bulletCount; i++)
        {
            // Calcula la direccion en la que disparar basandose en el angulo actual
            float bulletDirX = bulletSpawnPoint.position.x + Mathf.Sin(angle * Mathf.Deg2Rad);
            float bulletDirZ = bulletSpawnPoint.position.z + Mathf.Cos(angle * Mathf.Deg2Rad);

            Vector3 bulletMoveDirection = new Vector3(bulletDirX, bulletSpawnPoint.position.y, bulletDirZ);
            Vector3 bulletDir = (bulletMoveDirection - bulletSpawnPoint.position).normalized;

            // Crear la bala en la posicion del spawn point
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            // Añadirle velocidad a la bala en la direccion calculada
            rb.velocity = bulletDir * bulletSpeed;

            Bullet bulletScript = bullet.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                bulletScript.contadorTexto = contadorTexto;
            }

            // Incrementar el angulo para el proximo disparo
            angle += angleStep;

        }
        
    }
}
