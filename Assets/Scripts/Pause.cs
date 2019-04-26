using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Pause : MonoBehaviour
{
  public  Canvas canv;
   public Button Restart, Quit;
 
    bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {

        Restart.onClick.AddListener(restart);
        Quit.onClick.AddListener(quit);
        canv.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        pauseGame();
        if (isPaused)
        {
            Cursor.visible = true;
        }
        else Cursor.visible = false;
    }

    void pauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            isPaused = true;
            Time.timeScale = 0f;
            
            Cursor.visible = true;
            canv.enabled = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            isPaused = false;
            Time.timeScale = 1f;
            Cursor.visible = false ;
            
            canv.enabled = false;
        }

    }
    void restart()
    {
        Scene scene =SceneManager.GetActiveScene();
       
   //    SceneManager.UnloadSceneAsync(scene.buildIndex);
        SceneManager.LoadScene(scene.buildIndex);
        Time.timeScale = 1f;
    }
    void quit()
    {
        Application.Quit();
    }
   
}
