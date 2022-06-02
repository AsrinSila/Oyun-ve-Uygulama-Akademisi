using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;
using Cinemachine;
using Cinemachine.Utility;

public class SecondGameZone : MonoBehaviour
{
    //Dialogues
    public AudioSource audioSecondGame;
    public GameObject panel;
    public Font _fontSecondGame;
    public Font _TMPfontSecondGame;
    private GameObject DialogueGOSecondGame;
    private GameObject myTextSecondGame;
    private GameObject infoTextSecondGame;
    private GameObject infoTextCanvasSecondGame;
    private Canvas _canvasSecondGame;
    private Canvas myCanvasSecondGame;
    private Text textSecondGame;
    private Text _infoTextSecondGame;
    private RectTransform rectTransformSecondGame;
    private RectTransform rectTransform2SecondGame;
    private RectTransform rectTransformTextDCSecondGame;
    private RectTransform rectTransformButtonSecondGame;
    private RectTransform rectTransformInfoTextSecondGame;
    bool inDialogueSizeSecondGame = false;
    [SerializeField] GameObject DialogueVirtualCameraSecondGame;
    [SerializeField] GameObject DialogueDollyCartSecondGame;
    public static bool canEscSecondGame = true;
    public GameObject DialogueContinueSecondGame;
    public GameObject TextDCSecondGame;
    public int ContinueCountSecondGame = 0;
    [SerializeField] GameObject NPCSecondGame;
    [SerializeField] GameObject OtisSecondGame;
    public GameObject WriteLineSecondGame;
    public string password = "ABACCA";
    [SerializeField] public GameObject typePassword;
    public int continueCounter = 0;
    public TMP_InputField typePass;

    //private string Line1 = "�- de�i�ik homurtular ve derin sesler-� ";
    //private string Line2 = "�nsan� Buraya gelenler ger�ekli�in ne kadar �a��rt�c� olabilece�ini g�remiyorlar. Size verilen g�zler sadece g�rmenize yar�yor, daha �tesine bakam�yorsunuz� �leride, tepede bir kap� var. Bu kap�y� a�abilmek i�in en ilkel insan zekas�na ihtiyac�n olacak. Ba�ka bir kap�n�n ard�nda seni bekliyor.�";

    //RectTransform m_RectTransform;



    void Start()
    {;
        
        DialogueDollyCartSecondGame.SetActive(false);

        DialogueGOSecondGame = new GameObject();
        DialogueGOSecondGame.name = "Canvas Dialogue";
        DialogueGOSecondGame.AddComponent<Canvas>();

        infoTextCanvasSecondGame = new GameObject();
        infoTextCanvasSecondGame.name = "�nfo Canvas";
        infoTextCanvasSecondGame.AddComponent<Canvas>();
        infoTextCanvasSecondGame.AddComponent<CanvasScaler>();
        infoTextCanvasSecondGame.AddComponent<GraphicRaycaster>();
        _canvasSecondGame = infoTextCanvasSecondGame.GetComponent<Canvas>();
        _canvasSecondGame.renderMode = RenderMode.ScreenSpaceOverlay;

        panel = new GameObject();

        myCanvasSecondGame = DialogueGOSecondGame.GetComponent<Canvas>();
        myCanvasSecondGame.renderMode = RenderMode.ScreenSpaceOverlay;
        DialogueGOSecondGame.AddComponent<CanvasScaler>();
        DialogueGOSecondGame.AddComponent<GraphicRaycaster>();




        //Panel Settings
        panel.transform.parent = DialogueGOSecondGame.transform;
        panel.AddComponent<Image>();
        panel.GetComponent<Image>().color = new Color32(55, 55, 55, 237);
        panel.GetComponent<Image>().raycastTarget = true;
        panel.GetComponent<Image>().maskable = true;
        panel.GetComponent<Transform>().localPosition = new Vector3(0, -194, 0f);
        panel.GetComponent<Transform>().localScale = new Vector3(11.68f, 2.56f, 1);
        DialogueGOSecondGame.SetActive(false);


        // Text
        myTextSecondGame = new GameObject();
        myTextSecondGame.transform.parent = DialogueGOSecondGame.transform;
        myTextSecondGame.name = "Dialogue";
        myTextSecondGame.transform.SetSiblingIndex(666);
        textSecondGame = myTextSecondGame.AddComponent<Text>();
        textSecondGame.transform.GetComponent<Text>().text = " �ifre Gir ";
        textSecondGame.transform.GetComponent<Text>().font = _fontSecondGame;
        textSecondGame.transform.GetComponent<Text>().fontSize = 29;
        rectTransformSecondGame = myTextSecondGame.GetComponent<RectTransform>();


        // Text position
        rectTransformSecondGame = textSecondGame.GetComponent<RectTransform>();
        rectTransformSecondGame.localPosition = new Vector3(0, -229, 0);
        rectTransformSecondGame.sizeDelta = new Vector2(1071, 243);
        rectTransform2SecondGame = textSecondGame.GetComponent<RectTransform>();
        rectTransform2SecondGame.localPosition = new Vector3(0, -229, 0);
        rectTransform2SecondGame.sizeDelta = new Vector2(1071, 243);

        // Info Text
        infoTextSecondGame = new GameObject();
        infoTextSecondGame.name = "Info Text";
        infoTextSecondGame.transform.parent = infoTextCanvasSecondGame.transform;
        infoTextSecondGame.transform.SetSiblingIndex(666);
        _infoTextSecondGame = infoTextSecondGame.AddComponent<Text>();
        _infoTextSecondGame.transform.GetComponent<Text>().text = "Press F to Talk to Wall";
        _infoTextSecondGame.transform.GetComponent<Text>().font = _fontSecondGame;
        _infoTextSecondGame.transform.GetComponent<Text>().fontSize = 29;
        _infoTextSecondGame.transform.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        _infoTextSecondGame.transform.GetComponent<Text>().alignment = TextAnchor.LowerCenter;


        rectTransformInfoTextSecondGame = _infoTextSecondGame.GetComponent<RectTransform>();
        rectTransformInfoTextSecondGame.localPosition = new Vector3(0, -472f, 0);
        rectTransformInfoTextSecondGame.sizeDelta = new Vector2(858.4f, 137f);
        infoTextSecondGame.transform.GetComponent<Text>().fontSize = 53; ;
        rectTransformInfoTextSecondGame = infoTextSecondGame.GetComponent<RectTransform>();


        //Button
        DialogueContinueSecondGame = new GameObject();
        TextDCSecondGame = new GameObject();
        DialogueContinueSecondGame.transform.parent = DialogueGOSecondGame.transform;
        TextDCSecondGame.transform.parent = DialogueContinueSecondGame.transform;
        TextDCSecondGame.name = "Text";
        DialogueContinueSecondGame.name = "Continue Button";
        DialogueContinueSecondGame.AddComponent<CanvasRenderer>();
        TextDCSecondGame.AddComponent<Text>();
        DialogueContinueSecondGame.AddComponent<Image>();
        DialogueContinueSecondGame.GetComponent<Image>().color = new Color32(1, 1, 1, 0);
        DialogueContinueSecondGame.AddComponent<Button>();
        DialogueContinueSecondGame.transform.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        DialogueContinueSecondGame.transform.GetComponent<Transform>().localPosition = new Vector3(427, -274, 0);
        rectTransformButtonSecondGame = TextDCSecondGame.GetComponent<RectTransform>();
        rectTransformTextDCSecondGame = DialogueContinueSecondGame.GetComponent<RectTransform>();
        rectTransformTextDCSecondGame.sizeDelta = new Vector2(172, 82);
        rectTransformButtonSecondGame.sizeDelta = new Vector2(315, 100);
        TextDCSecondGame.transform.GetComponent<Text>().text = "Continue";
        TextDCSecondGame.transform.GetComponent<Text>().font = _fontSecondGame;
        TextDCSecondGame.transform.GetComponent<Text>().fontSize = 45;
        TextDCSecondGame.transform.GetComponent<Transform>().localPosition = new Vector3(88.9f, -33, 0);
        DialogueContinueSecondGame.GetComponent<Button>().onClick.AddListener(() => DialogueContinueOnClickEvent());

        infoTextCanvasSecondGame.SetActive(false);
        DialogueGOSecondGame.SetActive(false);

    }

    void DialogueContinueOnClickEvent()
    {
        if (continueCounter==0)
        {
            //DialogueGOSecondGame.SetActive(false);
            textSecondGame.enabled = false;
            panel.SetActive(false);
            continueCounter++;
            typePass.Select();

        }

        else if (continueCounter==1)
        {
            string typePassword = typePass.GetComponent<TMP_InputField>().text;
            if (typePassword == "ABACCA")
            {
                Debug.Log("DO�RU");
                typePass.Select();
            }
            typePass.Select();
        }
        /*
        Cursor.visible = false;
        StarterAssets.StarterAssetsInputs.instance.cursorInputForLook = true;
        StarterAssets.StarterAssetsInputs.instance.cursorLocked = true;
        infoTextCanvasSecondGame.SetActive(true);
        DialogueGOSecondGame.SetActive(false);
        DialogueVirtualCameraSecondGame.GetComponent<CinemachineVirtualCamera>().Priority = 5;
        infoTextCanvasSecondGame.SetActive(true);
        */
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer != LayerMask.NameToLayer("Key"))
        {
            inDialogueSizeSecondGame = true;
            infoTextCanvasSecondGame.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        inDialogueSizeSecondGame = false;
        infoTextCanvasSecondGame.SetActive(false);
    }

    void Update()
    {
        typePass.text = typePass.text.ToUpper();
        if (Input.GetKeyDown(KeyCode.F) && inDialogueSizeSecondGame == true)
        {
            DialogueVirtualCameraSecondGame.GetComponent<CinemachineVirtualCamera>().LookAt = NPCSecondGame.transform;
            infoTextCanvasSecondGame.SetActive(false);
            DialogueGOSecondGame.SetActive(true);
            DialogueVirtualCameraSecondGame.GetComponent<CinemachineVirtualCamera>().Priority = 15;
            DialogueDollyCartSecondGame.SetActive(true);
            canEscSecondGame = false;
            Cursor.visible = true;
            //audio.Play();
            StarterAssets.StarterAssetsInputs.instance.cursorInputForLook = false;
            StarterAssets.StarterAssetsInputs.instance.cursorLocked = false;
            Cursor.lockState = CursorLockMode.None;
            Death.thirdPersonController.enabled = false;
            //rigidbody.constraints = RigidbodyConstraints.None;
        }
    }

}