using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapController : MonoBehaviour
{
    public Transform kaya;

    void Update()
    {
        Vector3 newPosition = kaya.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90.0f, kaya.eulerAngles.y, 0.0f);
    }
}
