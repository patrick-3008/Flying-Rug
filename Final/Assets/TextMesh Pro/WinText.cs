using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WinText : MonoBehaviour
{
    static TextMeshProUGUI winText;

    void Start()
    {
        winText = GetComponent<TextMeshProUGUI>();
        winText.text = "";
    }


    public static void setWinText()
    {
        winText.text = "Mission Completed !";
    }
}
