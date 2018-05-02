using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.command.impl;

public class GameViewInitiateCommand : Command {

    //[Inject]
    //public SlotView view { get; set; }
    
    public override void Execute() {
        Debug.Log("Hello world");
        //view.Init();
        // suppose to initiate everything
        
    }
}
