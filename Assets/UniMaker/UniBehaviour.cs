using UnityEngine;
using System;
using System.Collections;

public class UniBehaviour : MonoBehaviour
{
    private bool keyWasPressed = false;

    protected virtual void Update()
    {
        //Handle KeyPressed
        if (Input.GetKey(KeyCode.LeftArrow)) { LeftKeyPressed(); }
        if (Input.GetKey(KeyCode.RightArrow)) { RightKeyPressed(); }
        if (Input.GetKey(KeyCode.UpArrow)) { UpKeyPressed(); }
        if (Input.GetKey(KeyCode.DownArrow)) { DownKeyPressed(); }

        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) { CtrlKeyPressed(); }
        if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) { AltKeyPressed(); }
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) { ShiftKeyPressed(); }
        if (Input.GetKey(KeyCode.Space)) { SpaceKeyPressed(); }
        if (Input.GetKey(KeyCode.Return)) { EnterKeyPressed(); }

        if (Input.GetKey(KeyCode.Backspace)) { BackspaceKeyPressed(); }
        if (Input.GetKey(KeyCode.Escape)) { EscapeKeyPressed(); }
        if (Input.GetKey(KeyCode.Home)) { HomeKeyPressed(); }
        if (Input.GetKey(KeyCode.End)) { EndKeyPressed(); }
        if (Input.GetKey(KeyCode.PageUp)) { PageUpKeyPressed(); }
        if (Input.GetKey(KeyCode.PageDown)) { PageDownKeyPressed(); }
        if (Input.GetKey(KeyCode.Delete)) { DeleteKeyPressed(); }
        if (Input.GetKey(KeyCode.Insert)) { InsertKeyPressed(); }

        if (Input.anyKey) { AnyKeyPressed(); } else { NoKeyPressed(); }

        //Handle KeyDown
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { LeftKeyDown(); }
        if (Input.GetKeyDown(KeyCode.RightArrow)) { RightKeyDown(); }
        if (Input.GetKeyDown(KeyCode.UpArrow)) { UpKeyDown(); }
        if (Input.GetKeyDown(KeyCode.DownArrow)) { DownKeyDown(); }

        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) { CtrlKeyDown(); }
        if (Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) { AltKeyDown(); }
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) { ShiftKeyDown(); }
        if (Input.GetKeyDown(KeyCode.Space)) { SpaceKeyDown(); }
        if (Input.GetKeyDown(KeyCode.Return)) { EnterKeyDown(); }

        if (Input.GetKeyDown(KeyCode.Backspace)) { BackspaceKeyDown(); }
        if (Input.GetKeyDown(KeyCode.Escape)) { EscapeKeyDown(); }
        if (Input.GetKeyDown(KeyCode.Home)) { HomeKeyDown(); }
        if (Input.GetKeyDown(KeyCode.End)) { EndKeyDown(); }
        if (Input.GetKeyDown(KeyCode.PageUp)) { PageUpKeyDown(); }
        if (Input.GetKeyDown(KeyCode.PageDown)) { PageDownKeyDown(); }
        if (Input.GetKeyDown(KeyCode.Delete)) { DeleteKeyDown(); }
        if (Input.GetKeyDown(KeyCode.Insert)) { InsertKeyDown(); }

        if (Input.anyKeyDown) { AnyKeyDown(); } else { NoKeyDown(); }

        //Handle KeyUp
        if (Input.GetKeyUp(KeyCode.LeftArrow)) { LeftKeyUp(); }
        if (Input.GetKeyUp(KeyCode.RightArrow)) { RightKeyUp(); }
        if (Input.GetKeyUp(KeyCode.UpArrow)) { UpKeyUp(); }
        if (Input.GetKeyUp(KeyCode.DownArrow)) { DownKeyUp(); }

        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) { CtrlKeyUp(); }
        if (Input.GetKeyUp(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) { AltKeyUp(); }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) { ShiftKeyUp(); }
        if (Input.GetKeyUp(KeyCode.Space)) { SpaceKeyUp(); }
        if (Input.GetKeyUp(KeyCode.Return)) { EnterKeyUp(); }

        if (Input.GetKeyUp(KeyCode.Backspace)) { BackspaceKeyUp(); }
        if (Input.GetKeyUp(KeyCode.Escape)) { EscapeKeyUp(); }
        if (Input.GetKeyUp(KeyCode.Home)) { HomeKeyUp(); }
        if (Input.GetKeyUp(KeyCode.End)) { EndKeyUp(); }
        if (Input.GetKeyUp(KeyCode.PageUp)) { PageUpKeyUp(); }
        if (Input.GetKeyUp(KeyCode.PageUp)) { PageDownKeyUp(); }
        if (Input.GetKeyUp(KeyCode.Delete)) { DeleteKeyUp(); }
        if (Input.GetKeyUp(KeyCode.Insert)) { InsertKeyUp(); }

        if (keyWasPressed && !Input.anyKey) { AnyKeyUp(); } else { NoKeyUp(); }
        
        keyWasPressed = Input.anyKey;
    }

    /* KEY PRESSED EVENTS */
    protected virtual void LeftKeyPressed() { }
    protected virtual void RightKeyPressed() { }
    protected virtual void UpKeyPressed() { }
    protected virtual void DownKeyPressed() { }

    protected virtual void CtrlKeyPressed() { }
    protected virtual void AltKeyPressed() { }
    protected virtual void ShiftKeyPressed() { }
    protected virtual void SpaceKeyPressed() { }
    protected virtual void EnterKeyPressed() { }

    protected virtual void BackspaceKeyPressed() { }
    protected virtual void EscapeKeyPressed() { }
    protected virtual void HomeKeyPressed() { }
    protected virtual void EndKeyPressed() { }
    protected virtual void PageUpKeyPressed() { }
    protected virtual void PageDownKeyPressed() { }
    protected virtual void DeleteKeyPressed() { }
    protected virtual void InsertKeyPressed() { }

    protected virtual void AnyKeyPressed() { }
    protected virtual void NoKeyPressed() { }

    /* KEY DOWN EVENTS */
    protected virtual void LeftKeyDown() { }
    protected virtual void RightKeyDown() { }
    protected virtual void UpKeyDown() { }
    protected virtual void DownKeyDown() { }

    protected virtual void CtrlKeyDown() { }
    protected virtual void AltKeyDown() { }
    protected virtual void ShiftKeyDown() { }
    protected virtual void SpaceKeyDown() { }
    protected virtual void EnterKeyDown() { }

    protected virtual void BackspaceKeyDown() { }
    protected virtual void EscapeKeyDown() { }
    protected virtual void HomeKeyDown() { }
    protected virtual void EndKeyDown() { }
    protected virtual void PageUpKeyDown() { }
    protected virtual void PageDownKeyDown() { }
    protected virtual void DeleteKeyDown() { }
    protected virtual void InsertKeyDown() { }

    protected virtual void AnyKeyDown() { }
    protected virtual void NoKeyDown() { }

    /* KEY UP EVENTS */
    protected virtual void LeftKeyUp() { }
    protected virtual void RightKeyUp() { }
    protected virtual void UpKeyUp() { }
    protected virtual void DownKeyUp() { }

    protected virtual void CtrlKeyUp() { }
    protected virtual void AltKeyUp() { }
    protected virtual void ShiftKeyUp() { }
    protected virtual void SpaceKeyUp() { }
    protected virtual void EnterKeyUp() { }

    protected virtual void BackspaceKeyUp() { }
    protected virtual void EscapeKeyUp() { }
    protected virtual void HomeKeyUp() { }
    protected virtual void EndKeyUp() { }
    protected virtual void PageUpKeyUp() { }
    protected virtual void PageDownKeyUp() { }
    protected virtual void DeleteKeyUp() { }
    protected virtual void InsertKeyUp() { }

    protected virtual void AnyKeyUp() { }
    protected virtual void NoKeyUp() { }
}
