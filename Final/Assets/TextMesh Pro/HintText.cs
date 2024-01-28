using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HintText : MonoBehaviour
{
    public Object kaya;
    TextMeshProUGUI hintText;

    void Start()
    {
        kaya.GetComponent<PlayerMove>();
        hintText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (!kaya.GetComponent<PlayerMove>().isStaffPickedUp)
        {
            hintText.text = "try to find magic staff (using tab button)";
        }
        else if (PlayerMove.win)
        {
            hintText.text = "";
        }
        else
        {
            hintText.text = "use platforms to climb to the scared tree";
        }
    }

}
