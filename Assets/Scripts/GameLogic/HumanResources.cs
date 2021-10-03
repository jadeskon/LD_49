using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanResources 
{

    public List<GameObject> activePersons { get; private set; }
    public List<GameObject> carPersons { get; private set; }
    
    private List<HouseController> houseControllerList;
    private int countSavedPersons = 0;
    private int countSacrificePersons = 0;

    public HumanResources (GameplayEventSystem eventSystem)
    {
        activePersons = new List<GameObject>();
        carPersons = new List<GameObject>();

        eventSystem.registerHomeEvent += RegisterHome;
    }

    private void RegisterHome(HouseController houseController)
    {
        houseControllerList.Add(houseController);
    }

    public void SpawnPersons(int count, HouseController house)
    {
        for (int i = 0; i < count; i++)
        {

        }
    }

    public GameObject GetClosestPerson(Vector3 fromPosition)
    {
        GameObject nearestPerson = null;
        float nearstDistance = 0;
        
        foreach (GameObject person in activePersons)
        {
            float distance = (person.transform.position - fromPosition).magnitude;
            
            if(nearstDistance > distance || nearestPerson == null)
            {
                nearstDistance = distance;
                nearestPerson = person;
            }
        }

        return nearestPerson;
    }

    public void RemoveActivePerson(GameObject person, bool saved)
    {
        activePersons.Remove(person);
        Object.Destroy(person);

        if (saved)
            countSavedPersons++;
        else
            countSacrificePersons++;
    }

    public void RemovePersonsOfCar ()
    {
        foreach (GameObject person in carPersons)
        {
            Object.Destroy(person);
        }

        carPersons.Clear();
    }

    public void PickUpPerson(GameObject person)
    {
        carPersons.Add(person);

        activePersons.Remove(person);
    }

    public List<GameObject> GetActivePersons()
    {
        return activePersons;
    }

    public List<GameObject> GetCarPersons()
    {
        return carPersons;
    }

    public int GetCountOfActivePersons()
    {
        return activePersons.Count;
    }

    public int GetCountOfCarPersons()
    {
        return carPersons.Count;
    }

    public int GetCountOfSavedPersons()
    {
        return countSavedPersons;
    }

    public int GetCountOfSacrificedPersons()
    {
        return countSavedPersons;
    }
}
