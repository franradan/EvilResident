using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    private bool isLoaded;
    private bool shouldLoad;

    void Start()
    {
        if (SceneManager.sceneCount > 0)
        {
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                if(scene.name == gameObject.name)
                {
                    isLoaded = true;
                }
            }
        }
    }

    void Update()
    {
        TriggerCheck();
    }

    void LoadScene()
    {
        if(!isLoaded)
        {
            SceneManager.LoadSceneAsync(gameObject.name, LoadSceneMode.Additive);
            isLoaded = true;
        }
    }

    void unloadScene()
    {
        if(isLoaded)
        {
            SceneManager.UnloadSceneAsync(gameObject.name);
            isLoaded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            shouldLoad = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            shouldLoad = false;
        }
    }

    void TriggerCheck()
    {
        if(shouldLoad)
        {
            LoadScene();
        }
        else
        {
            unloadScene();
        }
    }


}
