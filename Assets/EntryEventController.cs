using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NetworkDataStuct;
using TMPro;

public class EntryEventController : MonoBehaviour
{
    [SerializeField]
    NetworkManager networkManager;
    [SerializeField]
    GameObject textField;
    [SerializeField]
    GameObject button;
    [SerializeField]
    GameObject nameInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sendMessage()
    {
        DataLogin data = new DataLogin();
        data.name = textField.GetComponent<TextMeshProUGUI>().text;
        string json = JsonUtility.ToJson(data);
        this.networkManager.emitMsg("onLogin",json);
        button.GetComponent<Button>().interactable = false;
        nameInput.GetComponent<TMPro.TMP_InputField>().interactable = false;
    }
}
