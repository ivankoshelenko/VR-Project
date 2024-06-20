using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using Unity.AI.Navigation;
public class CodePassword : MonoBehaviour
{
    private string code = "4725";
    public GameObject leftDoor;
    public GameObject rightDoor;

    public TextMeshProUGUI text;
    public GameObject codePanel;
    public GameObject successPanel;
    public void AddNumber(int number)
    {
        if (text.text.Length < 4)
        {
            text.text = text.text + number.ToString();
        }
        else 
        {
            text.text = "";
        }
    }
    public void CheckCode()
    {
        if (text.text == code)
        {
            leftDoor.SetActive(false);
            rightDoor.SetActive(false);
            successPanel.SetActive(true);
            codePanel.SetActive(false);
        }
        else
        {
            text.text = "";
        }
    }
}
