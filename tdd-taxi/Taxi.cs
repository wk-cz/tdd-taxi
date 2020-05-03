using System;
using System.Linq;

namespace tdd_taxi
{
    public class Taxi
    {
        private Schema schema;
        private Command command;

        public Taxi(string schema, string command)
        {
            this.schema = new Schema(schema);
            this.command = new Command(command);
        }

        public object GetValue(string name)
        {
            return schema.GetValue(name, command.GetValue(name));
        }

        public int GetTaxiMeterResult(string command)
        {
            this.command = new Command(command);

            int ret = -1;
            int iTemp = 0;
            int M = 0;
            int T = 0;

            var value = GetValue("M");
            if (null != value && Int32.TryParse(value.ToString(), out iTemp))
            {
                M = iTemp;
            }

            value = GetValue("T");
            if (null != value && Int32.TryParse(value.ToString(), out iTemp))
            {
                T = iTemp;
            }
            ret = Convert.ToInt32(Math.Round(calMileage(M) + calTime(T), 0, MidpointRounding.AwayFromZero));
            return ret;
        }

        private double calMileage(int mileage)
        {
            double ret = 0d;
            if (mileage > 0)
            {
                if (mileage <= 2)
                {
                    ret = 6; 
                }
                else if (mileage > 2 && mileage <= 8)
                {
                    ret = 6 + (mileage - 2) * 0.8;
                }
                else if (mileage > 8)
                {
                    ret = 6 + (mileage - 2) * 0.8 + (mileage - 8) * 0.4;
                }
            }
            return ret;
        }
        private double calTime(int time)
        {
            double ret = 0d;
            if(time > 0)
            {
                ret = time * 0.25;
            }
            return ret;
        }
    }
}
