using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CSVReader : MonoBehaviour
{
    public string str_Filename;

    public List<Dictionary<string, object>> DataList = new List<Dictionary<string, object>>();

    private const string m_Default_Filename = "Data.csv";
    private static List<Dictionary<string, object>> ShareList = new List<Dictionary<string, object>>();

    void Awake()
    {
        ReadData(str_Filename);
        PrintData();
    }

    public List<Dictionary<string, object>> ReadData(string str_name = m_Default_Filename)
    {
        StreamReader sr = new StreamReader(Application.dataPath + "/" + str_Filename);

        if (sr.Peek() == 0)
            Debug.LogError("File doesn't exist");

        bool m_bIsEnd = false;
        bool m_bExample = true;
        bool m_friend = false;
        bool m_recommend = false;

        string[] m_Example = new string[3];

        while (!m_bIsEnd)
        {
            string str_Data = sr.ReadLine();
            if (str_Data == null)
            {
                m_bIsEnd = true;
                break;
            }

            if (m_bExample)
            {
                var var_Example = str_Data.Split(',');
                m_bExample = false;
                for (int i = 0; i < 3; i++)
                {
                    m_Example[i] = var_Example[i];
                }
            }

            var var_Value = str_Data.Split(',');
            var temp = new Dictionary<string, object>();

            if (m_Example[0] != var_Value[0])
            {
                m_friend = var_Value[1].Equals("1");
                m_recommend = var_Value[2].Equals("1");

                temp.Add(m_Example[0], var_Value[0]);
                temp.Add(m_Example[1], m_friend);
                temp.Add(m_Example[2], m_recommend);
                DataList.Add(temp);
            }
        }
        return DataList;
    }

    void PrintData(string _1 = "name", string _2 = "friend", string _3 = "recommend")
    {
        for (int i = 0; i < DataList.Count; i++)
        {
            Debug.Log(_1 + " : " + DataList[i][_1] + ", " + _2 + " : " + DataList[i][_2] + ", " + _3 + " : " + DataList[i][_3]);
        }
    }

    public List<Dictionary<string, object>> PushList()
    {
        ShareList = DataList;
        return ShareList;
    }
}
