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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Xml;
using System.Media;
using System.Threading;
using System.Diagnostics;
using System.Globalization;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;
using System.Windows.Markup;
using System.Windows.Interop;
using System.Windows.Threading;

namespace RenderAsDialog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var templates = new List<TemplateItem>();
            templates.Add(new TemplateItem() { Title = "Template1", IsFavorite = false });
            templates.Add(new TemplateItem() { Title = "Template2", IsFavorite = true });
            templates.Add(new TemplateItem() { Title = "Template3", IsFavorite = false });

            m_templateListBox.ItemsSource = templates;
        }


        private Boolean myIsFavorite = false;
        public Boolean IsFavorite
        {
            get { return myIsFavorite; }
            set
            {
                if (myIsFavorite != value)
                {
                    myIsFavorite = value;
//                     OnPropertyChanged("IsFavorite");
//                     OnPropertyChanged("VizFavOn");
//                     OnPropertyChanged("VizFavOff");
                }
            }
        }

        public Boolean IsEqualProject
        {
            get { return true; }
        }


        public Visibility VizFavOn
        {
            get
            {
                if (IsFavorite) return Visibility.Visible;
                return Visibility.Collapsed;
            }
        }

        public Visibility VizFavOff
        {
            get
            {
                if (IsFavorite) return Visibility.Collapsed;
                return Visibility.Visible;
            }
        }

        public Visibility VizEql
        {
            get
            {
                if (IsEqualProject) return Visibility.Visible;
                return Visibility.Hidden;
            }
        }

        private void ToggleFavorite(object sender, MouseButtonEventArgs e)
        {
            Image img = sender as Image;
            TemplateItem item = img.Tag as TemplateItem;
            item.IsFavorite = !item.IsFavorite;
            e.Handled = true;
        }

    }

    public class TemplateItem : INotifyPropertyChanged
    {
        public string Title { get; set; }
        private Boolean myIsFavorite = false;
        public bool IsFavorite {
            get
            {
                return myIsFavorite;
            }
            set
            {
                if (myIsFavorite != value)
                {
                    myIsFavorite = value;
                    OnPropertyChanged("IsFavorite");
                    OnPropertyChanged("ShowFavorite");
                    OnPropertyChanged("ShowNotFavorite");
                }

            }
        }

        public Visibility ShowFavorite
        {
            get { return IsFavorite ? Visibility.Visible : Visibility.Collapsed; }
        }

        public Visibility ShowNotFavorite
        {
            get { return IsFavorite ? Visibility.Collapsed : Visibility.Visible; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
