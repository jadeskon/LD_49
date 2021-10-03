using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanResources 
{
    PlayState owner;

    GameplayEventSystem gameEventChanel;

    public List<HouseController> activePersons { get; private set; }
    public int personsInCar { get; private set; }
    
    private List<HouseController> houseControllerList;
    private int countSavedPersons;
    private int countSacrificePersons;

    private uint personsInQuewe = 0;

    public HumanResources (PlayState iniOwner)
    {
        owner = iniOwner;

        gameEventChanel = owner.GetGameEventChanel();
        gameEventChanel.registerHomeEvent += RegisterHome;
        gameEventChanel.personCollectedEvent += PickUpPerson;

        Reset();
    }

    public void UpdateHR()
    {
        if (personsInQuewe > 0)
        {
            SpawnPersons(personsInQuewe);
            personsInQuewe = 0;
        }
    }

    internal void Reset()
    {
        houseControllerList = new List<HouseController>();
        activePersons = new List<HouseController>();
        personsInCar = 0;
        countSavedPersons = 0;
        countSacrificePersons = 0;
    }

	private void RegisterHome(HouseController houseController)
    {
        houseControllerList.Add(houseController);
    }

    public void SpawnPersons(uint count)
    {
        if (houseControllerList.Count > 0)
        {
            uint personsPlaced = 0;
            while (personsPlaced < count)
            {
                HouseController controller = houseControllerList[Random.Range(0, houseControllerList.Count)];
                if (controller.IsHouseFree())
                {
                    controller.SpawnPerson();
                    personsPlaced++;
                }
            }
        }
        else
        {
            personsInQuewe = count;
        }
    }

    public HouseController GetClosestPerson(Vector3 fromPosition)
    {
        HouseController nearestPerson = null;
        float nearstDistance = 0;
        
        foreach (HouseController person in activePersons)
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

    public void RemoveActivePerson(HouseController person, bool saved)
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
        personsInCar = 0;
    }

    public void PickUpPerson(HouseController housOfPerson)
    {
        personsInCar++;
        activePersons.Remove(housOfPerson);
    }

    public List<HouseController> GetActivePersons()
    {
        return activePersons;
    }

    public int GetCountOfActivePersons()
    {
        return activePersons.Count;
    }

    public int GetCountOfCarPersons()
    {
        return personsInCar;
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
