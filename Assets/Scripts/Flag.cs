using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Flag : MonoBehaviour
{
    ParticleSystem winning;

    public void Start()
    {

        winning = GetComponent<ParticleSystem>();
    }

    IEnumerator WonFlag()
    {
        winning.Play();

        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Won");
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Scene scene = SceneManager.GetActiveScene();

        if (collision.gameObject.CompareTag("Player"))
        {
            if (scene.name == "Level_1")
            {
                SceneManager.LoadScene("Level_2");

            }
            else
            {
                StartCoroutine(WonFlag());
            }
        }
    }
}
