using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;


public class WinController : MonoBehaviour
{
    public Object kaya;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Kaya"))
        {
            Debug.Log("Winning...");
            WinText.setWinText();
            PlayerMove.win = true;
            kaya.GetComponent<PlayerMove>().kayaAnim.SetBool("win", true);
        }
    }
}
