using System;
using UnityEngine;
using strange.extensions.context.impl;

// follow another example: http://www.cnblogs.com/hammerc/p/4743070.html
// or http://www.cnblogs.com/funyuto/p/4143790.html

public class SlotsRoot : ContextView {

    void Awake() {
        context = new SlotsContext(this);
    }
}
