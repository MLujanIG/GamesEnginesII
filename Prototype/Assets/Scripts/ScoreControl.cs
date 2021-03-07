using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreControl : MonoBehaviour
{
    public Text txtScore;
    int score = 0;
    public gameControl GameControl; //no tenía public ni private

    /*private void Awake()
    {
        GameControl = GameObject.Find("gameControl").GetComponent(typeof(gameControl)) as gameControl;
    }*/

    private void Start()
    {
        
    }

    public void sumScore() 
    {
        score++;
        updateTxtScore();

        if (score >= 6){
            gameControl.unlockedLevel();//changeLevel(0);
            gameControl.unlockedObjects();
        }
    }


    void updateTxtScore()
    {
        txtScore.text = "" + score.ToString() + "/5";
    }
}
