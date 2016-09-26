//USINGS
using UnityEngine;
//CLASS
public class TestBehaviour : UniBehaviour {
    //EVENT%{"type":"Start","args":[]}
    void Start() {
        //ACTION%{"type":"Translate","x":0,"y":0,"z":0}
        transform.Translate(new Vector3(0,0,0));
        //ENDACTION
    //ENDEVENT
    }
    //EVENT%{"type":"KeyPressed","args":["KeyCode.LeftArrow"]}
    protected override void KeyPressed(KeyCode which) { if (which != KeyCode.LeftArrow) { return; }
        //ACTION%{"type":"Translate","x":0,"y":0,"z":0}
        transform.Translate(new Vector3(0,0,0));
        //ENDACTION
    //ENDEVENT
    }
//ENDCLASS
}
