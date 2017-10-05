using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : TextController
{

	public GameObject[] unconditionalScripts;

    public GameObject[] yesScripts;
    public GameObject[] noScripts;

    public void Execute(GameObject agent, bool result)
    {
        base.runScripts(unconditionalScripts);

        if (result)
        {
            base.runScripts(yesScripts);
        } else
        {
            base.runScripts(noScripts);
        }



    }

}
