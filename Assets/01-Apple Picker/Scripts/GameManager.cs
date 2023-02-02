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
    public int _lives;
    public int Lives{
        get{
            return _lives;
        }
        set{
            _lives = value;
            switch (_lives)
            {
                case 2:
                    basket3.SetActive(false);
                    break;
                case 1:
                    basket2.SetActive(false);
                    break;
                case 0:
                    basket3.SetActive(true);
                    basket2.SetActive(true);
                    CurrentScore=0;
                    UpdateScores();
                    _lives = 3;
                    break;

            }
        }
    }
    public GameObject basket2;
    public GameObject basket3;
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
        UpdateScores();
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
