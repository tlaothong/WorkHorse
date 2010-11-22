using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using PerfEx.Infrastructure.LotUpdate;

namespace SimpleNotif.Views
{
    public partial class SimpleChat : Page
    {
        public SimpleChat()
        {
            InitializeComponent();

            //svc.SendMessageCompleted += new EventHandler<OhSimpleSvc.SendMessageCompletedEventArgs>(svc_SendMessageCompleted);
            _tracker = new StatusTracker();
            _tracker.Initialize(new Uri("http://localhost:49491/LatestLotNo.ashx", UriKind.Absolute));

            OhSimpleSvc.IOhSimpleService oss = svc;

            _sendMsg = Observable.FromAsyncPattern<string, Guid>(
                oss.BeginSendMessage, oss.EndSendMessage);
        }

        private Func<string, IObservable<Guid>> _sendMsg;
        private IStatusTracker _tracker;
        OhSimpleSvc.OhSimpleServiceClient svc = new OhSimpleSvc.OhSimpleServiceClient();

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //MessageBox.Show("Hello");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var id = Guid.NewGuid();
            svc.SendInfoAsync(id, textBox1.Text);

            IStatusTracker tracker = _tracker;

            SimpleTrackingObserver obs = new SimpleTrackingObserver();

            IDisposable dsp = null;
            dsp = tracker.Watch(obs).SubscribeOnDispatcher().Subscribe(
                nx =>
                {
                    var info = new { nx.LotNo, nx.Status };
                    //MessageBox.Show(info.ToString());
                    listBox1.Items.Add(info);
                }
                , ex => { MessageBox.Show(ex.ToString()); }
                , () => { MessageBox.Show("???"); dsp.Dispose(); });
            obs.Initialize(tracker);
            obs.SetTrackingID(id);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            SimpleTrackingObserver obs = new SimpleTrackingObserver();
            obs.Initialize(_tracker);
            IDisposable dsp = null;

            dsp = _tracker.Watch(obs).SubscribeOnDispatcher().Subscribe(
                nx =>
                {
                    var info = new { nx.LotNo, nx.Status };
                    //MessageBox.Show(info.ToString());
                    listBox1.Items.Add(info);
                }
                , ex => { MessageBox.Show(ex.ToString()); }
                , () => { MessageBox.Show("???"); dsp.Dispose(); });

            ////svc.SendMessageAsync(textBox1.Text, obs);
            IDisposable mdsp = null;
            mdsp = _sendMsg.Invoke(textBox1.Text).Subscribe(
                nx => {
                    obs.SetTrackingID(nx);
                    mdsp.Dispose();
                },
                erx => {
                    MessageBox.Show(erx.ToString());
                },
                () => {
                });
        }

        //void svc_SendMessageCompleted(object sender, OhSimpleSvc.SendMessageCompletedEventArgs e)
        //{
        //    var id = e.Result;
        //    var obs = e.UserState as SimpleTrackingObserver;
        //    obs.SetTrackingID(id);
        //}
    }
}
