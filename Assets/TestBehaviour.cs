//USINGS
using UnityEngine;
//CLASS
public class TestBehaviour : UniBehaviour {
    //EVENT%{"type":"LeftKeyPressed","args":[]}
    protected override void LeftKeyPressed() {
        //ACTION%{"type":"Translate","x":-0.1,"y":0,"z":0}
        transform.Translate(new Vector3(-0.1f,0f,0f));
        //ENDACTION
    //ENDEVENT
    }
    //EVENT%{"type":"RightKeyPressed"}
    protected override void RightKeyPressed() {
        //ACTION%{"type":"Translate","x":0.1,"y":0,"z":0}
        transform.Translate(new Vector3(0.1f,0f,0f));
        //ENDACTION
    //ENDEVENT
    }
    //EVENT%{"type":"UpKeyPressed"}
    protected override void UpKeyPressed() {
        //ACTION%{"type":"Translate","x":0,"y":0.1,"z":0}
        transform.Translate(new Vector3(0f,0.1f,0f));
        //ENDACTION
    //ENDEVENT
    }
    //EVENT%{"type":"DownKeyPressed"}
    protected override void DownKeyPressed() {
        //ACTION%{"type":"Translate","x":0,"y":-0.1,"z":0}
        transform.Translate(new Vector3(0f,-0.1f,0f));
        //ENDACTION
    //ENDEVENT
    }
//ENDCLASS
}
