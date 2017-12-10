using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon.LoadBalancing;
using Photon;
public class ServerManager : Photon.PunBehaviour, IPunCallbacks {
    private LoadBalancingClient loadBalancingClient;
    private ExitGames.Client.Photon.LoadBalancing.AuthenticationValues authenticationValues;
    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this);
        PhotonNetwork.ConnectUsingSettings("0.0.1");
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master Server");
    }
    private void OnDestroy()
    {
        PhotonNetwork.Disconnect();
    }

}
