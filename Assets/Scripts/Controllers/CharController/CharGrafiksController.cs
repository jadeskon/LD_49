using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharGrafiksController : MonoBehaviour
{
    [SerializeField]
    private PlayerCharakterController owner;
    [SerializeField]
    private GameObject charGrafiksGO;
    [SerializeField]
    private float orientationSpeed = 10.0f;
    public void UpdateGrafiks()
    {
        //OrientToGrund();
    }

    private void OrientToGrund()
    {
        Vector3 localForward = owner.transform.localRotation * Vector3.forward;
        Quaternion orientationToGrund = Quaternion.LookRotation(localForward, owner.GetNormalOfGrund());
        transform.rotation = Quaternion.Slerp(transform.rotation, orientationToGrund, Time.deltaTime * orientationSpeed);
    }
}
