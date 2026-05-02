using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangecolorandPose : MonoBehaviour
{
    [Header("Cambio de Posicion")]
    public   GameObject nuevelados;
    private SpriteRenderer _renderer;
    private string positionn;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        ChangeColor();
        ChangePos();
        Debug.Log(string.Format("La posición del diamante es {0} y su color es verde", positionn));
    }

    // Update is called once per frame
    public void ChangeColor()
    {
        _renderer.color = Color.green;
    }

    public void ChangePos()
    {
        transform.position = nuevelados.transform.position;
        positionn = transform.position.ToString();

    }
}
