using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameControl : MonoBehaviour
{
    static public int unlockedLevels;
    //static int unlockedLevels;// = PlayerPrefs.GetInt("unlockedLevels", 0);
    static public int currentLevel;
    static private int unObjects;
    static private int ObjectAt;

    public Button[] buttonsMenu;
    public Button[] buttonObjects;

    [SerializeField]
    private bool gameRunning;
    private bool gameClose;

    public GameObject menuPaused, gameBoolClosed;
    //GameObject objeto;
   private void Start() {
        //objeto = GameObject.FindGameObjectWithTag("findObject");

        menuPaused.SetActive(false);
        gameBoolClosed.SetActive(false);

        unlockedLevels = PlayerPrefs.GetInt("unlockedLevels"); //Leer
        currentLevel = PlayerPrefs.GetInt("currentLevel"); //Leer
        if (SceneManager.GetActiveScene().name == "SwipeMenu") {
            updateButtons();
        }

        if (SceneManager.GetActiveScene().name == "Level_1"){
            //updateObjects();
        }

        //int objetos = PlayerPrefs.GetInt("objetos", 2);
        /*for (int i = 0; i < buttonObjects.Length; i++) {
            if(i+2 > objetos){
                buttonObjects[i].interactable = false;
            }
        }*/

    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)){
            changeGameRunningState();
        }
    }

    public void reset() {
        PlayerPrefs.DeleteAll();
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
        PlayerPrefs.SetInt("unlockedLevels", unlockedLevels); //Grabar
        PlayerPrefs.SetInt("currentLevel", currentLevel); //Grabar
        if (unlockedLevels < currentLevel){
            unlockedLevels = currentLevel;
            currentLevel++;
        }

        backMenu();
    }

    public static void unlockedObjects() {
        if (unObjects < ObjectAt) {
            unObjects = ObjectAt;
            ObjectAt++;
        }
    }
    
    //Revisar funcion
   /* public void updateObjects()  {
        for (int i = 0; i < unObjects + 1; i++) {
            buttonObjects [i].interactable = true;
        }
    }*/  

    public void destroyObject(GameObject objeto) {
        if(objeto.gameObject.tag == "findObject") {
            Destroy(objeto.gameObject, (float) 1f);
            //Destroy(this.gameObject, (float)3);
            GameObject[] objetos = GameObject.FindGameObjectsWithTag("findObject"); 
        }

    }

    static void backMenu() {
        changeLevel(0);
    }

    public void updateButtons() {
        for (int i = 0; i < unlockedLevels + 1; i++)
        {
            buttonsMenu[i].interactable = true;
        }
    }
    public void changeGameRunningState()
    {
        gameRunning = !gameRunning;
        if (gameRunning) {
            //Game is Running
            Debug.Log("Game Running");
            Time.timeScale = 1f;
            btnPause();
        } else {
            //Game is Paused
            Debug.Log("Game Paused");
            Time.timeScale = 0f;
            btnResume();
        }
    }

    void btnResume(){
        menuPaused.SetActive(false);
        Time.timeScale = 1f;
        gameClose = false;
    }

    void btnPause(){
        menuPaused.SetActive(true);
        Time.timeScale = 0f;
        gameClose = true;
    }

    public void panelCloseGame() {
        gameBoolClosed.SetActive(true);
    }

    public void salirPanelNo() {
        gameBoolClosed.SetActive(false);
    }

    public void salirPanelSi() {
        Debug.Log("Se ha salido del juego");
        Application.Quit();
    }

    public bool isGameRunning(){
        return gameRunning;
    }

}
