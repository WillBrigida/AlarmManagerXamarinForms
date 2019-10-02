using System;
using System.Collections.Generic;
using System.Text;

namespace AlarmManagerXamarinForms.Services
{
    public interface IAlarmSetter
    {
        void DeleteAlarm();
        void SetAlarm();
    }
}
