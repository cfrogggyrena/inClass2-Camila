using System.Diagnostics;
using UnityEngine;
using TMPro;

public class IWasClicked : MonoBehaviour
{


    public TMP_Text buttonText;

    public void onClick()
    {
        UnityEngine.Debug.Log("I was clicked!");
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (buttonText != null)
        {

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
