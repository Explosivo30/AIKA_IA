using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateWorld : MonoBehaviour
{
    public Text states;

    private void Update()
    {
        
    }

    private void LateUpdate()
    {
        Dictionary<string, int> worldState = GWorld.Instance.GetWorld().GetStates();
        states.text = "";
        foreach (KeyValuePair<string, int> s in worldState)
        {
            states.text += s.Key + ", " + s.Value + " \n";
        }
    }
}
