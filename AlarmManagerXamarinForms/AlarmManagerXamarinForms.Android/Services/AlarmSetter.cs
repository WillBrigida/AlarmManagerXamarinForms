using AlarmManagerXamarinForms.Droid.Services;
using AlarmManagerXamarinForms.Services;
using Android.App;
using Android.Content;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(AlarmSetter))]

namespace AlarmManagerXamarinForms.Droid.Services
{
    public class AlarmSetter : IAlarmSetter
    {
        AlarmManager alarmManager = (AlarmManager)Forms.Context.GetSystemService(Context.AlarmService);
        Intent alarmIntent = new Intent(Forms.Context, typeof(AlarmReceiver));
        public void SetAlarm()
        {

            //Java.Util.Calendar calendar = Java.Util.Calendar.Instance;
            //calendar.Set(Java.Util.CalendarField.HourOfDay, 20);
            //calendar.Set(Java.Util.CalendarField.Minute, 00);
            //calendar.Set(Java.Util.CalendarField.Second, 0);

            alarmIntent.PutExtra("title", "Título da Mensagem");
            alarmIntent.PutExtra("message", "Mensagem");
            alarmIntent.SetFlags(ActivityFlags.IncludeStoppedPackages);
            var pendingIntent = PendingIntent.GetBroadcast(Forms.Context, 0, alarmIntent, PendingIntentFlags.UpdateCurrent);

            //Envia a mensagem e repe a cada 1 minuto (60000)
            alarmManager.SetRepeating(AlarmType.RtcWakeup, Java.Lang.JavaSystem.CurrentTimeMillis(), 60000, pendingIntent);

        }

        public void DeleteAlarm()
        {
            //Cancela a mensagem
            alarmIntent.SetFlags(ActivityFlags.IncludeStoppedPackages);
            var pendingIntent = PendingIntent.GetBroadcast(Forms.Context, 0, alarmIntent, PendingIntentFlags.UpdateCurrent);
            alarmManager.Cancel(pendingIntent);
        }
    }
}