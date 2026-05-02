using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb;
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Metodo Saltar
    public void Jump()
    {
        if (Mathf.Abs(_rb.velocity.y) < 0.03)
        {
            _animator.SetTrigger("Jump");
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            AudioManager.instance.PlayJump();
        }
    }
}
