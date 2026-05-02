using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise : MonoBehaviour
{
    // Creacion de variables
    [Header("Numbers")]
    public int a;
    public int b;
    private int _result;

    // Start is called before the first frame update
    void Start()
    {
        AddNumber();
    }

    // Metodo para la suma
    public void AddNumber()
    {
        _result = a + b;
        Debug.Log("El resultado es: "+ _result );
        Debug.Log(string.Format("La suma entre {0} y {1} es {2}", a, b, _result));

        
    }
}
