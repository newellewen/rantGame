using Rant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralTextAdventure
{
    public class Character
    {
        public Character(int _characterId)
        {
            characterId = _characterId;
            nameVar = "char" + _characterId.ToString() + "name";
            hairColorVar = "char" + _characterId.ToString() + "haircolor";
            actionVar = "char" + _characterId.ToString() + "action";
            actionItemVar = "char" + _characterId.ToString() + "actionitem";

            RantProgram setName = RantProgram.CompileString(@"[vs:" + nameVar + ";<name>]");
            RantProgram setHairColor = RantProgram.CompileString(@"[vs:" + hairColorVar + ";<adj-color>]");
            RantProgram setAction = RantProgram.CompileString(@"[vs:" + actionVar + ";<verb>]");
            RantProgram setActionItem = RantProgram.CompileString(@"[vs:" + actionItemVar + ";<noun>]");

            rantEngine.Do(setName);
            rantEngine.Do(setHairColor);
            rantEngine.Do(setAction);
            rantEngine.Do(setActionItem);

            RantProgram getName = RantProgram.CompileString("[v:" + nameVar + "]");
            RantProgram getHairColor = RantProgram.CompileString("[v:" + hairColorVar + "]");
            RantProgram getAction = RantProgram.CompileString("[v:" + actionVar + "]");
            RantProgram getActionItem = RantProgram.CompileString("[v:" + actionItemVar + "]");

            name = rantEngine.Do(getName).Main;
            hairColor = rantEngine.Do(getHairColor).Main;
            action = rantEngine.Do(getAction).Main; 
            actionItem = rantEngine.Do(getActionItem).Main;             
        }

        private int characterId;

        private string nameVar;
        public string name;
        
        private string hairColorVar;
        public string hairColor;
        
        private string actionVar;
        public string action;

        private string actionItemVar;
        public string actionItem;

        private RantEngine rantEngine = RantLoader.StartEngine(); 
    }
}
