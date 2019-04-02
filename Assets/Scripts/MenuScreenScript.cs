using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class MenuScreenScript : MonoBehaviour
{
    public Button New_Game,Load, Quit;
    public GameObject Video, CoolText, Canvas_Text, Canvas_Load;
    public Image slider;
    public Text text;
    private VideoPlayer player;
    public Loader_Saver loader;
    // Start is called before the first frame update
    private void Awake()
    {
        //loader = (new GameObject("puk")).AddComponent<Loader_Saver>();
        //loader.canvas = GameObject.Find("Load canvas");      //  File.CreateText(Path.Combine(Application.persistentDataPath, "КТО ПРОЧИТАЕТ.TOT ZDOXNET"));
    }
    void Start()
    {
        player = Video.GetComponent<VideoPlayer>();
        Canvas_Load.SetActive(false);
        text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Close()
    {
        print("Closing");
        Application.Quit();
    }
    public void StartNextLevel()
    {
        print("Starting next Level");

     loader.Load(1);

    }
    public void load()
    {
     loader.Load(-1);
    }

    //IEnumerator BackLoading()
    //{
    //    CoolText.SetActive(false);
    //    Canvas_Text.SetActive(false);
    //    Canvas_Load.SetActive(true);
    //    slider.fillAmount = 0;
    //    Scene scene = SceneManager.GetSceneByBuildIndex(1);
    //AsyncOperation operation=    SceneManager.LoadSceneAsync(1);
    //    operation.allowSceneActivation = false;
    //    while (!operation.isDone)
    //    {
    //        slider.fillAmount += operation.progress/100;

    //        Debug.Log("puk");
    //        if (operation.progress >= 0.9f)
    //        {
    //            text.enabled = true;
    //            if (Input.GetKeyDown(KeyCode.Space))
    //            {
    //                operation.allowSceneActivation = true;
    //            }
    //        }
    //        yield return null;
    //    }
    //}
}
