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

namespace BasicSilverClient
{
    public partial class MainPage : UserControl
    {
        private BasicWcfSvc.IBasicWcf _svc;
        private Func<BasicWcfSvc.BasicSimpleRequest, IObservable<BasicWcfSvc.BasicSimpleResponse>> _observ;

        public MainPage()
        {
            InitializeComponent();

            _svc = new BasicWcfSvc.BasicWcfClient();

            _observ = Observable.FromAsyncPattern<
                BasicWcfSvc.BasicSimpleRequest, BasicWcfSvc.BasicSimpleResponse>(
                _svc.BeginBasicSimple, _svc.EndBasicSimple);

            Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            IDisposable odisp = null;
            odisp = _observ(new BasicWcfSvc.BasicSimpleRequest { Message = "Aloha!" }).ObserveOnDispatcher().Subscribe(
                nx => txt.Text = nx.Message,
                erx => odisp.Dispose(),
                () => odisp.Dispose());
        }
    }
}
