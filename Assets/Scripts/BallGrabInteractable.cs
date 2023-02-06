using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BallGrabInteractable : XRGrabInteractable
{
    //I've omitted some unnecessary code here


    public void Update()
    {

    }

    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        ulong cID = 0;
        //Method to set cID to the player ID of the player who's grabbed the ball
        GetComponent<GrabbableBall>().changeDiscOwnershipServerRpc();
        base.OnSelectEntered(interactor);
    }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);
        GetComponent<GrabbableBall>().resetDiscOwnershipServerRpc();

    }
}
