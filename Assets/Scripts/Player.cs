using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Info Needed")]
    [SerializeField] private Transform playerSpawnPoints;
    //[SerializeField] private bool respawn = false;
    [SerializeField] private Helicopter helicopter;
    [SerializeField] private GameObject flarePrefab;

    [Header("SFX")]
    [SerializeField] private AudioClip whatHappend;
    [SerializeField] private AudioClip landingAreaFound;
    [SerializeField] private AudioClip callHeliSound;

    private Transform[] spawnPoints;
    //private bool lastToggle = false;
    private bool heliCalled = false;
    [HideInInspector] public bool areaFound = true;
    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = playerSpawnPoints.GetComponentsInChildren<Transform>();
        _audioSource = GetComponent<AudioSource>();
        Respawn();
        Invoke("CallWhatHappend", 1f);
    }

    private void CallWhatHappend()
    {
        _audioSource.clip = whatHappend;
        _audioSource.Play();
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    if (lastToggle != respawn)
    //    {
    //        Respawn();
    //        respawn = false;
    //    }
    //    else
    //    {
    //        lastToggle = respawn;
    //    }
    //}

    public void OnFindClearArea()
    {
        Debug.Log("ClearAreaFound");
        if (Input.GetButtonDown("callHeli") && !heliCalled)
        {
            heliCalled = true;
            _audioSource.clip = callHeliSound;
            _audioSource.Play();
            Invoke("callHelli", callHeliSound.length + 2f);
            Instantiate(flarePrefab, new Vector3(317f, 48.2f, 114f), Quaternion.identity);
        }
    }

    private void callHelli()
    {
        helicopter.Call();
    }

    public void PlayGoodAreaSound()
    {
        _audioSource.clip = landingAreaFound;
        _audioSource.Play();
    }

    private void Respawn()
    {
        int i = Random.Range(1, spawnPoints.Length);
        transform.position = spawnPoints[i].transform.position;
    }
}
