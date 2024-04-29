using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ManuelitoWpf
{
    /// <summary>
    /// Logica di interazione per FineM.xaml
    /// </summary>
    public partial class FineM : Window
    {
        private bool _vittoria;
        public FineM(bool vittoria)
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            this.Height = 730;
            this.Width = 350;
            _vittoria = vittoria;
        }
    }
}
