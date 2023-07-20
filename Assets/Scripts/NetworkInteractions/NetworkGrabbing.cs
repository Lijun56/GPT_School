using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

//the script is for sync the grab movement of CERTAIN OBJECT in the VR multiplayer network scene
    //send the grab photonview(of object) to the server, and when do so, we:
     //transfer the ownership of the object
    //drop the gravity when grab the object
public class NetworkGrabbing : MonoBehaviourPunCallbacks, IPunOwnershipCallbacks
{
    PhotonView m_photonView;
    Rigidbody rb;
    bool isBeingGrabbed = false;

    private void Awake() {
        m_photonView = GetComponent<PhotonView>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if(isBeingGrabbed){
            rb.isKinematic = true;
            gameObject.layer =11;
        }else{
            rb.isKinematic = false;
            gameObject.layer =9;

        }
    }

    void TransferOwnerShip(){

    }

    public void OnSelect(){
        Debug.Log("Grabbed");
        m_photonView.RPC("StartNetworkGrabbing", RpcTarget.AllBuffered);
        if(m_photonView.Owner ==  PhotonNetwork.LocalPlayer){
            Debug.Log("item is mine, no transfer request can made");
        }
        else{
            TransferOwnerShip();
        }
    }

    public void OnRelease(){
        Debug.Log("Released");
        m_photonView.RPC("StopNetworkGrabbing", RpcTarget.AllBuffered);
        
    }


//functions must  have comes with the dependency "IPunOwnershipCallbacks"
    public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer){
        //must be the object attached with this script
        if(targetView != m_photonView){
            return;
        }
        Debug.Log("OwnerShip Requested for object "+targetView.name+ "made by"+ requestingPlayer.NickName);
    }
    public void OnOwnershipTransfered(PhotonView targetView, Player requestingPlayer){
        Debug.Log("OwnerShip Transfered for object "+targetView.name+ "made by"+ requestingPlayer.NickName);
        
    }
    public void OnOwnershipTransferFailed(PhotonView targetView, Player requestingPlayer){
        Debug.Log("OwnerShip Transfered and Failed for object "+targetView.name+ "made by"+ requestingPlayer.NickName);
        
    }
//////"IPunOwnershipCallbacks" default functions end here

    //makesure the gravity of object droped when grab
    [PunRPC]
    public void StartNetworkGrabbing(){
        isBeingGrabbed =true;
    }
    [PunRPC]
    public void StopNetworkGrabbing(){

        isBeingGrabbed =false;
    }
}
