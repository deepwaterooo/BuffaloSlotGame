using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.command.impl;

namespace Game {
    public class HelloWorldStartCommand : Command {
        public override void Execute() {
            Debug.Log("Hello world");
        }
    }
}
