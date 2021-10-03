using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : MonoBehaviour 
{
    [SerializeField]
    private List<GameObject> housePrefabs;
    [SerializeField]
    private Transform houseSpawnPos;
    [SerializeField]
    private GameObject housePlaceHolder;
    [SerializeField]
    private List<GameObject> personePrefabList = new List<GameObject>();
    private GameObject personInstace;
    [SerializeField]
    private Transform spawnPos;
    [SerializeField]
    private GameplayEventSystem eventChanel;
    private BoxCollider collectBoxColliderTrigger;

    private void Awake()
    {
        collectBoxColliderTrigger = GetComponent<BoxCollider>();
        
    }

    private void Start()
    {
        housePlaceHolder.SetActive(false);
        eventChanel.RegisterHome(this);
        Instantiate(housePrefabs[Random.Range(0, housePrefabs.Count)], houseSpawnPos);
    }

    public void SpawnPerson() 
    {
        if (IsHouseFree())
        {
            personInstace = Instantiate(personePrefabList[Random.Range(0, personePrefabList.Count)], spawnPos);
        }
    }

    public bool IsHouseFree()
    {
        if (personInstace == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SavePerson()
    {
        eventChanel.PersonCollected(this);
        Destroy(personInstace);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!IsHouseFree())
        {
            SavePerson();
        }
    }
}
