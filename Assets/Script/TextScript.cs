using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    //public CSVReader csv_reader;
    public csvReader_ver2 csv_reader;
    public bool b_Name;
    public bool b_Friend;
    public bool b_Recommend;
    public Text t_Text;
    
    private List<Dictionary<object, object>> m_ShareList = new List<Dictionary<object, object>>();
    private static int m_iIndex = 0;

    void Start()
    {
        m_ShareList = csv_reader.PushList();
        if (m_ShareList.Count <= 0)
            Debug.LogError("DataList Doesn't Exist");

        m_iIndex = 0;

        SetData();
    }

    private void Update()
    {
        SetData();
    }

    void SetData()
    {
        if (b_Name)
            ListLoad(m_iIndex, "name");
        else if (b_Friend)
            ListLoad(m_iIndex, "friend");
        else
            ListLoad(m_iIndex, "recommend");
    }

    public void IndexUp()
    {
        if (m_iIndex == m_ShareList.Count - 1)
            return;
        m_iIndex++;
    }

    public void IndexDown()
    {
        if (m_iIndex <= 0)
            return;
        m_iIndex--;
    }

    void ListLoad(int index, string str_Type)
    {
        t_Text.text = m_ShareList[index][str_Type].ToString();
    }

    public void FindName(string str_name)
    {
        for (int i = 0; i < m_ShareList.Count; i++)
        {
            if (str_name == m_ShareList[i]["name"].ToString())
            {
                m_iIndex = i;
                return;
            }
        }

        Debug.Log("That Name doesn't exist");
    }
}
