using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class MenuScreenScript : MonoBehaviour
{
    public Button New_Game, Quit;
    public GameObject Video;
    private VideoPlayer player;
    // Start is called before the first frame update
    void Start()
    {
        player = Video.GetComponent<VideoPlayer>();
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
        Scene scene = SceneManager.GetSceneByBuildIndex(1);
        StartCoroutine("BackLoading");
       
    }

    IEnumerator BackLoading(Scene scene)
    {
        SceneManager.LoadScene(1);
        while (!scene.isLoaded)
        {
            Debug.Log("puk");
            yield return null;
        }
    }
}
