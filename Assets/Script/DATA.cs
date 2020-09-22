using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DATA : MonoBehaviour
{
    public int iNumber = -1;
    public int iClan = -1;
    public int iAge = -1;
    public int iLevel = -1;
    public int iFriend = -1;
    public int iRecommend = -1;

    public string GetOrder(int index)
    {
        if (index == iNumber)
            return "number";
        else if (index == iAge)
            return "age";
        else if (index == iClan)
            return "clan";
        else if (index == iLevel)
            return "level";
        else if (index == iFriend)
            return "friend";
        else if (index == iRecommend)
            return "recommend";
        else
            return "";
    }

    private object m_strName;
    private object m_strClan;
    private object m_iAge;
    private object m_iLevel;
    private object m_bFriend;
    private object m_bRecommend;

    public object Name { get { return m_strName; } set { m_strName = value; } }
    public object Clan { get { return m_strClan; } set { m_strClan = value; } }
    public object Age { get { return m_iAge; } set { m_iAge = value; } }
    public object Level { get { return m_iLevel; } set { m_iLevel = value; } }
    public object Friend { get { return m_bFriend; } set { m_bFriend = value; } }
    public object Recommend { get { return m_bRecommend; } set { m_bRecommend = value; } }
}
