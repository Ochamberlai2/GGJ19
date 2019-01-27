using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogDatabase : MonoBehaviour
{
    //System.Environment.NewLine
    // {"", ""},

        //NOTE: Change empty in: [Child name]

    public Dictionary<string, string> DialogsDict = new Dictionary<string, string>()
    {
        {"Test", "Test string it is."},
         {"Narrative1", "The source of our grief left behind." + System.Environment.NewLine + "Our journey to a new home entwined;"+ System.Environment.NewLine + "With him chasing us relentlessly."+ System.Environment.NewLine + "From our home we are resigned."},
        {"Narrative2", "Whose woods these are we think we know." + System.Environment.NewLine + "His home is in our minds now though;"+ System.Environment.NewLine + "He will not see us stopping here"+ System.Environment.NewLine + "To avail his woods ease our sorrow."},
        {"SleepWorriesAway1", "Our little boy must think it queer." +System.Environment.NewLine + "To stop without a safehouse near." +System.Environment.NewLine+ "Between the woods and frozen lake." +System.Environment.NewLine+ "His presence intimate our newest fears."},
        {"SleepWorriesAway2", "Our little boy has grown hungry." +System.Environment.NewLine+ "He must eat before we flee." +System.Environment.NewLine+ "Quick before the monter comes." +System.Environment.NewLine+ "To how us our sombre tragedy."},
        {"DruggedUp1", "He gives his bony limbs a shake"+System.Environment.NewLine+ "But there must be some mistake." +System.Environment.NewLine+ "The only other sound’s the sweep" +System.Environment.NewLine+ "Of easy wind and downy flake."},
        {"Depression1", "The waters are lovely, dark and deep," +System.Environment.NewLine+ "True I have promises to keep," +System.Environment.NewLine+ "But miles to go before I sleep," +System.Environment.NewLine+ "And miles to go while I weep."},
        {"MakeItHome2", "Whose woods these are we think we know" +System.Environment.NewLine+ "Our home is right over that hill though;" +System.Environment.NewLine+"He did not see us walking here" +System.Environment.NewLine+ "His woods have eased our sorrow"},


    };



}
