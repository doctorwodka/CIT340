using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    // Start is called before the first frame update

    public Camera cam;
    public void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();


        if (cam == null)
        {
            cam = Camera.main;

        }

        DontDestroyOnLoad(this);

        if (scene.name == "Menu" || scene.name == "Credits" || scene.name == "Won" || scene.name == "Died")
        {
            Destroy(this);
        }
    }

}
