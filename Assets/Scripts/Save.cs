using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class Save : MonoBehaviour
{
    // Start is called before the first frame update

    public Camera cam;
    public GameObject savedObject;
    public void Start()
    {
        Scene scene = SceneManager.GetActiveScene();


        if (cam == null)
        {
            cam = Camera.main;

        }
        


        DontDestroyOnLoad(savedObject);

        if (scene.name == "Menu" || scene.name == "Credits" || scene.name == "Won" || scene.name == "Died")
        {
            SceneManager.MoveGameObjectToScene(savedObject, SceneManager.GetSceneByName("Won"));
            
            SceneManager.UnloadSceneAsync("DontDestroyOnLoad");

            Destroy(savedObject);
        }
    }

}
