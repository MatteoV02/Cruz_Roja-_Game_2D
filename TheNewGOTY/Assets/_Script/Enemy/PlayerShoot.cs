using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    private Animator _animator;
    public GameObject bulletPrefab;
    public Transform startPos;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void Shoot(InputAction.CallbackContext context)
    {
        if(context.started)
        {   
            _animator.SetTrigger("Attack");
            
        }
    }

    public void PanAttack()
    {
        GameObject bullet = Instantiate(bulletPrefab, startPos.position, startPos.rotation);
        Destroy(bullet, 1f);
    }

}
