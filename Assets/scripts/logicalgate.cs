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
    

    // Sprite assets
    public GameObject laptopRecharged;
    public GameObject laptopDead;

    void Start()  
    {
        submitButton.onClick.AddListener(CheckCircuit);

      
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
        
        bool circuitOn = notA && inputB;

        if (circuitOn)
        {
            
            SceneManager.LoadScene(LevelSceneName);
           // laptopDead.SetActive(false);


        }

        else
        {
            laptopDead.SetActive(true);
            live hearts = FindObjectOfType<live>();
            if (hearts != null)
            {
                hearts.LoseLife();
            }
          // laptopRecharged.SetActive(false);
           // nextButton.gameObject.SetActive(false);

        }

    }
}
