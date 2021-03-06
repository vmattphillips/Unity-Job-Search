﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StaticPlayerScript : MonoBehaviour
{
    public Vector2 joystick;
    public float speed;
    public GameObject centerEyeAnchor;
    public GameObject cameraRig;
    public GameObject oculusGoRemote;

    public GameObject outsideToInside;
    public GameObject outsideToDorm;
    public GameObject insideToOutside;
    public GameObject insideToFrontDesk;
    public GameObject frontDeskToInside;
    public GameObject frontDeskGO;
    public GameObject ccFrontToBack;
    public GameObject ccFrontToDorm;
    public GameObject ccBackToFront;
    public GameObject showText;
    public GameObject Textbg;
    public AudioClip sound;
    public GameObject TEST;
    RaycastHit hit;


    public GameObject returnCanvas;
    public GameObject map;
    public RawImage rawImage;
    public GameObject fairtxt;
    public GameObject dormtxt;
    public GameObject darlatxt;
    public GameObject cectxt;

    public GameObject Fair;
    public GameObject Dorm;
    public GameObject Darla;
    public GameObject CEC;
    public GameObject Tips;
    private bool canvasOn;
    public GameObject fkingCamera;
    private string sceneName;
    private bool tutorialOff;
    public GameObject tutorial;
    //public Text DisplayText;
    //public GameObject Door;

    //public GameObject CareerCenterButton;

    //public GameObject InterviewButton;

    //GameObject FairButton;




    //public GameObject ResumeButton;

    /*
    void HandlePlayerMovement()
    {
        joystick = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);

        transform.eulerAngles = new Vector3(0, centerEyeAnchor.transform.localEulerAngles.y, 0);
        transform.Translate(Vector3.forward * speed * joystick.y * Time.deltaTime);
        transform.Translate(Vector3.right * speed * joystick.x * Time.deltaTime);

        cameraRig.transform.position = Vector3.Lerp(cameraRig.transform.position, transform.position, 10f * Time.deltaTime);
    }
    */
    void Start()
    {
        canvasOn = false;
        
        sceneName = SceneManager.GetActiveScene().name;
        fkingCamera.SetActive(true);
        if (PlayerPrefs.HasKey("darlatutorial") == false && sceneName == "Outside_Front")
        {
            
            tutorial.SetActive(true);
            outsideToInside.SetActive(false);
            outsideToDorm.SetActive(false);
            if(Tips != null) { Tips.SetActive(false); }
            
        }
        else if(PlayerPrefs.HasKey("fairtutorial") == false && sceneName == "CareerCenterFront")
        {
            tutorial.SetActive(true);
            ccFrontToBack.SetActive(false);
            ccFrontToDorm.SetActive(false);
            if (Tips != null) { Tips.SetActive(false); }
        }
    }

    void HandleGyroController()
    {
        //oculusGoRemote.transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote);


        if (canvasOn == false && OVRInput.GetDown(OVRInput.Button.Back) == true)
        {
            canvasOn = true;
            
            if (sceneName == "Outside_Front")
            {
                tutorial.SetActive(false);
                outsideToInside.SetActive(false);
                outsideToDorm.SetActive(false);
                
            }
            else if (sceneName == "Inside_Front_Entrance")
            {
                insideToOutside.SetActive(false);
                insideToFrontDesk.SetActive(false);
            }
            else if (sceneName == "Inside_Front_Desk")
            {
                frontDeskGO.SetActive(false);
                frontDeskToInside.SetActive(false);
            }
            else if (sceneName == "CareerCenterFront")
            {
                tutorial.SetActive(false);
                ccFrontToBack.SetActive(false);
                ccFrontToDorm.SetActive(false);
            }
            else if (sceneName == "CareerCenterBack")
            {
                ccBackToFront.SetActive(false);
                
            }
            else
            {

            }
            if (Tips != null)
            {
                Tips.SetActive(false);
            }
            
            returnCanvas.SetActive(true);

            returnCanvas.GetComponent<LaptopMenu>().openLaptopMenu();

        }
        else if (canvasOn == true && OVRInput.GetDown(OVRInput.Button.Back) == true)
        {
            canvasOn = false;
            
            if (sceneName == "Outside_Front")
            {
                outsideToInside.SetActive(true);
                outsideToDorm.SetActive(true);
            }
            else if (sceneName == "Inside_Front_Entrance")
            {
                insideToOutside.SetActive(true);
                insideToFrontDesk.SetActive(true);
            }
            else if (sceneName == "Inside_Front_Desk")
            {
                frontDeskGO.SetActive(true);
                frontDeskToInside.SetActive(true);
            }
            else if (sceneName == "CareerCenterFront")
            {
                ccFrontToBack.SetActive(true);
                ccFrontToDorm.SetActive(true);
            }
            else if (sceneName == "CareerCenterBack")
            {
                ccBackToFront.SetActive(true);

            }
            else
            {

            }
            if (Tips != null)
            {
                Tips.SetActive(true);
            }
            returnCanvas.SetActive(false);
            rawImage.GetComponent<RawImage>().color = Color.white;
            returnCanvas.GetComponent<LaptopMenu>().closeLaptopMenu(); // Although its not really LaptopMenu.. Just using the functionality of it.. just opens menu linked
            map.SetActive(false);
            Fair.SetActive(false);
            Dorm.SetActive(false);
            Darla.SetActive(false);
            CEC.SetActive(false);
            fairtxt.SetActive(false);
            dormtxt.SetActive(false);
            cectxt.SetActive(false);
            darlatxt.SetActive(false);


        }

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(oculusGoRemote.transform.position, oculusGoRemote.transform.forward, out hit))
        {
            //Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.name == "outsideToInside")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                outsideToInside.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("Inside_Front_Entrance");
                    
                }
            }
            if (hit.collider.gameObject.name == "outsideToDorm")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                outsideToDorm.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                
                
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("Dorm");
                }
            }
            if (hit.collider.gameObject.name == "insideToFrontDesk")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                insideToFrontDesk.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("Inside_Front_Desk");
                }
            }
            if (hit.collider.gameObject.name == "insideToOutside")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                insideToOutside.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("Outside_Front");
                }
            }
            if (hit.collider.gameObject.name == "frontDeskToInside")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                frontDeskToInside.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("Inside_Front_Entrance");
                }
            }
            //**************************************************************

            if (hit.collider.gameObject.name == "CCFrontToBack")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                ccFrontToBack.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("CareerCenterBack");
                }
            }
            if (hit.collider.gameObject.name == "CCFrontToDorm")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                ccFrontToDorm.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("Dorm");
                }
            }
            if (hit.collider.gameObject.name == "CCBackToFront")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                ccBackToFront.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("CareerCenterFront");
                }
            }


            if (hit.collider.gameObject.name == "frontDeskGO")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                frontDeskGO.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    // TODO: add something when interacted with
                }
            }
            if((hit.collider.gameObject.name == "menu_exit" && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true))
            {
                
                if (sceneName == "Outside_Front")
                {
                    PlayerPrefs.SetInt("darlatutorial", 1);
                    tutorial.SetActive(false);
                    outsideToInside.SetActive(true);
                    outsideToDorm.SetActive(true);
                    if (Tips != null) { Tips.SetActive(true); }
                }
                else if(sceneName == "CareerCenterFront")
                {
                    PlayerPrefs.SetInt("fairtutorial", 1);
                    tutorial.SetActive(false);
                    ccFrontToBack.SetActive(true);
                    ccFrontToDorm.SetActive(true);
                    if (Tips != null) { Tips.SetActive(true); }
                }
                else if (sceneName == "Inside_Front_Entrance")
                {
                    insideToOutside.SetActive(true);
                    insideToFrontDesk.SetActive(true);
                    if (Tips != null) { Tips.SetActive(true); }
                }
                else if (sceneName == "Inside_Front_Desk")
                {
                    frontDeskGO.SetActive(true);
                    frontDeskToInside.SetActive(true);
                    if (Tips != null) { Tips.SetActive(true); }
                }
                else if (sceneName == "CareerCenterBack")
                {
                    ccBackToFront.SetActive(true);
                    if (Tips != null) { Tips.SetActive(true); }
                }

                returnCanvas.SetActive(false);
            }
            /*
            else if (hit.collider.gameObject.name == "CareerCenter_Button")
            {

                CareerCenterButton.GetComponent<VRButtonBehavior>().changeColor();
                if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) == 1)
                {
                    DisplayText.text = "Button Touched";
                    SceneManager.LoadScene("Outside_Front");
                }
            }
            else
            {
                Door.GetComponent<DoorBehavior>().hideText();
                Door.GetComponent<DoorBehavior>().closeDoorMenu();
                CareerCenterButton.GetComponent<VRButtonBehavior>().resetColor();

            }


            //Debug.DrawLine(oculusGoRemote.transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.cyan);
            //Debug.Log("Did Hit");
            */

            // THIS IS THE HOVERABLE TIPS IN EACH SCENE DOWN HERE AND ITS FOR ALL THE SCENES
            /*if (hit.collider.gameObject.name == "Tips")
            {
                showText.SetActive(true);
                Textbg.SetActive(true);
                Debug.Log("WTF");
            }
            else if(!(hit.collider.gameObject.name == "Tips"))
            {
                Debug.Log("FK");
            }*/

            if ((hit.collider.gameObject.name == "Quit_Btn" && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true))
            {
                SceneManager.LoadScene("MainMenu");
                
            }
            if ((hit.collider.gameObject.name == "Map_Btn" && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true))
            {
                returnCanvas.GetComponent<LaptopMenu>().closeLaptopMenu();
                map.SetActive(true);
                rawImage.GetComponent<RawImage>().color = Color.black;
                if(sceneName == "Outside_Front" || sceneName == "Inside_Front_Entrance" || sceneName == "Inside_Front_Desk")
                {
                    Fair.SetActive(true);
                    Dorm.SetActive(true);
                    CEC.SetActive(true);
                }
                else if(sceneName == "CareerCenterFront" || sceneName == "CareerCenterBack")
                {
                    Darla.SetActive(true);
                    Dorm.SetActive(true);
                    CEC.SetActive(true);
                }
                
             
            }
            if (hit.collider.gameObject.name == "Dorm")
            {
                fairtxt.SetActive(false);
                darlatxt.SetActive(false);
                cectxt.SetActive(false);
                dormtxt.SetActive(true);

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    SceneManager.LoadScene("Dorm");
                }
            }
            if (hit.collider.gameObject.name == "Fair")
            {
                dormtxt.SetActive(false);
                darlatxt.SetActive(false);
                cectxt.SetActive(false);
                fairtxt.SetActive(true);

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    var visited_jobfair = true;  //***This should trigger the laptop to get an email from an employer***
                    PlayerPrefs.SetInt("visited_jobfair", visited_jobfair ? 1 : 0);
                    SceneManager.LoadScene("CareerCenterFront");
                }
            }
            if (hit.collider.gameObject.name == "Darla")
            {
                dormtxt.SetActive(false);
                fairtxt.SetActive(false);
                cectxt.SetActive(false);
                darlatxt.SetActive(true);

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    SceneManager.LoadScene("Outside_Front");
                }
            }
            if (hit.collider.gameObject.name == "Swearingen")
            {
                dormtxt.SetActive(false);
                fairtxt.SetActive(false);
                darlatxt.SetActive(false);
                cectxt.SetActive(true);
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    SceneManager.LoadScene("CECOutsideFar");
                }
            }
        }
    }

    void HoverTips()
    {
        //If the pointer hovers over the Tip icons, it will display text, and remove it when they point away
        
        if (Physics.Raycast(oculusGoRemote.transform.position, oculusGoRemote.transform.forward, out hit))
        {
            if (hit.collider.gameObject.name == "Tips")
            {
                showText.SetActive(true);
                Textbg.SetActive(true);

            }
            else
            {
                showText.SetActive(false);
                Textbg.SetActive(false);
            }
            

        }
       
    }

    void Update()
    {
        //HandlePlayerMovement();
        HandleGyroController();
        HoverTips();
        
    }
}
