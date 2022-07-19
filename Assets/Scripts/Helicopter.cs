using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    [SerializeField] private AudioClip callSound;
    private bool heliCalled = false;
    private AudioSource _audioSource;
    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Call()
    {
        if (!heliCalled)
        {
            heliCalled = true;
            Debug.Log("Helicopter Called");
            _audioSource.clip = callSound;
            _audioSource.Play();
            _rigidbody.velocity = new Vector3(0, 0, 50);
        }
    }
}
