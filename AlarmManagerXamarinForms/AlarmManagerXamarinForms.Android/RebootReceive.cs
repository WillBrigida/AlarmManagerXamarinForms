using Android.App;
using Android.Content;

namespace AlarmManagerXamarinForms.Droid
{
    [BroadcastReceiver]
    [IntentFilter(new string[] { "android.intent.action.BOOT_COMPLETED" }, Priority = (int)IntentFilterPriority.LowPriority)]
    public class RebootReceive : BroadcastReceiver
    {

        //Caso o smatphone seja reiniciado, é preciso fazer um novo agendamento para o envio das notificações.
        
        private static string ACTION_START_NOTIFICATION_SERVICE = "ACTION_START_NOTIFICATION_SERVICE";

        public override void OnReceive(Context context, Intent intent)
        {
            AlarmManager alarmManager = (AlarmManager)context.GetSystemService(Context.AlarmService);
            PendingIntent alarmIntent = GetStartPendingIntent(context);
            alarmManager.SetRepeating(AlarmType.RtcWakeup, Java.Lang.JavaSystem.CurrentTimeMillis(), 60000, alarmIntent);
        }

        private static PendingIntent GetStartPendingIntent(Context context)
        {
            //var bd = new Repository<Scheduling>().GetAll().FirstOrDefault();
            Intent intent = new Intent(context, typeof(AlarmReceiver));
            intent.PutExtra("title", "Titulo Mensagem reboot");
            intent.PutExtra("message", "Mensagem");
            intent.SetAction(ACTION_START_NOTIFICATION_SERVICE);
            return PendingIntent.GetBroadcast(context, 0, intent, PendingIntentFlags.UpdateCurrent);
        }
    }
}