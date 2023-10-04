using BigPack.Db;
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

namespace BigPack.Presentation
{
    /// <summary>
    /// Логика взаимодействия для MaterialsViewPage.xaml
    /// </summary>
    public partial class MaterialsViewPage : Page
    {
        public MaterialsViewPage()
        {
            InitializeComponent();
            var dbcontext = new BigPackDbContext();
            var materials = dbcontext.Materials.ToList();

            MaterialsListView.ItemsSource = materials;
        }
    }
}
