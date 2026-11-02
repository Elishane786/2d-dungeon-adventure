using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Door : MonoBehaviour
{
    public Animator door;
    public string nextSceneName;
    private bool isPlayerNear = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E)) 
        {
            door.SetBool("IsOpened", true);
            StartCoroutine(FadeAndLoadScene());
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    IEnumerator FadeAndLoadScene()
    {
        FindObjectOfType<FadeEffect>().StartFadeOut();
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(nextSceneName);
    }
}


