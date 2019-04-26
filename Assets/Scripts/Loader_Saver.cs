using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loader_Saver : MonoBehaviour
{
    static public Loader_Saver instance;
    static string path;
    public LoadingCanvasScript canvas;
    public GameObject menuScreen;
    private void Awake()
    {
        print(Application.persistentDataPath);
        instance = this;
        path = Path.Combine(Application.persistentDataPath, "КТО ПРОЧИТАЕТ.TOT ZDOXNET");
    }
    public static void Save(Scene scene)
    {
        
        int level = scene.buildIndex;
        var jSonString = JsonUtility.ToJson(level);
      
        print(jSonString);
        using (StreamWriter writer = File.CreateText(path))
        {
            writer.Write(level);
        }
        print("Save succesfyll");
    }
    public void Load(int level)
    {
        print("Loading level");
        IEnumerator coroutine = loading(level);

        StartCoroutine(coroutine);
    }

    IEnumerator loading(int level)
    {
        AsyncOperation asyncOperation = null;
        int currentLevel = -1;


        if (File.Exists(path) && level == -1)
        {
            StreamReader reader = File.OpenText(path);
            //string jSonString = reader.ReadToEnd();
            //currentLevel = JsonUtility.FromJson<int>(jSonString)
            var levelString = reader.ReadToEnd();
            currentLevel = int.Parse(levelString);


            asyncOperation = SceneManager.LoadSceneAsync(currentLevel);
        }
        //else if (File.Exists(path) && level != -1)
        //{

        //}
        else
        {
            asyncOperation = SceneManager.LoadSceneAsync(1);
        }


        asyncOperation.allowSceneActivation = false;
        // LoadingCanvasScript canvas = (new GameObject("Canvas").AddComponent<LoadingCanvasScript>());
        //  LoadingCanvasScript canvas = GameObject.FindGameObjectWithTag("LOAD");
        canvas.gameObject.SetActive(true);
        if (menuScreen != null)
        {
            menuScreen.SetActive(false);
        }
        while (!asyncOperation.isDone)
        {
            canvas.Slider.fillAmount += asyncOperation.progress ;

            Debug.Log("puk");
            if (asyncOperation.progress >= 0.9f)
            {
                canvas.text.enabled = true;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    asyncOperation.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }

}
