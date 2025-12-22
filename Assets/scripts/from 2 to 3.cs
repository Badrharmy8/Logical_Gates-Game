using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class from2to3 : MonoBehaviour
{
    public string LevelSceneName = "level3";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        SceneManager.LoadScene(LevelSceneName);
    }
}
