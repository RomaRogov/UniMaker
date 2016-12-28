//USINGS
using UnityEngine;
//CLASS
public class TestBehaviour : UniBehaviour {
    //EVENT%{"type":"LeftKeyPressed","args":[]}
    protected override void LeftKeyPressed() {
        //ACTION%{"type":"Translate","x":"GameObject.Find("Cube").transform.localScale.x","y":"0","z":"0"}
        transform.Translate(new Vector3((float)GameObject.Find("Cube").transform.localScale.x,(float)0,(float)0));
        //ENDACTION
    //ENDEVENT
    }
    //EVENT%{"type":"RightKeyPressed"}
    protected override void RightKeyPressed() {
        //ACTION%{"type":"Translate","x":"0","y":"0","z":"0"}
        transform.Translate(new Vector3((float)0,(float)0,(float)0));
        //ENDACTION
    //ENDEVENT
    }
    //EVENT%{"type":"UpKeyPressed"}
    protected override void UpKeyPressed() {
        //ACTION%{"type":"Translate","x":"0","y":"0","z":"0"}
        transform.Translate(new Vector3((float)0,(float)0,(float)0));
        //ENDACTION
    //ENDEVENT
    }
    //EVENT%{"type":"DownKeyPressed"}
    protected override void DownKeyPressed() {
        //ACTION%{"type":"Translate","x":"0","y":"0","z":"0"}
        transform.Translate(new Vector3((float)0,(float)0,(float)0));
        //ENDACTION
    //ENDEVENT
    }
//ENDCLASS
}
