using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem particlesToPlay;
    
    [SerializeField] float loadDelay = 1f;
    [SerializeField] bool isTransitioning = false;
    // Class to print out what the player object has collided with.

    void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        GetComponent<PlayerController>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        Invoke("ReloadLevel", loadDelay);
        particlesToPlay.Play();
    }

    void ReloadLevel()
    {
        // Reload the current level.
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }


}
