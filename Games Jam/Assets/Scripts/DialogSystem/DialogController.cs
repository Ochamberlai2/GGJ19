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
        OpenDialog(3);
    }

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
        OutputText = DDB.GetComponent<DialogDatabase>().Dialogs[ID];
        box = Instantiate(DialogBoxPrefab, Canvas.transform.position, Canvas.transform.rotation);
        box.transform.SetParent(Canvas.transform);
        box.transform.GetChild(0).gameObject.GetComponent<Text>().text = OutputText;
        box.GetComponent<Animator>().Play("MoveIn");
        box.transform.localScale = new Vector3(18.96987f, 2.226429f, 0.576515f);
    }

    public void CloseDialog()
    {
        Destroy(box, 1);
        box.GetComponent<Animator>().Play("MoveOut");
        box = null;
    }

    public void DEBUG_buttonPress()
    {
        OpenDialog(int.Parse(DEBUG_infld.GetComponent<Text>().text));
    }
    
}
