﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogController : MonoBehaviour
{
    public GameObject DDB;
    private Font CurrentFont;
    public Font[] TextFont;
    private string OutputText;
    private int CurrentID;
    public GameObject DialogBoxPrefab;
    private GameObject box;

    private bool tmrOn;
    private float tmr1;
    private float tmr2;
    [SerializeField]
    private float textAnimatePauseTime = 0.2f;

	public static DialogController Instance;

    private void Awake()
    {
		if (Instance != null)
		{
			Destroy(gameObject);
			return;
		}
		Instance = this;

        CurrentFont = TextFont[0]; //sets a default font. 
    }

    public void Update()
    {
        if (tmrOn) //used for time out type of dialog pop-up.
        {
            tmr1 += Time.deltaTime;
            if(tmr1 >= tmr2)
            {
                CloseDialog();
                tmrOn = false;

            }
        }
    }


    /*
       How to use:

        reference this object's function OpenDialog(ID number). Each dialog has own unique
        ID number, see list for reference. Box will close itself if another messege is triggered.
        You can manually close the box by using CloseDialog().

        Please note that all public references needs to be assigned in the inspector.
        Canvas should be tagged "Canvas" just to avoid some random bugs.

    */

    public void OpenDialog(string ID)
    {
        var DialogDatabase = DDB.GetComponent<DialogDatabase>();

        if (!DialogDatabase.DialogsDict.ContainsKey(ID)) return;
        
        OutputText = DialogDatabase.DialogsDict[ID];
        if (box != null)
        {
            CloseDialog();
        }
        var Canvas = GameObject.FindGameObjectWithTag("Canvas");
        
        box = Instantiate(DialogBoxPrefab, Canvas.transform.position, Canvas.transform.rotation);
		box.transform.SetParent(Canvas.transform, true);
		box.transform.localScale = new Vector3(18.96987f, 2.226429f, 0.576515f); //this is just to fix some issue with scaling after parenting to canvas, please ignore.
        StopAllCoroutines();
        StartCoroutine(AnimateText(OutputText));
        box.transform.GetChild(0).gameObject.GetComponent<Text>().font = CurrentFont;
        box.GetComponent<Animator>().Play("MoveIn");
    }

    public void CloseDialog()
    {
        if (box == null)
        {
            return;
        }
        Destroy(box, 1);
        box.GetComponent<Animator>().Play("MoveOut");
        box = null;
    }

   

    


    public void OpenDialogTimeOut(string ID, float Time) //if necessery, you can trigger the dialog to last only for [Time] amount of time. (in seconds).
    {
        if (box != null)
        {
            CloseDialog();
        }
        var Canvas = GameObject.FindGameObjectWithTag("Canvas");
        OutputText = DDB.GetComponent<DialogDatabase>().DialogsDict[ID];
        box = Instantiate(DialogBoxPrefab, Canvas.transform.position, Canvas.transform.rotation);
		box.transform.SetParent(Canvas.transform, true);
		box.transform.localScale = new Vector3(18.96987f, 2.226429f, 0.576515f); //this is just to fix some issue with scaling after parenting to canvas, please ignore.
        StopAllCoroutines();
        StartCoroutine(AnimateText(OutputText));
        box.transform.GetChild(0).gameObject.GetComponent<Text>().font = CurrentFont;
        box.GetComponent<Animator>().Play("MoveIn");
        tmr2 = Time;
        tmrOn = true;
    }


    public void OpenDialogWithName(string ID, string Name)
    {
        if (box != null)
        {
            CloseDialog();
        }
        var Canvas = GameObject.FindGameObjectWithTag("Canvas");
        OutputText = DDB.GetComponent<DialogDatabase>().DialogsDict[ID];
        var CharacterName = Name;
        box = Instantiate(DialogBoxPrefab, Canvas.transform.position, Canvas.transform.rotation);
		box.transform.SetParent(Canvas.transform, true);
		box.transform.localScale = new Vector3(18.96987f, 2.226429f, 0.576515f); //this is just to fix some issue with scaling after parenting to canvas, please ignore.
        StopAllCoroutines();
        StartCoroutine(AnimateText(OutputText));
        box.transform.GetChild(0).gameObject.GetComponent<Text>().font = CurrentFont;
        box.transform.GetChild(1).gameObject.GetComponent<Text>().text = CharacterName;
        box.GetComponent<Animator>().Play("MoveIn");
    }

    public void SetFont(int FontIndex)
    {
        CurrentFont = TextFont[FontIndex];
    }

    private IEnumerator AnimateText(string DialogueText)
    {
        Text displayText = box.transform.GetChild(0).GetComponent<Text>();
        if (displayText == null)
            yield return null;
        string displayedtext = "";
        int currentDialogueIndex = 0;
        while (displayedtext != DialogueText)
        {
            displayedtext += DialogueText[currentDialogueIndex];
            displayText.text = displayedtext;
            currentDialogueIndex++;
            yield return new WaitForSeconds(textAnimatePauseTime);
        }
        yield return null;
    }
}
