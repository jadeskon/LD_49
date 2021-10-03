using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharGrafiksController : MonoBehaviour
{
    [SerializeField]
    private PlayerCharakterController owner;
    [SerializeField]
    private Transform pasengerSpawnPos;
    [SerializeField]
    private GameObject pasengerPrefab;
    [SerializeField, Range(0, 10)]
    private float distenceBetwenePasengers = 1.0f;
    [SerializeField, Range(0, 10)]
    private int testAmountOfPasengers = 0;
    private List<GameObject> displayedPasengers = new List<GameObject>();
    public void UpdateGrafiks()
    {

    }

    public void SetAmountDisplayedPasengers(uint newAmountOfPasangers)
    {
        if (Application.isPlaying)
        {
            if (newAmountOfPasangers < displayedPasengers.Count)
            {
                while (newAmountOfPasangers < displayedPasengers.Count)
                {
                    Destroy(displayedPasengers[displayedPasengers.Count - 1].gameObject);
                    displayedPasengers.RemoveAt(displayedPasengers.Count - 1);
                }
            }
            else if (newAmountOfPasangers > displayedPasengers.Count)
            {
                while (newAmountOfPasangers > displayedPasengers.Count)
                {
                    GameObject pasengerReference = Instantiate(pasengerPrefab, pasengerSpawnPos);
                    pasengerReference.transform.position = new Vector3( pasengerReference.transform.position.x, 
                                                                        displayedPasengers.Count * distenceBetwenePasengers + pasengerReference.transform.position.y, 
                                                                        pasengerReference.transform.position.z);
                    displayedPasengers.Add(pasengerReference);
                }
            }
        }        
    }

    private void OnValidate()
    {
        if (testAmountOfPasengers != displayedPasengers.Count)
        {
            SetAmountDisplayedPasengers((uint)testAmountOfPasengers);
        }
    }
}
