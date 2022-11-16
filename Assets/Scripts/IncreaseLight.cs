using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class IncreaseLight : MonoBehaviour
{

    public static FireIntensity lightReference;
    
    void Start()
    {
        if (lightReference == null)
        {
            lightReference = FindObjectOfType<FireIntensity>();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            lightReference.IncreaseLight(1);

        }
    }

}
