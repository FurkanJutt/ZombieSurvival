using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("IsRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.GetComponent<Player>())
        {
            _animator.SetTrigger("Attack");
        }
    }

    private void OnCollisionExit(Collision collider)
    {
        if (collider.gameObject.GetComponent<Player>())
        {
            _animator.SetBool("IsRunning", true);
        }
    }
}
