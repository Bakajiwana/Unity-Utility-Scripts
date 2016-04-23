using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UISelectOnEnable : MonoBehaviour
{
    void OnEnable()
    {
        gameObject.GetComponent<Button>().onClick.Invoke ();
    }	
}
