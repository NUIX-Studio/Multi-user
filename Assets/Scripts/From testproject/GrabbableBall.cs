using UnityEngine;
using Unity.Netcode;
using System.Collections;

public class GrabbableBall : NetworkBehaviour
{

    public PrimaryButtonWatcher watcher;

    public bool IsPressed = false; // used to display button state in the Unity Inspector window

    public float GrabDistance = 5.0f;

    private Rigidbody m_Rigidbody;
    private Material m_Material;

    private Vector3 velocity = Vector3.zero;

    //private NetworkVariable<bool> m_IsGrabbed = new NetworkVariable<bool>();


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

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Material = GetComponent<Renderer>().material;
    }

    private void FixedUpdate()
    {
        if (NetworkManager == null)
        {
            return;
        }
    }

    private void Update()
    {

        if (NetworkManager == null)
        {
            return;
        }


        if (IsOwner && !IsServer)
        {
            m_Material.color = Color.white;
        }
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

    [ServerRpc(RequireOwnership = false)]
    public void UpdateTranslationServerRpc()
    {

    }

    [ClientRpc]
    public void UpdateTranslationClientRpc()
    {

    }


}
 