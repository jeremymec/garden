using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : TextController {

    public GameObject[] attachedScripts;

    public void Execute()
    {
        base.runScripts(attachedScripts);
    }

}
