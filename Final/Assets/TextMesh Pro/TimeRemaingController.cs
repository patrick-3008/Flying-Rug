using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TimeRemaingController : MonoBehaviour
{
    public Object kaya;
    private TextMeshProUGUI timeRemaining;

    void Start()
    {
        timeRemaining = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        timeRemaining.text = kaya.GetComponent<PlayerMove>().timeRemaining.ToString("f2");
    }
}
