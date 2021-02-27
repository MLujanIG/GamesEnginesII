using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour
{
    public Text txtScore;
    int score = 0;
    gameControl GameControl;

    private void Awake(){
        GameControl = GameObject.Find("gameControl").GetComponent(typeof(gameControl)) as gameControl;
    }

    public void sumScore() 
    {
        score++;
        updateTxtScore();

        if (score >= 5){
            //gameControl.changeLevel(0);
        }
    }

    void updateTxtScore()
    {
        txtScore.text = "Objetos encontrados: " + score.ToString() + "/5";
    }
}
