//USINGS
using UnityEngine;
//CLASS
public class TestBehaviour : UniBehaviour {
    //EVENT%{"type":"Start"}
    void Start() {
        //ACTION%{"type":"Translate","x":0,"y":0,"z":0}
        transform.Translate(new Vector3(0,0,0));
        //ENDACTION
    //ENDEVENT
    }
    //EVENT%{"type":"Update"}
    protected override void Update() { base.Update();
        //ACTION%{"type":"Translate","x":0,"y":0,"z":0}
        transform.Translate(new Vector3(0,0,0));
        //ENDACTION
    //ENDEVENT
    }
//ENDCLASS
}
