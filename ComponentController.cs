using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Controls the components in the object by 

public class ComponentController : MonoBehaviour
{
    public Component[] components;   

	public void DisableAllComponents()
    {
        foreach(MonoBehaviour script in components)
        {
            script.enabled = false;
        }
    }

    public void EnableAllComponents()
    {
        foreach(MonoBehaviour script in components)
        {
            script.enabled = true;
        }
    }

    public void EnableComponents(int[] _indices)
    {
        for(int c = 0; c < components.Length; c++)
        {
            for(int i = 0; i < _indices.Length; i++)
            {
                if(c == _indices[i])
                {
                    int index = 0;
                    foreach(MonoBehaviour script in components)
                    {
                        if(index == c)
                        {
                            script.enabled = true;
                        }
                        else
                        {
                            index++;
                        }
                    }
                    break;
                }
            }
        }
    }

    public void EnableComponent(int _index)
    {
        int index = 0;
        foreach(MonoBehaviour script in components)
        {
            if(index == _index)
            {
                script.enabled = true;
            }
            else
            {
                index++;
            }
        }
    }

    public void DisableComponents(int[] _indices)
    {
        for (int c = 0; c < components.Length; c++)
        {
            for (int i = 0; i < _indices.Length; i++)
            {
                if (c == _indices[i])
                {
                    int index = 0;
                    foreach (MonoBehaviour script in components)
                    {
                        if (index == c)
                        {
                            script.enabled = false;
                        }
                        else
                        {
                            index++;
                        }
                    }
                    break;
                }
            }
        }
    }

    public void DisableComponent(int _index)
    {
        int index = 0;
        foreach (MonoBehaviour script in components)
        {
            if (index == _index)
            {
                script.enabled = false;
            }
            else
            {
                index++;
            }
        }
    }
}
