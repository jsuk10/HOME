using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using GameData;
using UnityEngine;
//Read로 읽어온 이후 LoadTable로 가지치기 한다.

/// <summary>
/// Data(T)를 지정해주고 세팅해줘야함 
/// singleton으로 구현되어있고 
/// OnInitiate에서 SetDictionary를 반드시 사용해야함.
/// </summary>
/// <typeparam name="T"> 하위클래스에서 구현한 추상 클래스</typeparam>
public abstract class Data<K, T> : NonUnitySingleton<K> where T : Data<K, T>.DataClass, new()
        where K : Data<K, T>, new(){
        #region Fields
    
        //위부터 구분자, 줄바꿈, 앞뒤로 없애는 문자 ("")
        static string SPLIT_RE = ",";
        static string LINE_SPLIT_RE = "\n";
        static char[] TRIM_CHARS = { '\"' };


        /// <summary>
        /// 딕셔너리가 들어 있는 테이블
        /// </summary>
        protected static Dictionary<int, T> table;

        /// <summary>
        /// 파일 이름을 추가할 경우 ParsingDataSet에 Enum을 추가한 뒤에 추가한다
        /// string로 줄 경우 실패할 가능성이 크기 때문에 미리정해진 값중 하나를 사용하도록 만들었다.
        ///  = ParsingDataSet.Dialog 사용할것
        /// </summary>
        protected static ParsingDataSet fileName;
    

        #endregion

        #region Class
        /// <summary>
        /// 자식이 구현해야 하는 추상 데이터 클래스
        /// 기본적으로 key값을 보유함
        /// </summary>
        public abstract class DataClass
        {
            protected int KEY;
        }

        #endregion

        #region Callbacks

        public override void Init()
        {
            ReadTable();
        }


        #endregion

        #region function
        /// <summary>
        /// .cvs에서 데이터를 읽어서 딕셔너리 형태로 반환해줌
        /// </summary>
        /// <param name="dataSet">파일이름에 해당한다. 잘못 읽을 가능성이 있으므로 ParsingDataSet에서 정의하고 줄것</param>
        /// <param name="path">데이터 파일이 들어있는 경로를 뜻한다 이 프로젝트에서는 "GameData/"가 기본</param>
        /// <returns>딕셔너리 파일을 반환해줌.</returns>
        public static Dictionary<int, Dictionary<string, string>> Read(ParsingDataSet dataSet, string path)
        {
            string fileName = dataSet.ToString();

            if (fileName == null)
            {
                Debug.Log("파일이 없습니다.");
                return null;
            }

            Dictionary<int, Dictionary<string, string>> list = new Dictionary<int, Dictionary<string, string>>();
            TextAsset data = Resources.Load<TextAsset>(path + fileName);
            if (data == null)
            {
                Debug.Log("파일이 비었습니다.");
                return null;
            }

            var lines = Regex.Split(data.text, LINE_SPLIT_RE);
            if (lines.Length <= 1) return list;
            string[] header = Regex.Split(lines[0], SPLIT_RE);
            for (var i = 1; i < lines.Length; i++)
            {
                string[] values = Regex.Split(lines[i], SPLIT_RE);
                if (values.Length == 0 || values[0] == "") continue;

                Dictionary<string, string> entry = new Dictionary<string, string>();
                int key = int.Parse(values[0]);
                for (var j = 0; j < header.Length && j < values.Length; j++)
                {
                    string value = values[j];
                    if (value == string.Empty)
                        continue;
                    value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("`", ",").Replace("+", "\n");
                    entry[header[j]] = value;
                    if (!list.ContainsKey(key))
                        list.Add(key, entry);
                }
            }
            return list;
        }

        /// <summary>
        /// 테이블을 읽을때 사용하는 클래스
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, T> LoadTable()
        {
            var result = new Dictionary<int, T>();
            //T의 데이터타입들을 읽어와서 저장함
            var tableDataType = typeof(T);
            var fields = tableDataType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            Dictionary<int, Dictionary<string, string>> parsedTable = Read(fileName, "GameData/");
            //테이블 마다 데이터를 조회해 연결하고 이를 반환함
            //맞는 데이터셋을 찾아서 들어감(T안에 포함된것만)
            foreach (var collectionPair in parsedTable)
            {
                var tableDataClass = new T();
                //key값은 int값, value는 Dictionary<string,string>이다.
                var tableKey = collectionPair.Key;
                var tableValue = collectionPair.Value;

                //테일블을 읽어서 키에는 키값을 매칭하고 다른값중 T에 속한 데이터면 삽입해줌
                for (int i = 0; i < fields.Length; i++)
                {
                    var fieldInfo = fields[i];
                    var fieldName = fieldInfo.Name;
                    var fieldType = fieldInfo.FieldType;
                    if (fieldName == "KEY")
                        fieldInfo.SetValue(tableDataClass, collectionPair.Key);
                    else if (tableValue.ContainsKey(fieldInfo.Name))
                    {
                        var value = tableValue[fieldName];
                        fieldInfo.SetValue(tableDataClass, value.DecodeType(fieldType));
                    }
                }
                //값을 가지고 있지 않으면 추가
                if (!result.ContainsKey(tableKey))
                    result.Add(tableKey, tableDataClass);
            }

            return result;
        }



        /// <summary>
        /// 테이블을 얻을때 사용함
        /// </summary>
        /// <returns>딕셔너리 타입으로 반환</returns>
        public Dictionary<int, T> GetTable() => table;

        /// <summary>
        /// 테이블 데이터를 얻을때 사용함
        /// </summary>
        /// <param name="key">키값에 매치되는 데이터를 뽑아줌</param>
        /// <example>GetTableData(2.2)</example>
        public T GetTableData(int key) => table[key];

        /// <summary>
        /// 초기에 테이블을 읽을때 사용
        /// </summary>
        public virtual void ReadTable()
        {
            if (table == null)
                table = LoadTable();
        }


        #endregion
}