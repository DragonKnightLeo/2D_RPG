using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;


//This 
public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance;
    const int numberOfPartyMembers = 4;
    public bool canWalk;
    public bool fadingBetweenAreas;
    public bool dialogActive;
    public Characters[] charStats = new Characters[numberOfPartyMembers];
    [SerializeField] PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        if (gameManagerInstance != null && gameManagerInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            gameManagerInstance = this;

        }
        DontDestroyOnLoad(gameObject);
    }

        // Update is called once per frame
    void Update()
    {
        //StopMovement();
    }

    void StopMovement()
    {

        bool activeMenu = MainMenu.instance.activeMenu;

        if (activeMenu || fadingBetweenAreas)
        {
           playerMovement.moveCharacter(canWalk = false);
        }
        else
        {
           playerMovement.moveCharacter(canWalk = true);
        }
    }
}
