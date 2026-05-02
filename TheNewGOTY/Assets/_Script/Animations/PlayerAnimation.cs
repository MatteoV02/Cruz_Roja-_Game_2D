using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private NewInput _newInput;
    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _newInput = GetComponent<NewInput>();
        _rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveAnim();
    }

    public void PlayerMoveAnim()
    {
        _animator.SetBool("IsMoving", _newInput.inputX != 0);
    }
    
}
