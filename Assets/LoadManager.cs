using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
public class LoadManager : MonoBehaviour
{
    IEnumerator Start()
    {
        AssetBundle asset = AssetBundle.LoadFromFile("Bundle/monster");
        if (asset != null) yield break;
        var ghoul = asset.LoadAsset<GameObject>("ghoul");
        var monster = Instantiate(ghoul);
        monster.transform.position = Vector3.zero;
        yield return new WaitUntil(() => IsDead(true));
        asset.Unload(true);
        Destroy(monster);
    }
    bool IsDead(bool check)
    {
        return check;
    }
}
