using AlarmManagerXamarinForms.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace AlarmManagerXamarinForms.ViewModels
{
    public class MainViewMoldel
    {
        public ICommand SetNotificationCommand => new Command(OnSetNotification);
        public ICommand DeleteNotificationCommand => new Command(OnDeleteNotification);


        private void OnSetNotification()
        {
            Xamarin.Forms.DependencyService.Get<IAlarmSetter>().SetAlarm();
        }

        private void OnDeleteNotification()
        {
            Xamarin.Forms.DependencyService.Get<IAlarmSetter>().DeleteAlarm();
        }
    }
}
