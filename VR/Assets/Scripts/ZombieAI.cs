using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ZombieAI : MonoBehaviour
{
    public GameObject Target;
    public float speed = 1.5f;

    void Start()
    {

    }

    void Update()
    {
        transform.LookAt(transform.gameObject.transform);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
