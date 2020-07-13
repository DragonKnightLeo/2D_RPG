using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    public string areaToLoad;
    public string areaTransitionName;
    public AreaEntrance theEntrance;
    public float waitToLoad = 1f;
    private bool shouldLoadAfterFade;

    // Start is called before the first frame update
    void Start()
    {
        theEntrance.transitionName = areaTransitionName;
    }

    // Update is called once per frame
    void Update()
    {
        fadeScreen();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        { 
            print("loading");
            shouldLoadAfterFade = true;
            GameManager.gameManagerInstance.fadingBetweenAreas = true;
            UIFade.imageInstance.FadeToBlack();
            Player.playerInstance.areaToTransitionName = areaTransitionName;
        }
    }

    void fadeScreen()
    {
        if (shouldLoadAfterFade)
        {
            waitToLoad -= Time.deltaTime;
            if (waitToLoad <= 0)
            {
                shouldLoadAfterFade = false;
                SceneManager.LoadScene(areaToLoad);
            }

        }
    }
}
