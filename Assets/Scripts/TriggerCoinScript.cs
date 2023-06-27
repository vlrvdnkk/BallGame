using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCoinScript : MonoBehaviour
{
    [SerializeField] private Animator _ladder;
    private void OnTriggerStay(Collider collid)
    {
        if (collid.gameObject.name == "coin1" | collid.gameObject.name == "coin2" | collid.gameObject.name == "coin3")
        {
            _ladder.SetBool("go", true);
        }
    }
}
