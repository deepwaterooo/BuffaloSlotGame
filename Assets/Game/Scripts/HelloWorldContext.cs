using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
    public class HelloWorldContext : SignalContext {
        public HelloWorldContext(MonoBehaviour contextView) : base(contextView) {
            
        }

        protected override void mapBindings() {
            base.mapBindings();

            // we bind a command to StartSignal since it is invoked by SignalContext (the parent class) during on Launch()
            commandBinder.Bind<StartSignal>().To<HelloWorldStartCommand>().Once();
            commandBinder.Bind<DoManagementSignal>().To<DoManagementCommand>().Pooled(); // new mapping

            // bind our view to its mediator
            mediationBinder.Bind<HelloWorldView>().To<HelloWorldMediator>();

            // bind our interface to a concrete implementation
            //injectionBinder.Bind<ISomeManager>().To<ManagerAsNormalClass>().ToSingleton();
            // Monobehaviour way of binding, istead: 
            ManagerAsMonobehaviour manager = GameObject.Find("Manager").GetComponent<ManagerAsMonobehaviour>();
            injectionBinder.Bind<ISomeManager>().ToValue(manager);
        } 
    }
    
}
