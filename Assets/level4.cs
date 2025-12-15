using UnityEngine;
using UnityEngine.UI;

public class level4 : MonoBehaviour
{
    // Input values
    private bool inputA = false;
    private bool inputB = false;
    private bool inputC = false;
    private bool inputD = false;
    private bool inputE = false;
    private bool inputF = false;
    private bool inputG = false;
    private bool inputH = false;

    // UI References
    public Text inputAText;
    public Text inputBText;
    public Text inputCText;
    public Text inputDText;
    public Text inputEText;
    public Text inputFText;
    public Text inputGText;
    public Text inputHText;
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
    public void ToggleInputE()
    {
        inputE = !inputE;
        if (inputEText != null) inputEText.text = inputE ? "1" : "0";
    }
    public void ToggleInputF()
    {
        inputF = !inputF;
        if (inputFText != null) inputFText.text = inputF ? "1" : "0";
    }
    public void ToggleInputG()
    {
        inputG = !inputG;
        if (inputGText != null) inputGText.text = inputG ? "1" : "0";
    }
    public void ToggleInputH()
    {
        inputH = !inputH;
        if (inputHText != null) inputHText.text = inputH ? "1" : "0";
    }

    void CheckCircuit()
    {
        // Stage 1: Four parallel gates
        bool notA = !inputA;                // NOT gate on input A
        bool andBC = inputB && inputC;      // AND gate on inputs B & C
        bool orDE = inputD || inputE;       // OR gate on inputs D & E

        // XOR gate on inputs F, G, H (3-input XOR: true if odd number of true inputs)
        bool xorFGH = inputF != inputG != inputH;

        // Stage 2: Combine pairs
        bool andStage2 = notA && andBC;     // AND of NOT and AND outputs
        bool orStage2 = orDE || xorFGH;     // OR of OR and XOR outputs

        // Stage 3: Final XOR
        bool finalOutput = andStage2 != orStage2;  // XOR of Stage 2 outputs

        // The ONE correct combination that makes finalOutput = TRUE:
        // A=0, B=1, C=1, D=1, E=0, F=1, G=0, H=0

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
        }

        Debug.Log($"Circuit: A={inputA}, B={inputB}, C={inputC}, D={inputD}, E={inputE}, F={inputF}, G={inputG}, H={inputH}, Result={finalOutput}");
    }

    void GoToNextLevel()
    {
        Debug.Log("Next Level button clicked!");
        // Add your level switching logic here
        // Example: SceneManager.LoadScene("Level2");
    }
}