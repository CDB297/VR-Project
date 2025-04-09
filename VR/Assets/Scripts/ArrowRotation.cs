using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    private void FixedUpdate()
    {
        transform.forward =
            Vector3.Slerp(transform.forward, rb.velocity.normalized, Time.fixedDeltaTime);
    }
}
