using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;
public class PlayerNetworkSetup : MonoBehaviourPunCallbacks
{
    //main function of this script is to tell who is who in the multiplayer scene
    public GameObject LocalXRRigGameObject;
    // Start is called before the first frame update
    public GameObject AvatarHead;
    public GameObject AvatarBody;

    void Start()
    {
        if(photonView.IsMine){
            //the player is local 
            LocalXRRigGameObject.SetActive(true);
            //if the avatar is mine, i set head and body
            SetLayerRecursively(AvatarHead, 6);
            SetLayerRecursively(AvatarBody, 7);

            //achieve teleporation function
            TeleportationArea[] teleportationAreas = GameObject.FindObjectsOfType<TeleportationArea>();
            if(teleportationAreas.Length > 0){
                Debug.Log("found this long: " + teleportationAreas.Length+"teleporation Area.");
                foreach(var item in teleportationAreas){
                    item.teleportationProvider = LocalXRRigGameObject.GetComponent<TeleportationProvider>();
                }
            }
        }
        else{
            //the player is remote
            LocalXRRigGameObject.SetActive(false);
            SetLayerRecursively(AvatarHead, 0);
            SetLayerRecursively(AvatarBody, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetLayerRecursively(GameObject go, int layerNumber)
    {
        if (go == null) return;
        foreach (Transform trans in go.GetComponentsInChildren<Transform>(true))
        {
            trans.gameObject.layer = layerNumber;
        }
    }
}
