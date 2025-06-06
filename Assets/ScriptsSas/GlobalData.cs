using System;
using TMPro;
using UnityEngine;

public class GlobalData : MonoBehaviour
{

    public static GlobalData dataInstance;

    [SerializeField] TextMeshProUGUI currentTime;
    public DateTime dateTime = new DateTime(523, 6, 1, 7, 00, 00);

    private void Start()
    {
        currentTime.text = dateTime.ToString();
    }

    public void changeTime(int time)
    {
        //Debug.Log("Changing time");
        dateTime = dateTime.AddSeconds(time);
        currentTime.text = dateTime.ToString();
    }
}
