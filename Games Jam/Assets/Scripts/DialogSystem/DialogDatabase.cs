using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogDatabase : MonoBehaviour
{

    public string[] Dialogs;

    public Dictionary<int, string> DialogsDict;



    private void Start()
    {
        DialogsDict.Add(0, "Messege 1");
        DialogsDict.Add(1, "Messege 2");
        DialogsDict.Add(2, "You get the idea.");
    }


}
