﻿using AutoMapper;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BigPack.Presentation
{
    /// <summary>
    /// Логика взаимодействия для MaterialsViewPage.xaml
    /// </summary>
    public partial class MaterialsViewPage : Page
    {
        private readonly BigPackDbContext _dbContext;
        private List<MaterialViewModel> materials;
        public MaterialsViewPage()
        {
            _dbContext = new BigPackDbContext();
            InitializeComponent();

            var mapperConfig = new MapperConfiguration(mc =>
            mc.AddProfile(new MaterialViewModelProfiler()));
            var mapper = mapperConfig.CreateMapper();

            var materials = _dbContext.Materials
                .ProjectTo<MaterialViewModel>(mapper.ConfigurationProvider)
                .ToList();
            MaterialsListView.ItemsSource = materials;

            Update();
        }

        private void Update()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            mc.AddProfile(new MaterialViewModelProfiler()));
            var mapper = mapperConfig.CreateMapper();

            var currentMaterials = _dbContext.Materials
                .ProjectTo<MaterialViewModel>(mapper.ConfigurationProvider)
                .ToList();

            currentMaterials = currentMaterials.Where(material =>
                material.MaterialName.ToLower().Contains(TextBoxSearch.Text.Trim().ToLower())).ToList();
            MaterialsListView.ItemsSource = currentMaterials;
        }

        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }


        private void SortComboBoxType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FiltrComboBoxType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
