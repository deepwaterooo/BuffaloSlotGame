using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.context.impl;

namespace Game {
    public class HelloWorldBootstrap : ContextView {

        void Awake() {
            this.context = new HelloWorldContext(this);
        }
    }
}
