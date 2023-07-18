using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalUIManager : MonoBehaviour
{
    [SerializeField] GameObject GoHomeButton;
    
    void Start() {
        GoHomeButton.GetComponent<Button>().onClick.AddListener(VirtualWorldManager.Instance.LeaveRoomAndLoadHomeScene);
    }


}
