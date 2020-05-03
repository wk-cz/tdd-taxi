using System;
using System.Collections.Generic;
using System.Linq;

namespace tdd_taxi
{
    public class Schema
    {
        private List<SchemaData> schemaDatas;
        public Schema(string schmaConfig)
        {
            schemaDatas = new List<SchemaData>();
            schmaConfig.Split(',').ToList().ForEach(flag =>{
                var datas = flag.Split(':');
                SchemaData tempData = new SchemaData(datas[0], datas[1]);
                schemaDatas.Add(tempData);});
        }

        public object GetValue(string name, object value)
        {
            int iTemp = 0;
            string type = string.Empty;
            foreach (var tempData in schemaDatas) { if (0 == string.Compare(tempData.Type, name)) { type = tempData.Value; } }
            switch (type){
                case "int":
                    if (null != value && Int32.TryParse(value.ToString(), out iTemp)) { return iTemp; }
                    else { return null; }
                default:
                    return value;}
        }
    } 
}
