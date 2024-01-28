using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using Unity.VisualScripting;

public class MagicStaffController : MonoBehaviour
{
    private int RockNumber;
    public Object kaya;

    public Light staffPonitLight;

    void Start()
    {
        RockNumber = Random.Range(1, 4);
        if (RockNumber == 1)
        {
            transform.position = new Vector3(370, 3, 60);
        }
        else if (RockNumber == 2)
        {
            transform.position = new Vector3(125, 2, 290);
        }
        else if (RockNumber == 3)
        {
            transform.position = new Vector3(270, 2, 370);
        }
        Debug.Log("Rock Number = " + RockNumber);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name.Contains("Kaya") && !kaya.GetComponent<PlayerMove>().isStaffPickedUp && Input.GetKeyDown(KeyCode.LeftControl))
        {
            kaya.GetComponent<PlayerMove>().kayaAnim.SetBool("readyToPickUp", true);
            kaya.GetComponent<PlayerMove>().isStaffPickedUp = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Kaya"))
            kaya.GetComponent<PlayerMove>().kayaAnim.SetBool("readyToPickUp", false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Terrain"))
            staffPonitLight.enabled = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name.Contains("Terrain"))
            staffPonitLight.enabled = true;
    }
}
