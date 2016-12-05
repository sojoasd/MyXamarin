using System;
using Android.App;
using Android.Content;
using Android.OS;
using System.Threading;
using Android.Support.V4.App;

namespace App5.Droid
{
    [Service(Enabled = true)]
    public class TimerService : Service
    {
        static readonly int TimerWait = 3000;
        Timer _timer;

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        //這邊是這樣寫嗎?
        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            StartService(new Intent(this, typeof(TimerService)));

            return StartCommandResult.Sticky;
        }

        public override void OnCreate()
        {
            base.OnCreate();

            //每 3 秒收到一次通知，顯示現在時間
            _timer = new Timer(o =>
            {
                createNotification("NotifyTitle", DateTime.UtcNow.ToString());

            }, null, 0, TimerWait);
        }

        void createNotification(string title, string desc)
        {
            var notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;

            var uiIntent = new Intent(this, typeof(MainActivity));

            NotificationCompat.Builder builder = new NotificationCompat.Builder(this);

            var notification = builder
                    .SetContentIntent(PendingIntent.GetActivity(this, 0, uiIntent, 0))
                    .SetSmallIcon(Android.Resource.Drawable.SymActionChat)
                    .SetTicker(title)
                    .SetContentTitle(title)
                    .SetContentText(desc)
                    .SetAutoCancel(true)
                    .Build();

            //Show the notification
            notificationManager.Notify(1, notification);
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}