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
    private GameObject personePrefab;
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
        Instantiate(housePrefabs[Random.Range(0, housePrefabs.Count)], houseSpawnPos);
    }

    public void SpawnPerson() 
    {
        if (IsHouseFree())
        {
            personInstace = Instantiate(personePrefab, spawnPos);
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

    private void OnTriggerEnter(Collider other)
    {
        if (!IsHouseFree())
        {
            eventChanel.PersonCollected(this);
        }
    }
}
