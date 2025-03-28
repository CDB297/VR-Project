using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockAndKey : MonoBehaviour
{
    public GameObject key;
    public GameObject door;
    bool doorOpened;

    AudioSource DoorOpen;
    AudioSource DoorClose;
    // Start is called before the first frame update
    void Start()
    {
        DoorOpen = GameObject.Find("DoorOpen").GetComponent<AudioSource>();
        DoorClose = GameObject.Find("DoorClose").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == key)
        {
            if (doorOpened == false)
            {
                door.SetActive(false);
                DoorOpen.Play();
                doorOpened = true;
            }
            else
            {
                door.SetActive(true);
                DoorClose.Play();
                doorOpened = false;
            }
        }
    }
}

