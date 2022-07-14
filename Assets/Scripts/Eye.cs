using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        Vector3 toTarget = target.position - transform.position;
        Vector3 toTargetXZ = new Vector3(toTarget.x, 0, toTarget.z);
        transform.rotation = Quaternion.LookRotation(toTarget);
    }
}
