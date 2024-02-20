using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour
{
    public static readonly WaitForFixedUpdate m_WaitForFixedUpdate = new WaitForFixedUpdate();
    public static readonly WaitForEndOfFrame m_WaitForEndOfFrame = new WaitForEndOfFrame();
    private static readonly Dictionary<float, WaitForSeconds> m_WaitForSecondsDict = new Dictionary<float, WaitForSeconds>();

    public static WaitForSeconds WaitForSecond(float waitTime)
    {
        WaitForSeconds wfs;

        if (m_WaitForSecondsDict.TryGetValue(waitTime, out wfs)) return wfs;
        else
        {
            wfs = new WaitForSeconds(waitTime);
            m_WaitForSecondsDict.Add(waitTime, wfs);
            return wfs;
        }
    }
}