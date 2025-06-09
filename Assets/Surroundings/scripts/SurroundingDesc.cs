using System;
using Ink.Parsed;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;

public class SurroundingDesc : MonoBehaviour
{
    //При захождении на тайл с предметом в окружении - показать клавишу "Взять ...(предмет)" 
    //Если там хранилища - то там появляется обыск и "Вражеский инвентарь"
    //Тут просто лист с предметами, по сути, если есть хранилища - то ещё и с 
    [SerializeField] public List<item> itemsOnTile;

    public int ammountOfItemOnTile = 1;
    [SerializeField] private List<item> storagesOnTile;
    [SerializeField] public Dictionary<item, int> itemsInTile;
    [SerializeField] private TextAsset inkJson;
    [SerializeField] private TextAsset spawnJson;
    DialogManager instanceOfTheManager;
    public movement playerInLocation;
    [SerializeField] int timeTakenToGoFromTile = 1;


    private void Start()
    {
        instanceOfTheManager = DialogManager.GetInstance();
    }

    private void Awake()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            instanceOfTheManager.EnterSurroundingNode(inkJson);
            instanceOfTheManager.WriteCurrentObject(gameObject);

            if(itemsOnTile.Count != 0)
            {
                instanceOfTheManager.DisplayItemsPickups(itemsOnTile);
            }
            playerInLocation = other.gameObject.GetComponent<movement>();
            playerInLocation.makeWorldTurnAround(timeTakenToGoFromTile);
        }
        if(other.gameObject.tag == "check")
        {

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //DialogManager.GetInstance().GutSurroundingNode();
            playerInLocation = other.gameObject.GetComponent<movement>();
        }
    }
    public void DropItemInTile(item item)
    {
        //itemsInTile.Add(item);
    }
}
