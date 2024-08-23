using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContadorBalas : MonoBehaviour
{
    public TextMeshProUGUI contadorTexto;
    private int cuenta = 0; // contador balas activos

    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    public void Incrementar()
    {
        cuenta++;
        UpdateText();
    }

    public void Disminuir(){
        cuenta--;
        UpdateText();
    }

    private void UpdateText()
    {
        contadorTexto.text = "Balas: " + cuenta.ToString();
    }
}
