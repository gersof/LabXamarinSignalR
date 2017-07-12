﻿using LabXamarinSignalR.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LabXamarinSignalR.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignalRLab1 : ContentPage
    {
        public SignalRLab1()
        {
            InitializeComponent();
            BindingContext = new SignalRLab1ViewModel();
        }


    }
}
