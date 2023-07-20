using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
public class LoginManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField PlayerName_InputName;
    // Start is called before the first frame update
    #region  Unity Methods
    void Start()
    {
;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

    #region UI Callback Methods 
    public void ConnectAnonymusly(){
        PhotonNetwork.ConnectUsingSettings();//do setting and call two function in Photn Callback method region
    }
    
    public void ConnectWithName(){
        if(PlayerName_InputName != null){
            PhotonNetwork.NickName = PlayerName_InputName.text;
            PhotonNetwork.ConnectUsingSettings();
        }
    }
    #endregion
    
    
    #region Photon Callback Methods


    public override void OnConnected()
    {
        Debug.Log("OnConnnection iscalled. The server is available");
    }

    public override void OnConnectedToMaster()
    {
            Debug.Log("connected to the server with nickname: "+PhotonNetwork.NickName);
            PhotonNetwork.LoadLevel("HomeScene");
    }
    #endregion
}
