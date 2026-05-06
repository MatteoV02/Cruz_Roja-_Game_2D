using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerMoveAnim();
    }

    void PlayerMoveAnim()
    {
        bool isMoving = Mathf.Abs(_rb.velocity.x) > 0.1f;
        _animator.SetBool("IsMoving", isMoving);
    }
}