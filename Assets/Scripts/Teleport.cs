using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

public class Teleport : MonoBehaviour
{
    [SerializeField] Transform teleportTarget;
    [SerializeField] GameObject player;
    [SerializeField] Light areaLight;
    [SerializeField] Light mainWorldLight;

    [SerializeField] List<Transform> teleportPlatforms; // Voeg een lijst van platforms toe

   
    void Start() 
    {
        if (mainWorldLight != null)
        {
            mainWorldLight.enabled = false; // Zet de lamp uit
        }

        if (areaLight != null)
        {
            areaLight.enabled = false; // Zet de lamp uit
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject == player)
        {
            TeleportPlayer();
            DeactivateObject();
            IlluminateArea();
            StartCoroutine (BlinkWorldLight());
            TeleportPlayerRandom();
        }
        
    }

    void TeleportPlayer()
    {
        player.transform.position = teleportTarget.position;
    }

    // teleport niet nog een keer
    void DeactivateObject()
    {
        GetComponent<Collider>().enabled = false;
    }

    void IlluminateArea()
    {
        if (areaLight != null)
        {
            areaLight.enabled = true; // Zet de lamp aan
            StartCoroutine(DisableLightAfterDelay(5f)); // Zet de lamp na 5 seconden weer uit
        }
    }

    IEnumerator DisableLightAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (areaLight != null)
        {
            areaLight.enabled = false; // Zet de lamp uit
        }
    }
    IEnumerator BlinkWorldLight()
    {
        if (mainWorldLight != null)
        {
            Debug.Log("BlinkWorldLight started");
            mainWorldLight.enabled = true; // Zet de lamp aan
            yield return new WaitForSeconds(2f); // Wacht 2 seconden
            mainWorldLight.enabled = false; // Zet de lamp uit
            Debug.Log("BlinkWorldLight finished");
        }
        else
        {
            Debug.LogWarning("mainWorldLight is not assigned!");
        }
    }

    void TeleportPlayerRandom()
    {
        if (teleportPlatforms != null && teleportPlatforms.Count > 0)
        {
            // Kies een willekeurig platform uit de lijst
            int randomIndex = Random.Range(0, teleportPlatforms.Count);
            Transform randomPlatform = teleportPlatforms[randomIndex];

            // Teleporteer de speler naar het gekozen platform
            player.transform.position = randomPlatform.position;
        }
        else
        {
            Debug.LogWarning("De lijst met teleportPlatforms is leeg of niet ingesteld!");
        }
    }



}
