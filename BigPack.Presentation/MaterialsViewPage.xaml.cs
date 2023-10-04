using AutoMapper;
using AutoMapper.QueryableExtensions;
using BigPack.Db;
using BigPack.Presentation.ViewModels;
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
        private readonly BigPackDbContext _dbCOntext;
        public MaterialsViewPage()
        {
            _dbCOntext = new BigPackDbContext();
            InitializeComponent();

            var mapperConfig = new MapperConfiguration(mc =>
            mc.AddProfile(new MaterialViewModelProfiler()));
            var mapper = mapperConfig.CreateMapper();

            var materials = _dbCOntext.Materials
                .ProjectTo<MaterialViewModel>(mapper.ConfigurationProvider)
                .ToList();

            MaterialsListView.ItemsSource = materials;
        }

        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void SortComboBoxType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FiltrComboBoxType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
