using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameControl : MonoBehaviour
{
   public void changeLevel(int level){
        if (level == 0){
            SceneManager.LoadScene("SwipeMenu");
        }
        else{
            SceneManager.LoadScene("Level_" + level);
        }
    }
}
