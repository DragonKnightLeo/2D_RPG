using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour
{
    public string[] characterLines;

    public GameObject shopButtons;
    
    Characters chars;

    int timeToOpen;

    int waitToOpen = 1;

    private bool canActivate;

    public bool isTalking;

    public bool isPerson = true;

    private void Update()
    {
        displayLines();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        chars = this.GetComponent<Characters>();

        if(other.tag == "Player")
        {
            canActivate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canActivate = false;
        }
    }

    void displayLines()
    {
        if (canActivate == true && Input.GetButtonDown("Fire1") && !DialogManager.instance.dialogBox.activeInHierarchy && chars.characterCategory == Characters.CharacterCategory.NPC)
        {
            DialogManager.instance.ShowDialog(characterLines, isPerson);
            shopButtons.SetActive(false);

        }
        else if(canActivate == true && Input.GetButtonDown("Fire1") && !DialogManager.instance.dialogBox.activeInHierarchy && chars.characterCategory == Characters.CharacterCategory.SHOPKEEPER)
        {
            DialogManager.instance.ShowDialog(characterLines, isPerson);
            shopButtons.SetActive(true);
        }
    }
}
