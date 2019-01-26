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
        {"Narrative1", "One dreary midnight the Frost family were shaken by the foundations of their home. " + System.Environment.NewLine + "Unable to prevent the monster harassing them, they ran and abandoned their home."},
        {"SleepWorriesAway1", "Whose woods these are I think I know." +System.Environment.NewLine + "His home is in our minds though;" +System.Environment.NewLine+ "He will not see us stopping here" +System.Environment.NewLine+ "To watch his woods fill up with sorrow."},
        {"SleepWorriesAway2", "Our little babe must think it queer" +System.Environment.NewLine+ "To stop without a farmhouse near" +System.Environment.NewLine+ "Between the woods and frozen lake" +System.Environment.NewLine+ "The darkest evening of the year."},
        {"DruggedUp1", "Poor [child name]’s stomach was empty. His parents ached, remembering the last hungry winter. He would need some food if they hoped to make it home. "},
        {"DruggedUp2", "He gives his harness bells a shake"+System.Environment.NewLine+ "To ask if there is some mistake." +System.Environment.NewLine+ "The only other sound’s the sweep" +System.Environment.NewLine+ "Of easy wind and downy flake."},
        {"Depression1", "The Frosts reached the end of their journey. Tired, hungry, and lost they knew it was over. Too much had happened to them. The place they once called home was long gone."},
        {"Depression2", "The waters are lovely, dark and deep," +System.Environment.NewLine+ "True I have promises to keep," +System.Environment.NewLine+ "But miles to go before I sleep," +System.Environment.NewLine+ "And miles to go while I weep."},
        {"MakeItHome1", "The Frosts crossed the river tentatively. The freezing waters below beckoned with icy fingers. They made it to safety, the screams of the monster fading behind them as their home came into view."},
        {"MakeItHome2", "Whose woods these are I think I know" +System.Environment.NewLine+ "Our home is just over that hill though;" +System.Environment.NewLine+"He did not see us walking here" +System.Environment.NewLine+ "His woods have healed our sorrow"},


    };



}
