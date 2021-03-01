using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameControl : MonoBehaviour
{
     static public int unlockedLevels;
    static public int currentLevel;
     public Button[] buttonsMenu;

   private void Start() {
        if (SceneManager.GetActiveScene().name == "SwipeMenu") {
            updateButtons();
        }
    }
    public static void changeLevel(int level){
        if (level == 0){
            SceneManager.LoadScene("SwipeMenu");
        }
        else{
            SceneManager.LoadScene("Level_" + level);
        }
    }

    public static void unlockedLevel(){
        if (unlockedLevels < currentLevel){
            unlockedLevels = currentLevel;
            currentLevel++;
        }

        backMenu();
    }

     static void backMenu() {
        changeLevel(0);
    }

     public void updateButtons(){
        for (int i = 0; i < unlockedLevels+1; i++)
        {
            buttonsMenu[i].interactable = true;
        }
    }
}
