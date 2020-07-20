using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Characters
{
    public static Player playerInstance;
    public string areaToTransitionName;
    Items hitObject;
    bool shouldDisappear;

    // Start is called before the first frame update
    private void Awake()
    {
        if (playerInstance != null && playerInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            playerInstance = this;
        }
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }


    //Update is called once per frame
    void Update()
    {
        levelUP();
        lvlUP();
    }

    public override IEnumerator DamageCharacter(int damage, float interval)
    {
        throw new System.NotImplementedException();
    }

    public void levelUP()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            currentExperience += 100;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("CanBePickedUp"))
        {
            hitObject = collision.gameObject.GetComponent<UsuableItems>().usuableItems;

            if (hitObject != null)
            {
                shouldDisappear = Inventory.instance.addNewItem(hitObject);
            }
            if (shouldDisappear == true)
            {
                collision.gameObject.SetActive(false);
            }
        }
    }

    public void useItem()
    {
        int itemSelectedPos = Inventory.instance.itemSelected;
        int slotSelectedPos = Inventory.instance.slotSelected;
        int buttonValue = Inventory.instance.slots[slotSelectedPos].buttonValue;

        print("slotSelected is " + slotSelectedPos);
        print("item selected is " + itemSelectedPos);

        if (Inventory.instance.items[itemSelectedPos].itemType == Items.ItemType.CONSUMABLE && buttonValue > 0)
        {
            print("potion Used");
            if (Inventory.instance.items[itemSelectedPos].itemName == "Health Potion" &&  currentHitPoints < maxHitPoints)
            {
                currentHitPoints += 10;
                if(currentHitPoints > maxHitPoints)
                {
                    currentHitPoints = maxHitPoints;
                }
            }
            else if(Inventory.instance.items[itemSelectedPos].itemName == "Mana Potion" && currentManaPoints < maxManaPoints)
            {
                currentManaPoints += 10;
                if (currentManaPoints > maxManaPoints)
                {
                    currentManaPoints = maxManaPoints;
                }
            }
            Inventory.instance.slots[slotSelectedPos].qtyText.text = (Inventory.instance.slots[slotSelectedPos].buttonValue -= 1).ToString();
        }
        else
        {
                switch(Inventory.instance.items[itemSelectedPos].itemName)
                {
                    case "Iron Sword":
                    print("Iron Sword Equipped ");
                    attackPower = Inventory.instance.items[itemSelectedPos].itemDamage;
                           break;

                    case "Iron Armor":
                    print("Iron Armor Equipped ");
                    armorPower = Inventory.instance.items[itemSelectedPos].itemArmor;
                    break;

                    case "Leather Armor":
                    print("Leather Armor Equipped ");
                    armorPower = Inventory.instance.items[itemSelectedPos].itemDamage;
                    break;

                    case "Wooden Sword":
                    print("Wooden Sword Equipped ");
                    attackPower = Inventory.instance.items[itemSelectedPos].itemDamage;
                    break;
                    default:
                            break;
                }
            Inventory.instance.slots[slotSelectedPos].qtyText.text = (Inventory.instance.slots[slotSelectedPos].buttonValue -= 1).ToString();
        }

    }
}

