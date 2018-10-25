using System.Windows;

namespace FlowDesigner
{
    public partial class MainWindow : Window
    {
        private MainWindowViewModel windowViewModel;

        public MainWindow()
        {
            InitializeComponent();

            windowViewModel = new MainWindowViewModel();
            this.DataContext = windowViewModel;
            this.Loaded += new RoutedEventHandler(Window_Loaded);
        }


        /// <summary>
        /// This shows you how you can create diagram items in code, which means you can 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
