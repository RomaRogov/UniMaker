//USINGS
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//CLASS
public class TestBehaviour : UniBehaviour {
    //PUBVAR%{"type"
    int score = 5;
    Dictionary<string,AudioClip> clipNames = new Dictionary<string, AudioClip>();
    //PRIVARS
    //EVENT%{"type":"Start"}
    void Start () {
    //ENDEVENT
    }
    //EVENT%{"type":"Update"}
    void Update () {
        //ACTION%{"type":"TransformTranslate", "x":1, "y":0, "z":0}
        transform.Translate(new Vector3(1, 0, 0));
        //ENDACTION
    //ENDEVENT
	}
//ENDCLASS
}
