using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BitColumn : MonoBehaviour
{
    public TMP_Text valueText;   
    public int bitValue;     

    private int currentValue = 0;

    public void Increase()
    {
        currentValue = 1;
        valueText.text = "1";
    }

    public void Decrease()
    {
        currentValue = 0;
        valueText.text = "0";
    }

    public int GetResult()
    {
        return currentValue * bitValue;
    }
}
