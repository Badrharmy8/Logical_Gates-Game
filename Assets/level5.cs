using UnityEngine;
using UnityEngine.UI;

public class level5 : MonoBehaviour
{
    // 10 Input values
    private bool inputA = false;
    private bool inputB = false;
    private bool inputC = false;
    private bool inputD = false;
    private bool inputE = false;
    private bool inputF = false;
    private bool inputG = false;
    private bool inputH = false;
    private bool inputI = false;
    private bool inputJ = false;

    // UI References
    public Text inputAText;
    public Text inputBText;
    public Text inputCText;
    public Text inputDText;
    public Text inputEText;
    public Text inputFText;
    public Text inputGText;
    public Text inputHText;
    public Text inputIText;
    public Text inputJText;

    public Button submitButton;
    public Button nextButton;
    public GameObject laptopRecharged;
    public GameObject laptopDead;

    void Start()
    {
        submitButton.onClick.AddListener(CheckCircuit);
    }

    // Toggle methods
    public void ToggleInputA() { inputA = !inputA; if (inputAText != null) inputAText.text = inputA ? "1" : "0"; }
    public void ToggleInputB() { inputB = !inputB; if (inputBText != null) inputBText.text = inputB ? "1" : "0"; }
    public void ToggleInputC() { inputC = !inputC; if (inputCText != null) inputCText.text = inputC ? "1" : "0"; }
    public void ToggleInputD() { inputD = !inputD; if (inputDText != null) inputDText.text = inputD ? "1" : "0"; }
    public void ToggleInputE() { inputE = !inputE; if (inputEText != null) inputEText.text = inputE ? "1" : "0"; }
    public void ToggleInputF() { inputF = !inputF; if (inputFText != null) inputFText.text = inputF ? "1" : "0"; }
    public void ToggleInputG() { inputG = !inputG; if (inputGText != null) inputGText.text = inputG ? "1" : "0"; }
    public void ToggleInputH() { inputH = !inputH; if (inputHText != null) inputHText.text = inputH ? "1" : "0"; }
    public void ToggleInputI() { inputI = !inputI; if (inputIText != null) inputIText.text = inputI ? "1" : "0"; }
    public void ToggleInputJ() { inputJ = !inputJ; if (inputJText != null) inputJText.text = inputJ ? "1" : "0"; }

    void CheckCircuit()
    {
        // STAGE 1: Each input used exactly once
        // A-J: All 10 inputs used in separate operations
        bool notA = !inputA;                // NOT on A
        bool andBC = inputB && inputC;      // AND on B & C
        bool orDE = inputD || inputE;       // OR on D & E
        bool xorFG = inputF != inputG;      // XOR on F & G
        bool notH = !inputH;                // NOT on H
        bool andIJ = inputI && inputJ;      // AND on I & J

        // STAGE 2: Combine outputs from Stage 1
        bool stage2_1 = notA && andBC;      // AND: NOT(A) AND (B AND C)
        bool stage2_2 = orDE != xorFG;      // XOR: (D OR E) XOR (F XOR G)
        bool stage2_3 = notH || andIJ;      // OR: NOT(H) OR (I AND J)

        // STAGE 3: Final combination
        bool finalOutput = (stage2_1 != stage2_2) && stage2_3;  // XOR then AND

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

        Debug.Log($"Circuit: A={inputA}, B={inputB}, C={inputC}, D={inputD}, E={inputE}, " +
                 $"F={inputF}, G={inputG}, H={inputH}, I={inputI}, J={inputJ}, Result={finalOutput}");
    }

    void GoToNextLevel()
    {
        Debug.Log("Next Level button clicked!");
        // SceneManager.LoadScene("NextLevel");
    }
}
