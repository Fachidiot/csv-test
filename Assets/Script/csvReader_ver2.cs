using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class csvReader_ver2 : MonoBehaviour
{
    public string str_Filename;
    
    private List<Dictionary<object, object>> DataList = new List<Dictionary<object, object>>();
    private const string m_Default_Filename = "Resource/Data.csv";
    private static List<Dictionary<object, object>> m_ShareList = new List<Dictionary<object, object>>();
    private int m_iIndex = 0;

    void Awake()
    {
        m_ShareList = ReadData(str_Filename);
        PrintData();
    }

    public List<Dictionary<object, object>> ReadData(string str_name = m_Default_Filename)
    {
        StreamReader sr = new StreamReader(Application.dataPath + "/" + str_Filename);

        if (sr.Peek() == 0)
            Debug.LogError("File doesn't exist");
        //=========================================
        bool m_bIsEnd = false;
        bool m_bExample = true;
        // DATA TempData = this.gameObject.AddComponent<DATA>();
        DATA TempData = new DATA();

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
                TempData.Name = var_Example[0];
                TempData.Level = var_Example[1];
                TempData.Clan = var_Example[2];
                TempData.Friend = var_Example[3];
                TempData.Recommend = var_Example[4];
                m_bExample = false;
            }
            else
            {
                var var_Value = str_Data.Split(',');
                var temp = new Dictionary<object, object>();

                if (var_Value[0] == "")
                    temp.Add(TempData.Name, "null");
                else
                    temp.Add(TempData.Name, var_Value[0]);
                if (var_Value[1] == "")
                    temp.Add(TempData.Level, "null");
                else
                    temp.Add(TempData.Level, var_Value[1]);
                if (var_Value[2] == "")
                    temp.Add(TempData.Clan, "null");
                else
                    temp.Add(TempData.Clan, var_Value[2]);
                if (var_Value[3] == "0")
                    temp.Add(TempData.Friend, "false");
                else
                    temp.Add(TempData.Friend, "true");
                if (var_Value[4] == "0")
                    temp.Add(TempData.Recommend, "false");
                else
                    temp.Add(TempData.Recommend, "true");
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

    public List<Dictionary<object, object>> PushList()
    {
        m_ShareList = DataList;
        return m_ShareList;
    }
}
