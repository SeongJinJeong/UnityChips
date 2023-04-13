using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using NetworkDataStuct;
using System.Threading;

public class LobbyManager : MonoBehaviour
{
    private MainManager mainManager = null;
    [SerializeField]
    GameObject NameField;
    [SerializeField]
    private TMP_Text textRoomCode = null;
    [SerializeField]
    private UnityEngine.UI.Button btnStart = null;
    [SerializeField]
    private UnityEngine.UI.Button btnJoin = null;
    [SerializeField]
    private TMP_InputField inputRoomCode = null;

    private DataPlayer playerData = null;

    // Start is called before the first frame update
    void Start()
    {
        btnJoin.onClick.AddListener(()=> { this.onButtonClick(btnJoin); });
        btnJoin.onClick.AddListener(() => { this.onBtnJoinClick(btnJoin); });

        btnStart.interactable = false;

        this._processEnterLobby();
    }

    private void _processEnterLobby()
    {
        this.mainManager.spawnGrayLayer();
        NetworkManager.getInstance().emitEnterLobby();
    }

    public void onEnterLobbySucceed()
    {
        Debug.Log("Enter Lobby Succeed!");
        this._onEnterLobbySucceed();
    }
    public void _onEnterLobbySucceed()
    {
        this.playerData = PlayerDataContainer.getInstance().getPlayerData();
        NameField.GetComponent<TMP_Text>().text = this.playerData.name;
        NetworkManager.getInstance().emitEnterRoom(this.playerData.id);
    }

    public void onEnterRoomSucceed()
    {
        this.mainManager.removeGrayLayer();
        this.textRoomCode.text = this.playerData.roomid;
    }

    public void onNewUserEnter()
    {
        //todo 유저가 방에 입장했을 때 Start 버튼 Interactable 켜기
        
    }

    private void onButtonClick(UnityEngine.UI.Button btn)
    {
        this.setUIInteractable(false);
        MainManager.getInstance().spawnGrayLayer();
    }

    private void onBtnJoinClick(UnityEngine.UI.Button btn)
    {
        Debug.Log("Join Button Clicked!");
    }

    private void setUIInteractable(bool interactable)
    {
        if(interactable == false)
        {
            this.btnJoin.interactable = false;
            this.btnStart.interactable = false;
            this.inputRoomCode.interactable = false;

            Color prevColor = this.btnJoin.transform.GetChild(0).GetComponent<TMP_Text>().color;
            this.btnJoin.transform.GetChild(0).GetComponent<TMP_Text>().color = new Color(prevColor.r, prevColor.g, prevColor.b, 0.5f);

            prevColor = this.btnStart.transform.GetChild(0).GetComponent<TMP_Text>().color;
            this.btnStart.transform.GetChild(0).GetComponent<TMP_Text>().color = new Color(prevColor.r, prevColor.g, prevColor.b, 0.5f);
        } else
        {
            this.btnJoin.interactable = true;
            this.btnStart.interactable = true;
            this.inputRoomCode.interactable = true;

            Color prevColor = this.btnJoin.transform.GetChild(0).GetComponent<TMP_Text>().color;
            this.btnJoin.transform.GetChild(0).GetComponent<TMP_Text>().color = new Color(prevColor.r, prevColor.g, prevColor.b, 1f);

            prevColor = this.btnStart.transform.GetChild(0).GetComponent<TMP_Text>().color;
            this.btnStart.transform.GetChild(0).GetComponent<TMP_Text>().color = new Color(prevColor.r, prevColor.g, prevColor.b, 1f);
        }
    }
}
