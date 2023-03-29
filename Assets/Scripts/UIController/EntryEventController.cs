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

    public void onLoginClick()
    {
        this.networkManager.emitLogin(textField.GetComponent<TextMeshProUGUI>().text);
        this.nameInput.GetComponent<TMP_InputField>().interactable = false;
        this.button.GetComponent<Button>().interactable = false;
        this.attachGrayLayer();
    }

    private void attachGrayLayer()
    {
        GameObject grayLayer = Resources.Load<GameObject>("Prefabs/Common/GrayLayer");
        GameObject grayLayerObject = Instantiate(grayLayer);
        grayLayerObject.transform.position = new Vector3(0, 0);

        this.attachLoadingProgress(grayLayer);
    }

    private void attachLoadingProgress(GameObject parent)
    {
        GameObject loading = Resources.Load<GameObject>("Prefabs/Common/Loading");
        GameObject loadingObject = Instantiate<GameObject>(loading);
    }
}
