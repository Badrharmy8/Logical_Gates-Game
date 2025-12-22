using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class level3 : MonoBehaviour
{
    public string LevelSceneName = "from 3 to 4";
    // Input values
    private bool inputA = false;
    private bool inputB = false;
    private bool inputC = false;
    private bool inputD = false;
    private bool inputE = false;
    private bool inputF = false;

    // UI References
    public Text inputAText;
    public Text inputBText;
    public Text inputCText;
    public Text inputDText;
    public Text inputEText;
    public Text inputFText;
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

    /*  void ResetCircuit()
      {
          if (laptopRecharged != null) laptopRecharged.SetActive(false);
          if (laptopDead != null) laptopDead.SetActive(true);
          if (nextButton != null) nextButton.gameObject.SetActive(false);
      }*/

    void CheckCircuit()
    {
        // Left side: XOR( OR(A,B), NOT(C) )
        bool orAB = inputA || inputB;      // OR gate
        bool notC = !inputC;               // NOT gate
        bool xorLeft = orAB != notC;       // XOR gate

        // Right side: XOR( OR(D,E), NOT(F) )
        bool orDE = inputD || inputE;      // OR gate
        bool notF = !inputF;               // NOT gate
        bool xorRight = orDE != notF;      // XOR gate

        // Final: AND gate
        bool finalOutput = xorLeft && xorRight;  // AND gate


        if (finalOutput)
        {
            // if (laptopRecharged != null) laptopRecharged.SetActive(true);
            SceneManager.LoadScene(LevelSceneName);
            if (laptopDead != null) laptopDead.SetActive(false);
            // if (nextButton != null) nextButton.gameObject.SetActive(true);
            // FindObjectOfType<nextlevel>().ShowNextButton();
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