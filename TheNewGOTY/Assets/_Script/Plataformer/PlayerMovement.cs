using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public NewInput _newInput;
    public float speedx;
    public float speedy;
    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        PlayerStats.score = 0;
        _newInput = GetComponent<NewInput>();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        //transform.Translate(Vector3.right * speedx * _newInput.inputX * Time.deltaTime);
        _rb.velocity = new Vector2(_newInput.inputX * speedx, _rb.velocity.y);
        Flip();
    }

    public void Flip()
    {
        if (_newInput.inputX > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }else if (_newInput.inputX < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
