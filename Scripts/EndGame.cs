using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    
    public int numSpiders;

    public int winCondition;

    // Start is called before the first frame update
    void Start()
    {
        numSpiders = 0;
            
        // default win condition
        if (winCondition == 0)
        {
            winCondition = 10;
        }
    }

    private void Update()
    {
        if (numSpiders >= winCondition)
        {
            SceneManager.LoadScene("Endgame");
        }
    }


}
