﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreHardwareMonitor.Hardware;
using OpenHardwareMonitor.Hardware;

namespace FanCtrl
{
    public class NvAPITemp : BaseSensor
    {
        public delegate int OnGetNvAPITemperatureHandler(int index);

        public event OnGetNvAPITemperatureHandler onGetNvAPITemperatureHandler;

        private int mIndex = -1;

        public NvAPITemp(string id, string name, int index) : base(LIBRARY_TYPE.NvAPIWrapper)
        {
            ID = id;
            Name = name;
            mIndex = index;
        }

        public override string getString()
        {
            if (OptionManager.getInstance().IsFahrenheit == true)
                return Util.getFahrenheit(Value) + " °F";
            else
                return Value + " °C";
        }
        public override void update()
        {
            Value = onGetNvAPITemperatureHandler(mIndex);
        }
    }
}
