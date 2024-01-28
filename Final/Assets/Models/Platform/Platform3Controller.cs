using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class Platform3Controller : MonoBehaviour
{
    public Object Kaya;
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered Platform 3");
        if (other.gameObject.name.Contains("Kaya") && Kaya.GetComponent<PlayerMove>().isStaffPickedUp)
        {
            anim.SetBool("isKayaThere", true);
            other.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit Platform 3");
        anim.SetBool("isKayaThere", false);
        other.gameObject.transform.SetParent(null);
    }
}
