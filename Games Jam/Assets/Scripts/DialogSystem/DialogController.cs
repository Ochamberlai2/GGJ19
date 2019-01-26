using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogController : MonoBehaviour
{
    public GameObject DDB;
    private string OutputText;
    private int CurrentID;
    public GameObject DialogBoxPrefab;
    private GameObject box;
    public GameObject DEBUG_infld;

    void Start()
    {
        OpenDialog(0);
    }

    /*
       How to use:

        reference this object's function OpenDialog(ID number). Each dialog has own unique
        ID number, see list for reference. Box will close itself if another messege is triggered.
        You can manually close the box by using CloseDialog().

        Please note that all public references needs to be assigned in the inspector.
        Canvas should be tagged "Canvas" just to avoid some random bugs.

    */
    void Update()
    {
        
    }


    public void OpenDialog(int ID)
    {
        if(box != null)
        {
            CloseDialog();
        }
        var Canvas = GameObject.FindGameObjectWithTag("Canvas");
        OutputText = DDB.GetComponent<DialogDatabase>().DialogsDict[ID];
        box = Instantiate(DialogBoxPrefab, Canvas.transform.position, Canvas.transform.rotation);
        box.transform.SetParent(Canvas.transform);
        box.transform.GetChild(0).gameObject.GetComponent<Text>().text = OutputText;
        box.GetComponent<Animator>().Play("MoveIn");
        box.transform.localScale = new Vector3(18.96987f, 2.226429f, 0.576515f); //this is just to fix some issue with scaling after parenting to canvas, please ignore.
    }

    public void CloseDialog()
    {
        Destroy(box, 1);
        box.GetComponent<Animator>().Play("MoveOut");
        box = null;
    }

    public void DEBUG_buttonPress() //Just for debug, delete in final game.
    {
        OpenDialog(int.Parse(DEBUG_infld.GetComponent<Text>().text));
    }
    
}
