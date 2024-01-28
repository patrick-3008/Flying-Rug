using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class LookAtMagicStaff : MonoBehaviour
{
    public GameObject arrow;
    public Transform staffPoistion;
    public Object kaya;

    void Update()
    {
        transform.LookAt(staffPoistion);

        if (Input.GetKey(KeyCode.Tab) && !kaya.GetComponent<PlayerMove>().isStaffPickedUp)
            arrow.SetActive(true);
        else
            arrow.SetActive(false);
    }
}
