//USINGS
using UnityEngine;
using System.Collections;
//CLASS
public class TestBehaviour : MonoBehaviour {
    //EVENT%{"type":"Start"}
    void Start () {
    //ENDEVENT%
    }
    //EVENT%{"type":"Update"}
    void Update () {
        //ACTION%{"type":"TransformTranslate", "x":1, "y":0, "z":0}
        transform.Translate(new Vector3(1, 0, 0));
    //ENDEVENT
	}
//ENDCLASS
}
