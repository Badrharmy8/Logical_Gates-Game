using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class nextlevel : MonoBehaviour
{
    public Button nextButton;

    void Start()
    {
        // Hide button at start
        if (nextButton != null)
        {
            nextButton.gameObject.SetActive(false);
            nextButton.onClick.AddListener(GoToNextLevel);
        }
    }

    // Call this when circuit is correct
    public void ShowNextButton()
    {
        if (nextButton != null)
            nextButton.gameObject.SetActive(true);
    }

    void GoToNextLevel()
    {
        // Load next scene in build order
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
