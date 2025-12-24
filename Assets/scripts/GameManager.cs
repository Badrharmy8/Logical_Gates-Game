using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text decimalText;
    public Text resultText;
    public BitColumn[] bits;
    public GameObject continue_but ;
    public GameObject level;
    public GameObject com;
    public GameObject pleted;


    private int targetNumber;

    void Start()
    {
        GenerateNumber();
    }

    void GenerateNumber()
    {
        targetNumber = Random.Range(1, 64); 
        decimalText.text = "Decimal: " + targetNumber;
    }

    public void CheckAnswer()
    {
        int sum = 0;

        foreach (BitColumn bit in bits)
        {
            sum += bit.GetResult();
        }

        if (sum == targetNumber)
        {
            resultText.text = " Correct!";
            continue_but.SetActive(true);
            level.SetActive(true);
            com.SetActive(true);
            pleted.SetActive(true);

        }
        else
        {
            resultText.text = " Wrong!";
        }
    }
}