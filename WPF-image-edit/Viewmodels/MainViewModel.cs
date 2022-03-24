﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPF_image_edit.Viewmodels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private ImageSource _imageSource;
        public ImageSource Image { get { return _imageSource; } set { _imageSource = value; NotifyPropertyChanged(); } }



        public RelayCommand btnLoadImage { get; set; }
        public RelayCommand btnUnloadImage { get; set; }
        public RelayCommand btnApplyFilter { get; set; }
        public RelayCommand cbxParallel { get; set; }
        public RelayCommand btnColor2Grayscale { get; set; }
        public RelayCommand btnNegative { get; set; }

        public MainViewModel()
        {
            btnLoadImage = new RelayCommand(() =>
            {
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == true)
                {
                    BitmapImage bitmapImage = new BitmapImage(new Uri(dialog.FileName));
                    Image = bitmapImage;
                }
            });
            btnUnloadImage = new RelayCommand(() =>
            {
                Image = null;
            });
            btnApplyFilter = new RelayCommand(() =>
            {

            });
            cbxParallel = new RelayCommand(() =>
            {

            });
            btnColor2Grayscale = new RelayCommand(() =>
            {

            });
            btnNegative = new RelayCommand(() =>
            {

            });
        }
    }
}