using UnityEngine;
using UnityEngine.UI;

public class logicall : MonoBehaviour
{
    // Input values
    private bool inputA = false;
    private bool inputB = false;
    private bool inputC = false;
    private bool inputD = false;

    // UI References
    public Text inputAText;
    public Text inputBText;
    public Text inputCText;
    public Text inputDText;
    public Button submitButton;
    public Button nextButton;
    public GameObject laptopRecharged;
    public GameObject laptopDead;

    void Start()
    {
        // Setup submit button


        submitButton.onClick.AddListener(CheckCircuit);
    }

    public void ToggleInputA()
    {
        inputA = !inputA;
        if (inputAText != null) inputAText.text = inputA ? "1" : "0";
       // ResetCircuit();
    }

    public void ToggleInputB()
    {
        inputB = !inputB;
        if (inputBText != null) inputBText.text = inputB ? "1" : "0";
       // ResetCircuit();
    }

    public void ToggleInputC()
    {
        inputC = !inputC;
        if (inputCText != null) inputCText.text = inputC ? "1" : "0";
       // ResetCircuit();
    }

    public void ToggleInputD()
    {
        inputD = !inputD;
        if (inputDText != null) inputDText.text = inputD ? "1" : "0";
        //ResetCircuit();
    }

    

  /*  void ResetCircuit()
    {
        if (laptopRecharged != null) laptopRecharged.SetActive(false);
        if (laptopDead != null) laptopDead.SetActive(true);
        if (nextButton != null) nextButton.gameObject.SetActive(false);
    }*/

    void CheckCircuit()
    {
        // Circuit logic: [(A AND B) OR (NOT C)] XOR D
        bool andResult = inputA && inputB;
        bool notCResult = !inputC;
        bool orResult = andResult || notCResult;
        bool finalOutput = orResult != inputD; // XOR

        if (finalOutput)
        {
            if (laptopRecharged != null) laptopRecharged.SetActive(true);
            if (laptopDead != null) laptopDead.SetActive(false);
            if (nextButton != null) nextButton.gameObject.SetActive(true);
            FindObjectOfType<nextlevel>().ShowNextButton();
        }
        else
        {
            if (laptopRecharged != null) laptopRecharged.SetActive(false);
            if (laptopDead != null) laptopDead.SetActive(true);
            if (nextButton != null) nextButton.gameObject.SetActive(false);

            live hearts = FindObjectOfType<live>();
            if (hearts != null)
            {
                hearts.LoseLife();
            }
        }

        Debug.Log($"Circuit: A={inputA}, B={inputB}, C={inputC}, D={inputD}, Result={finalOutput}");
    }

    void GoToNextLevel()
    {
        Debug.Log("Next Level button clicked!");
        // Add your level switching logic here
        // Example: SceneManager.LoadScene("Level2");
    }
}