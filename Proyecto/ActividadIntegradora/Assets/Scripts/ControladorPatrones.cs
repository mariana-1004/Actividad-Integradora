using System.Collections;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ControladorPatrones : MonoBehaviour
{
    public Jefe jefeScript;          
    public patron2 patron2Script;    
    public patron3 patron3Script;    

    void Start()
    {
        jefeScript.enabled = false;
        patron2Script.enabled = false;
        patron3Script.enabled = false;

        StartCoroutine(EjecutarPatrones());
    }

    IEnumerator EjecutarPatrones()
    {
        
        jefeScript.enabled = true;
        yield return new WaitForSeconds(10f);
        jefeScript.enabled = false;

        patron2Script.enabled = true;
        yield return new WaitForSeconds(10f);
        patron2Script.enabled = false;


        patron3Script.enabled = true;
        yield return new WaitForSeconds(10f);
        patron3Script.enabled = false;


    }
}



