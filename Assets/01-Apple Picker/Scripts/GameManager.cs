using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI currentScoreText;

    private int _currentScore;
    public int highScore;
    public int CurrentScore{
        get{
            return _currentScore;
        }
        set{
            _currentScore = value;
            if (_currentScore > highScore)
            {
                highScore = _currentScore;
                UpdateScores();
            }
        }
    }
    

    public static GameManager Instance {get; private set;}
    public bool gameRunning;
    // Start is called before the first frame update
    private void Awake() {
        if (Instance != null && Instance != this) 
    { 
        Destroy(this); 
    } 
    else 
    { 
        Instance = this; 
    }

    gameRunning = true;

    }   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScores(){
        currentScoreText.text = "Current score: "+CurrentScore;
        highScoreText.text = "High score: "+highScore;
    }
}
