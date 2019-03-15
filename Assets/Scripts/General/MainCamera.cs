using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * 5f);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, target.localRotation, Time.deltaTime * 5f);
	}
}
