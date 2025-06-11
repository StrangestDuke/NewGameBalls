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

    /* Описание локи(варьируется от состояния игры и локации)
     * +
     * Флейвор текст расы и перков
     * +
     * Описание интерьера локи(+ примерное количество предметов на локации.)
     * +
     * Описание лутабельных вещей
     * +
     * Нпс, что присутсвуют на местности
     * 
     * Тут нужно будет реализовывать в тайлах ДнД подобные описания.
     * 
     * Сами тайлы будут состоять из листа предметов, которые находятся на локации.
     * Тайл будет иметь определенный тэг, который в большей мере будет определять иконку данного тайла
     * и возможности взаимодействия с ним для НПС
     * После всех приколов - будет сбриваться описание этих блядских столов и стульев и просто приплюсовываться
     * к существующему описанию.
     * 
     * Предметы с тэгом хранилища можно будет открыть.
     * При нахождении на какой-либо местности, в этих хранилищах будут генирироваться пожитки НПС, которые
     * можно игроку спиздить(пропажу чего может заметить НПС)
     * 
     * Если это тайл, в котором можно переместиться на другую локацию, то на этой хуйне будет тэг, который
     * отвечает за иконку, которая находится на тайле(Либо иконки лок можно руками делать и не выебываться)
     * Проверки делаются именно на тайле, а не на соседнем.
     * Можно засвечивать только проходы, в которые нельзя пройти.
     * 
     * Просто предметы, которые можно взять на локе, что может вызвать разные реакции от НПС или даже конфл.
     * 
     * В самом тайле так-же указано куда он может пойти с этого тайла, а куда нет.(по сути, это можно сделать
     * простенькой менюшкой в инспекторе из 4 bool)
     * 
     * При входе на некоторые тайлы - могут накидываться дополнительные статус эффекты на игрока.
     * 
     * На тайле будет список энкаутеров, которые будут по разному взаимодействовать с игроком, которые будут
     * ролиться при вхождении на тайл игрока, с некоторым шансом.(ну и действия игрока на шансы могут влиять)
     * 
     * Трата времени на подбор предметов из тайла
     * 
     * 
     * *Будущее
     * *Энкаутеры могут быть изменены, если НПС будут взаимодействовать с тайлами, увеличивая\уменьшая шансы
     * 
     * *Будущее
     * На локации могут присутствовать НПС, которые будут заниматься чем-то, из-за чего на локе так-же должны
     * присутствовать всякие хуйни, чтобы НПС могли создавать продукты для себя. Поля, станки...
     * 
     * На тайлы можно влиять, при помощи определенных предметов. Дабы достигать своих целей необходимых и 
     * влиять на глобальные данные(отравить воду там, поле разъебать, дом поджечь)
     * 
     * Вендоры, по сути - не особо нуждаются прямо в отдельных локациях(если игроки не пытаются пробаться вну
     * трь здания. Так что вендоровские магазины без "захода" в здания могут предоставлять услуги.)
     * Но для вендора потребуется отдельное хранилище предметов
     * 
     * Поддержка разных языков.
     * 
     * **При энкаутерах
     * При воздействии НПС - внутрянка шансом энкаутеров меняется
     * Убираются НПС, предметы, существа
     * Существа не отображаются как НПС, они скорее предметы, которые закидываются в описания локи
     * Я не знаю, либо ставить предметы с лимитом, которые персы могут получить, на своих "Работах", либо делать
     * спец тайлы, на которых НПС могут получать предметы.
     * 
     */

    [Space(10), Header("Description")]
    [Space(10)]
    [SerializeField] private TextAsset inkJson;
    [SerializeField] private TextAsset spawnJson;
    [SerializeField] private bool IsThatAShop = false;
    [SerializeField] Sprite icon;
    [SerializeField] public List<statusEffect> effectsOnEntry;

    [Space(10), Header("ItemsToTake")]
    [Space(10)]
    [SerializeField] public List<item> itemsOnTile;
    public int ammountOfItemOnTile = 1;

    [Space(10), Header("Furniture")]
    [Space(10)]
    [SerializeField] private List<furnitureItem> furnitureOnTile;
    [SerializeField] public List<item> itemsInStorages;

    [Space(10), Header("WaysToGo")]
    [Space(10)]
    public bool abilityToGoRight = true;
    public bool abilityToGoLeft = true;
    public bool abilityToGoBack = true;
    public bool abilityToGoForward = true;
    [SerializeField] int timeTakenToGoFromTile = 1;
    [SerializeField] int timeTakenToTakeAnItem = 5;
    public bool isThatLeadsSomewhere = false;
    [SerializeField] public Transform where;


    [Space(10), Header("SystemShit")]
    [Space(10)]
    DialogManager instanceOfTheManager;
    public movement playerInLocation;
    [SerializeField] public List<item> NPCONTile;
    [SerializeField] public List<item> NPCINTile;
    public int UnwantedAttention = 0;


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

            if (furnitureOnTile.Count != 0)
            {
                instanceOfTheManager.ShowFurnitureOnTile(furnitureOnTile);
            }
            playerInLocation = other.gameObject.GetComponent<movement>();
            if (timeTakenToGoFromTile != 0)
            {
                playerInLocation.makeWorldTurnAround(timeTakenToGoFromTile);
            }
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
