using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicJump : MonoBehaviour
{
    public ControllerAnimator logicaSalto;

    private void OnTriggerStay(Collider other)
    {
        logicaSalto.puedoSaltar = true;
    }
    private void OnTriggerExit(Collider other)
    {
        logicaSalto.puedoSaltar = false;
    }

}
