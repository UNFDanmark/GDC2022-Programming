using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PointHandlerScript : MonoBehaviour
{
    public int killCount = 0;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        
    }

    public void RegisterKill()
    {
        killCount = killCount + 1;
        scoreText.text = "Bananer samlet " + killCount;
    }
}
