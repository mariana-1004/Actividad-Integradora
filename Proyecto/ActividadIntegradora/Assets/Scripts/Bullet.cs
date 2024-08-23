using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{
    public TextMeshProUGUI contadorTexto;
    public int vel = 0;
    public float muerte = 15f;
    private ContadorBalas contadorBalas;
    public float tiempoDeVida = 0f; // Tiempo despues del cual la bala sera destruida

    void Start()
    {
        contadorBalas = FindObjectOfType<ContadorBalas>();
        contadorBalas.Incrementar();
    }

    void Update()
    {
        tiempoDeVida += Time.deltaTime;

        if (tiempoDeVida > muerte){
            contadorBalas.Disminuir();
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(Vector3.up * vel * Time.deltaTime);
        }

    }

}
