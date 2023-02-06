using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.Netcode;
using UnityEngine;

public class GrabbableNetworkObject : NetworkBehaviour
{
    public PrimaryButtonWatcher watcher;
    public bool IsPressed = false; 


    void Start()
    {
        watcher.primaryButtonPress.AddListener(onPrimaryButtonEvent);
    }

    [ServerRpc(RequireOwnership = false)]
    private void TranslatePositionServerRpc()
    {
        transform.Translate(Vector3.forward / 100.0f);
    }

    public void onPrimaryButtonEvent(bool pressed)
    {
        IsPressed = pressed;
        if (pressed)
            TranslatePositionServerRpc();
    }

    [ServerRpc(RequireOwnership = false)]
    public void changeDiscOwnershipServerRpc(ServerRpcParams serverRpcParams = default)
    {
        var senderClientId = serverRpcParams.Receive.SenderClientId;
        NetworkObject.ChangeOwnership(senderClientId);
    }

    [ServerRpc(RequireOwnership = false)]
    public void resetDiscOwnershipServerRpc()
    {
        NetworkObject.RemoveOwnership();
    }
}
