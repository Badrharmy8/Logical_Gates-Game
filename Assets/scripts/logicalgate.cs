using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class logicalgate: MonoBehaviour  // MUST have this
{
    public string LevelSceneName = "from 1 to 2";
    // Input values
    private bool inputA = false;
    private bool inputB = false;
    

    // UI References
    public Text inputAText;
    public Text inputBText;
    public Button submitButton;
    public Button nextButton;
    // public Image feedbackIcon;  // Changed to Image for UI

    // Sprite assets
    public GameObject laptopRecharged;
    public GameObject laptopDead;

    void Start()  // MonoBehaviour method - needs inheritance
    {
        submitButton.onClick.AddListener(CheckCircuit);

        // Start invisible
       // feedbackIcon.color = new Color(1, 1, 1, 0);
    }

    public void ToggleInputA()
    {
        inputA = !inputA;
        inputAText.text = inputA ? "1" : "0";
    }

    public void ToggleInputB()
    {
        inputB = !inputB;
        inputBText.text = inputB ? "1" : "0";
    }
    



    void CheckCircuit()
    {      bool notA= !inputA ;
        // Change this logic for your circuit
        bool circuitOn = notA && inputB;

        if (circuitOn)
        {
            // laptopRecharged.SetActive(true);
            SceneManager.LoadScene(LevelSceneName);
            laptopDead.SetActive(false);
            // nextButton.gameObject.SetActive(true);

        }

        else
        {
            laptopDead.SetActive(true);
            live hearts = FindObjectOfType<live>();
            if (hearts != null)
            {
                hearts.LoseLife();
            }
            laptopRecharged.SetActive(false);
            nextButton.gameObject.SetActive(false);

        }

    }
}
